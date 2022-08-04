using Nethereum.Util;
using Receiptinfo;

public class Bot_Matic
{
    decimal value_matic;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.token_setup_matic T_setup_matic = new SmartContract.Token.Setup.token_setup_matic();
    private SmartContract.Token.Setup.token_setup_apple T_setup_apple = new SmartContract.Token.Setup.token_setup_apple();
    private SmartContract.Token.Setup.token_setup_ham T_setup_ham = new SmartContract.Token.Setup.token_setup_ham();
    public int cycleCount = 0;

    public void Balance_DO()
    {
        var rt_matic = Task.Run(async () => await new BalanceOf_Token_Matic(T_setup_matic.abi,
                                                                          T_setup_matic._contractAddress,
                                                                          T_setup_matic._fromAddress,
                                                                          T_setup_matic._url).token_balance());
        rt_matic.Wait();
        value_matic = rt_matic.Result;
        Console.WriteLine($"\nTokenBalance_matic : {value_matic}\n");
    }
    public void Transfer_Do()
    {
        if (value_matic <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_ma_ap = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_matic.abi,
                                                             T_setup_matic._contractAddress,
                                                             T_setup_matic._fromAddress,
                                                             T_setup_apple._fromAddress,
                                                             T_setup_matic._privateKey,
                                                             T_setup_matic._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ma_ap.Wait();
        var info_ma_ap = rt_ma_ap.Result;
        if (null != info_ma_ap)
        {
            Save(info_ma_ap);
            Console.WriteLine($"\nTransactionHash_ma_ap = {info_ma_ap.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ma_ap = is null");
        }

        var rt_ma_ha = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_matic.abi,
                                                             T_setup_matic._contractAddress,
                                                             T_setup_matic._fromAddress,
                                                             T_setup_ham._fromAddress,
                                                             T_setup_matic._privateKey,
                                                             T_setup_matic._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ma_ha.Wait();
        var info_ma_ha = rt_ma_ha.Result;
        if (null != info_ma_ha)
        {
            Save(info_ma_ha);
            Console.WriteLine($"\nTransactionHash_ma_ha = {info_ma_ha.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ma_ha = is null");
        }
    }
    public void Save(Receiptinfo.Receiptinfo info)
    {
        List<Matic_Transaction_Logs> dbAdds = new List<Matic_Transaction_Logs>();
        foreach (var logs in info.Logs)
        {
            var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
            if (objLog == null) continue;
            dbAdds.Add(new Matic_Transaction_Logs
            {
                transactionHash = objLog.transactionHash,
                address = objLog.address,
                blockHash = objLog.blockHash,
                blockNumber = objLog.blockNumber,
                data = objLog.data,
                logIndex = objLog.logIndex,
                transactionIndex = objLog.transactionIndex
            });
        }

        using (var db = new Transaction_DB_matic())
        {
            db.matic_transaction_data.AddRange(dbAdds);
            db.SaveChanges();
        }
    }
}