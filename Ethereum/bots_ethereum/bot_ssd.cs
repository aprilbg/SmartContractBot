using Nethereum.Util;
using Receiptinfo;

public class Bot_SSD
{
    decimal value_SSD;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.Token_Setup_ETH T_Setup_ETH = new SmartContract.Token.Setup.Token_Setup_ETH();
    private SmartContract.Token.Setup.Token_Setup_SSD T_Setup_SSD = new SmartContract.Token.Setup.Token_Setup_SSD();
    private SmartContract.Token.Setup.Token_Setup_RAM T_Setup_RAM = new SmartContract.Token.Setup.Token_Setup_RAM();
    private SmartContract.Token.Setup.Token_Setup_HARD T_Setup_HARD = new SmartContract.Token.Setup.Token_Setup_HARD();
    private SmartContract.Token.Setup.Token_Setup_SOFT T_Setup_SOFT = new SmartContract.Token.Setup.Token_Setup_SOFT();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_SSD = Task.Run(async () => await new BalanceOf_Token_ETH(T_Setup_SSD.abi,
                                                                        T_Setup_SSD._contractAddress,
                                                                        T_Setup_SSD._fromAddress,
                                                                        T_Setup_SSD._url).token_balance());
        rt_SSD.Wait();
        value_SSD = rt_SSD.Result;
        Console.WriteLine($"\nTokenBalance_SSD : {value_SSD}\n");
    }

    public void Transfer_Do()
    {
        if (value_SSD <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }
        var rt_SS_RA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SSD.abi,
                                                           T_Setup_SSD._contractAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_SSD._privateKey,
                                                           T_Setup_SSD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SS_RA.Wait();
        var info_SS_RA = rt_SS_RA.Result;
        if (null != info_SS_RA)
        {
            Save(info_SS_RA);
            Console.WriteLine($"\nTransactionHash_SS_RA = {info_SS_RA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SS_RA = is null");
        }

        var rt_SS_HA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SSD.abi,
                                                           T_Setup_SSD._contractAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_SSD._privateKey,
                                                           T_Setup_SSD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SS_HA.Wait();
        var info_SS_HA = rt_SS_HA.Result;
        if (null != info_SS_HA)
        {
            Save(info_SS_HA);
            Console.WriteLine($"\nTransactionHash_SS_HA = {info_SS_HA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SS_HA = is null");
        }

        var rt_SS_SO = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SSD.abi,
                                                           T_Setup_SSD._contractAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_SSD._privateKey,
                                                           T_Setup_SSD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SS_SO.Wait();
        var info_SS_SO = rt_SS_SO.Result;
        if (null != info_SS_SO)
        {
            Save(info_SS_SO);
            Console.WriteLine($"\nTransactionHash_SS_SO = {info_SS_SO.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SS_SO = is null");
        }

        var rt_SS_ET = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SSD.abi,
                                                           T_Setup_SSD._contractAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_SSD._privateKey,
                                                           T_Setup_SSD._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SS_ET.Wait();
        var info_SS_ET = rt_SS_ET.Result;
        if (null != info_SS_ET)
        {
            Save(info_SS_ET);
            Console.WriteLine($"\nTransactionHash_SS_ET = {info_SS_ET.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SS_ET = is null");
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
                db.SSD_transaction_data.Add(new SSD_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }

    }
}