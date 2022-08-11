using Nethereum.Util;
using Receiptinfo;

public class Bot_HARD
{
    decimal value_HARD;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.Token_Setup_ETH T_Setup_ETH = new SmartContract.Token.Setup.Token_Setup_ETH();
    private SmartContract.Token.Setup.Token_Setup_SSD T_Setup_SSD = new SmartContract.Token.Setup.Token_Setup_SSD();
    private SmartContract.Token.Setup.Token_Setup_RAM T_Setup_RAM = new SmartContract.Token.Setup.Token_Setup_RAM();
    private SmartContract.Token.Setup.Token_Setup_HARD T_Setup_HARD = new SmartContract.Token.Setup.Token_Setup_HARD();
    private SmartContract.Token.Setup.Token_Setup_SOFT T_Setup_SOFT = new SmartContract.Token.Setup.Token_Setup_SOFT();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_HARD = Task.Run(async () => await new BalanceOf_Token_ETH(T_Setup_HARD.abi,
                                                                         T_Setup_HARD._contractAddress,
                                                                         T_Setup_HARD._fromAddress,
                                                                         T_Setup_HARD._url).token_balance());
        rt_HARD.Wait();
        value_HARD = rt_HARD.Result;
        Console.WriteLine($"\nTokenBalance_HARD : {value_HARD}\n");
    }

    public void Transfer_Do()
    {
        if (value_HARD <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }
        
        var rt_HA_SO = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_HARD.abi,
                                                           T_Setup_HARD._contractAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_HARD._privateKey,
                                                           T_Setup_HARD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_HA_SO.Wait();
        var info_HA_SO = rt_HA_SO.Result;
        if (null != info_HA_SO)
        {
            Save(info_HA_SO);
            Console.WriteLine($"\nTransactionHash_HA_SO = {info_HA_SO.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_HA_SO = is null");
        }

        var rt_HA_ET = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_HARD.abi,
                                                           T_Setup_HARD._contractAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_HARD._privateKey,
                                                           T_Setup_HARD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_HA_ET.Wait();
        var info_HA_ET = rt_HA_ET.Result;
        if (null != info_HA_ET)
        {
            Save(info_HA_ET);
            Console.WriteLine($"\nTransactionHash_HA_ET = {info_HA_ET.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_HA_ET = is null");
        }

        var rt_HA_SS = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_HARD.abi,
                                                           T_Setup_HARD._contractAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_HARD._privateKey,
                                                           T_Setup_HARD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_HA_SS.Wait();
        var info_HA_SS = rt_HA_SS.Result;
        if (null != info_HA_SS)
        {
            Save(info_HA_SS);
            Console.WriteLine($"\nTransactionHash_HA_SS = {info_HA_SS.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_HA_SS = is null");
        }

        var rt_HA_RA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_HARD.abi,
                                                           T_Setup_HARD._contractAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_HARD._privateKey,
                                                           T_Setup_HARD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_HA_RA.Wait();
        var info_HA_RA = rt_HA_RA.Result;
        if (null != info_HA_RA)
        {
            Save(info_HA_RA);
            Console.WriteLine($"\nTransactionHash_HA_RA = {info_HA_RA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_HA_RA = is null");
        }
    }
    public void Save(Receiptinfo.Receiptinfo info)
    {
        foreach (var logs in info.Logs)
        {
            var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
            if (objLog == null) continue;
            using (var db = new Transaction_DB_eth())
            {
                db.HARD_transaction_data.Add(new HARD_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }

    }
}