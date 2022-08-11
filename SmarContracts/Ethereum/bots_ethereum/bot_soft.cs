using Nethereum.Util;
using Receiptinfo;

public class Bot_SOFT
{
    decimal value_SOFT;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.Token_Setup_ETH T_Setup_ETH = new SmartContract.Token.Setup.Token_Setup_ETH();
    private SmartContract.Token.Setup.Token_Setup_SSD T_Setup_SSD = new SmartContract.Token.Setup.Token_Setup_SSD();
    private SmartContract.Token.Setup.Token_Setup_RAM T_Setup_RAM = new SmartContract.Token.Setup.Token_Setup_RAM();
    private SmartContract.Token.Setup.Token_Setup_HARD T_Setup_HARD = new SmartContract.Token.Setup.Token_Setup_HARD();
    private SmartContract.Token.Setup.Token_Setup_SOFT T_Setup_SOFT = new SmartContract.Token.Setup.Token_Setup_SOFT();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_SOFT = Task.Run(async () => await new BalanceOf_Token_ETH(T_Setup_SOFT.abi,
                                                                         T_Setup_SOFT._contractAddress,
                                                                         T_Setup_SOFT._fromAddress,
                                                                         T_Setup_SOFT._url).token_balance());
        rt_SOFT.Wait();
        value_SOFT = rt_SOFT.Result;
        Console.WriteLine($"\nTokenBalance_SOFT : {value_SOFT}\n");
    }

    public void Transfer_Do()
    {
        if (value_SOFT <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }
        var rt_SO_ET = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SOFT.abi,
                                                           T_Setup_SOFT._contractAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_SOFT._privateKey,
                                                           T_Setup_SOFT._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SO_ET.Wait();
        var info_SO_ET = rt_SO_ET.Result;
        if (null != info_SO_ET)
        {
            Save(info_SO_ET);
            Console.WriteLine($"\nTransactionHash_SO_ET = {info_SO_ET.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SO_ET = is null");
        }

        var rt_SO_SS = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SOFT.abi,
                                                           T_Setup_SOFT._contractAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_SOFT._privateKey,
                                                           T_Setup_SOFT._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SO_SS.Wait();
        var info_SO_SS = rt_SO_SS.Result;
        if (null != info_SO_SS)
        {
            Save(info_SO_SS);
            Console.WriteLine($"\nTransactionHash_SO_SS = {info_SO_SS.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SO_SS = is null");
        }

        var rt_SO_RA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SOFT.abi,
                                                           T_Setup_SOFT._contractAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_SOFT._privateKey,
                                                           T_Setup_SOFT._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SO_RA.Wait();
        var info_SO_RA = rt_SO_RA.Result;
        if (null != info_SO_RA)
        {
            Save(info_SO_RA);
            Console.WriteLine($"\nTransactionHash_SO_RA = {info_SO_RA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SO_RA = is null");
        }

        var rt_SO_HA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_SOFT.abi,
                                                           T_Setup_SOFT._contractAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_SOFT._privateKey,
                                                           T_Setup_SOFT._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_SO_HA.Wait();
        var info_SO_HA = rt_SO_HA.Result;
        if (null != info_SO_HA)
        {
            Save(info_SO_HA);
            Console.WriteLine($"\nTransactionHash_SO_HA = {info_SO_HA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_SO_HA = is null");
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
                db.SOFT_transaction_data.Add(new SOFT_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }

    }
}