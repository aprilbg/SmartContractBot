using Nethereum.Util;
using Receiptinfo;

public class Bot_Ham
{
    decimal value_ham;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.token_setup_matic T_setup_matic = new SmartContract.Token.Setup.token_setup_matic();
    private SmartContract.Token.Setup.token_setup_apple T_setup_apple = new SmartContract.Token.Setup.token_setup_apple();
    private SmartContract.Token.Setup.token_setup_ham T_setup_ham = new SmartContract.Token.Setup.token_setup_ham();
    public int cycleCount = 0;

    public void Balance_DO()
    {
        var rt_ham = Task.Run(async () => await new BalanceOf_Token_Matic(T_setup_ham.abi,
                                                                        T_setup_ham._contractAddress,
                                                                        T_setup_ham._fromAddress,
                                                                        T_setup_ham._url).token_balance());
        rt_ham.Wait();
        value_ham = rt_ham.Result;
        Console.WriteLine($"\nTokenBalance_ham : {value_ham}\n");
    }
    public void Transfer_Do()
    {
        if (value_ham <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_ha_ma = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_ham.abi,
                                                             T_setup_ham._contractAddress,
                                                             T_setup_ham._fromAddress,
                                                             T_setup_matic._fromAddress,
                                                             T_setup_ham._privateKey,
                                                             T_setup_ham._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ha_ma.Wait();
        var info_ha_ma = rt_ha_ma.Result;
        if (null != info_ha_ma)
        {
            Save(info_ha_ma);
            Console.WriteLine($"\nTransactionHash_ha_ma = {info_ha_ma.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ha_ma = is null");
        }

        var rt_ha_ap = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_ham.abi,
                                                             T_setup_ham._contractAddress,
                                                             T_setup_ham._fromAddress,
                                                             T_setup_apple._fromAddress,
                                                             T_setup_ham._privateKey,
                                                             T_setup_ham._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ha_ap.Wait();
        var info_ha_ap = rt_ha_ap.Result;
        if (null != info_ha_ap)
        {
            Save(info_ha_ap);
            Console.WriteLine($"\nTransactionHash_ha_ap = {info_ha_ap.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ha_ap = is null");
        }
    }
    public void Save(Receiptinfo.Receiptinfo info)
    {

        List<Ham_Transaction_Logs> dbAdds = new List<Ham_Transaction_Logs>();
        foreach (var logs in info.Logs)
        {
            var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
            if (objLog == null) continue;
            dbAdds.Add(new Ham_Transaction_Logs
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
            db.ham_transaction_data.AddRange(dbAdds);
            db.SaveChanges();
        }
    }
}