using Nethereum.Util;
using Receiptinfo;

public class Bot_Apple
{
    decimal value_apple;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.token_setup_matic T_setup_matic = new SmartContract.Token.Setup.token_setup_matic();
    private SmartContract.Token.Setup.token_setup_apple T_setup_apple = new SmartContract.Token.Setup.token_setup_apple();
    private SmartContract.Token.Setup.token_setup_ham T_setup_ham = new SmartContract.Token.Setup.token_setup_ham();
    public int cycleCount = 0;

    public void Balance_DO()
    {
        var rt_apple = Task.Run(async () => await new BalanceOf_Token_Matic(T_setup_apple.abi,
                                                                          T_setup_apple._contractAddress,
                                                                          T_setup_apple._fromAddress,
                                                                          T_setup_apple._url).token_balance());
        rt_apple.Wait();
        value_apple = rt_apple.Result;
        Console.WriteLine($"\nTokenBalance_apple : {value_apple}\n");
    }
    public void Transfer_Do()
    {
        if (value_apple <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_ap_ma = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_apple.abi,
                                                             T_setup_apple._contractAddress,
                                                             T_setup_apple._fromAddress,
                                                             T_setup_matic._fromAddress,
                                                             T_setup_apple._privateKey,
                                                             T_setup_apple._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ap_ma.Wait();
        var info_ap_ma = rt_ap_ma.Result;
        if (null != info_ap_ma)
        {
            Save(info_ap_ma);
            Console.WriteLine($"\nTransactionHash_ap_ma = {info_ap_ma.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ap_ma = is null");
        }

        var rt_ap_ha = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Matic(T_setup_apple.abi,
                                                             T_setup_apple._contractAddress,
                                                             T_setup_apple._fromAddress,
                                                             T_setup_ham._fromAddress,
                                                             T_setup_apple._privateKey,
                                                             T_setup_apple._url,
                                                             80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ap_ha.Wait();
        var info_ap_ha = rt_ap_ha.Result;
        if (null != info_ap_ha)
        {
            Save(info_ap_ha);
            Console.WriteLine($"\nTransactionHash_ap_ha = {info_ap_ha.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ap_ha = is null");
        }
    }
    public void Save(Receiptinfo.Receiptinfo info)
    {
        List<Apple_Transaction_Logs> dbAdds = new List<Apple_Transaction_Logs>();
        foreach (var logs in info.Logs)
        {
            var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
            if (objLog == null) continue;
            dbAdds.Add(new Apple_Transaction_Logs
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
            db.apple_transaction_data.AddRange(dbAdds);
            db.SaveChanges();
        }
    }
}