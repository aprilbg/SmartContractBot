using Nethereum.Util;
using Receiptinfo;

public class Bot_RAM
{
    decimal value_RAM;
    Receiptinfo.Receiptinfo info = new Receiptinfo.Receiptinfo();
    private SmartContract.Token.Setup.Token_Setup_ETH T_Setup_ETH = new SmartContract.Token.Setup.Token_Setup_ETH();
    private SmartContract.Token.Setup.Token_Setup_SSD T_Setup_SSD = new SmartContract.Token.Setup.Token_Setup_SSD();
    private SmartContract.Token.Setup.Token_Setup_RAM T_Setup_RAM = new SmartContract.Token.Setup.Token_Setup_RAM();
    private SmartContract.Token.Setup.Token_Setup_HARD T_Setup_HARD = new SmartContract.Token.Setup.Token_Setup_HARD();
    private SmartContract.Token.Setup.Token_Setup_SOFT T_Setup_SOFT = new SmartContract.Token.Setup.Token_Setup_SOFT();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_RAM = Task.Run(async () => await new BalanceOf_Token_ETH(T_Setup_RAM.abi,
                                                                        T_Setup_RAM._contractAddress,
                                                                        T_Setup_RAM._fromAddress,
                                                                        T_Setup_RAM._url).token_balance());
        rt_RAM.Wait();
        value_RAM = rt_RAM.Result;
        Console.WriteLine($"\nTokenBalance_RAM : {value_RAM}\n");
    }

    public void Transfer_Do()
    {
        if (value_RAM <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }
        
        var rt_RA_HA = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_RAM.abi,
                                                           T_Setup_RAM._contractAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_HARD._fromAddress,
                                                           T_Setup_RAM._privateKey,
                                                           T_Setup_RAM._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_RA_HA.Wait();
        var info_RA_HA = rt_RA_HA.Result;
        if (null != info_RA_HA)
        {
            Save(info_RA_HA);
            Console.WriteLine($"\nTransactionHash_RA_HA = {info_RA_HA.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_RA_HA = is null");
        }

        var rt_RA_SO = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_RAM.abi,
                                                           T_Setup_RAM._contractAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_SOFT._fromAddress,
                                                           T_Setup_RAM._privateKey,
                                                           T_Setup_RAM._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_RA_SO.Wait();
        var info_RA_SO = rt_RA_SO.Result;
        if (null != info_RA_SO)
        {
            Save(info_RA_SO);
            Console.WriteLine($"\nTransactionHash_RA_SO = {info_RA_SO.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_RA_SO = is null");
        }

        var rt_RA_ET = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_RAM.abi,
                                                           T_Setup_RAM._contractAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_ETH._fromAddress,
                                                           T_Setup_RAM._privateKey,
                                                           T_Setup_RAM._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_RA_ET.Wait();
        var info_RA_ET = rt_RA_ET.Result;
        if (null != info_RA_ET)
        {
            Save(info_RA_ET);
            Console.WriteLine($"\nTransactionHash_RA_ET = {info_RA_ET.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_RA_ET = is null");
        }

        var rt_RA_SS = Task.Run(async () =>
        {
            Receiptinfo.Receiptinfo? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_ETH(T_Setup_RAM.abi,
                                                           T_Setup_RAM._contractAddress,
                                                           T_Setup_RAM._fromAddress,
                                                           T_Setup_SSD._fromAddress,
                                                           T_Setup_RAM._privateKey,
                                                           T_Setup_RAM._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_RA_SS.Wait();
        var info_RA_SS = rt_RA_SS.Result;
        if (null != info_RA_SS)
        {
            Save(info_RA_SS);
            Console.WriteLine($"\nTransactionHash_RA_SS = {info_RA_SS.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_RA_SS = is null");
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
                db.RAM_transaction_data.Add(new RAM_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }

    }
}