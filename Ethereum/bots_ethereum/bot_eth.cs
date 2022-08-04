using Nethereum.Util;
using Receiptinfo;

public class Bot_ETH
{
    decimal value_ETH;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.Token_Setup_ETH T_Setup_ETH = new SmartContract.Token.Setup.Token_Setup_ETH();
    private SmartContract.Token.Setup.Token_Setup_SSD T_Setup_SSD = new SmartContract.Token.Setup.Token_Setup_SSD();
    private SmartContract.Token.Setup.Token_Setup_RAM T_Setup_RAM = new SmartContract.Token.Setup.Token_Setup_RAM();
    private SmartContract.Token.Setup.Token_Setup_HARD T_Setup_HARD = new SmartContract.Token.Setup.Token_Setup_HARD();
    private SmartContract.Token.Setup.Token_Setup_SOFT T_Setup_SOFT = new SmartContract.Token.Setup.Token_Setup_SOFT();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_ETH = Task.Run(async () => await new BalanceOf_Token_ETH(T_Setup_ETH.abi,
                                                                        T_Setup_ETH._contractAddress,
                                                                        T_Setup_ETH._fromAddress,
                                                                        T_Setup_ETH._url).token_balance());
        rt_ETH.Wait();
        value_ETH = rt_ETH.Result;
        Console.WriteLine($"\nTokenBalance_ETH : {value_ETH}\n");
    }

    public void Transfer_Do()
    {
        if (value_ETH <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_ET_SS = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_ETH.abi,
                                                           T_Setup_ETH._contractAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_ETH._privateKey,
                                                           T_Setup_ETH._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ET_SS.Wait();
        var info_ET_SS = rt_ET_SS.Result;
        if (null != info_ET_SS)
        {
            Save(info_ET_SS);
            Console.WriteLine($"\nTransactionHash_ET_SS = {info_ET_SS.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ET_SS = is null");
        }

        var rt_ET_RA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_ETH.abi,
                                                           T_Setup_ETH._contractAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_ETH._privateKey,
                                                           T_Setup_ETH._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ET_RA.Wait();
        var info_ET_RA = rt_ET_RA.Result;
        if (null != info_ET_RA)
        {
            Save(info_ET_RA);
            Console.WriteLine($"\nTransactionHash_ET_RA = {info_ET_RA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ET_RA = is null");
        }

        var rt_ET_HA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_ETH.abi,
                                                           T_Setup_ETH._contractAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_ETH._privateKey,
                                                           T_Setup_ETH._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ET_HA.Wait();
        var info_ET_HA = rt_ET_HA.Result;
        if (null != info_ET_HA)
        {
            Save(info_ET_HA);
            Console.WriteLine($"\nTransactionHash_ET_HA = {info_ET_HA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ET_HA = is null");
        }

        var rt_ET_SO = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_ETH.abi,
                                                           T_Setup_ETH._contractAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_ETH._privateKey,
                                                           T_Setup_ETH._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ET_SO.Wait();
        var info_ET_SO = rt_ET_SO.Result;
        if (null != info_ET_SO)
        {
            Save(info_ET_SO);
            Console.WriteLine($"\nTransactionHash_ET_SO = {info_ET_SO.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ET_SO = is null");
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
                db.ETH_transaction_data.Add(new ETH_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }

    }
}