using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_seven
{
    decimal value_seven;
    KlayTransactionReceipt info = new KlayTransactionReceipt();
    private SmartContract.Token.Setup.Token_Setup_one T_setup_one = new SmartContract.Token.Setup.Token_Setup_one();
    private SmartContract.Token.Setup.Token_Setup_two T_setup_two = new SmartContract.Token.Setup.Token_Setup_two();
    private SmartContract.Token.Setup.Token_Setup_three T_setup_three = new SmartContract.Token.Setup.Token_Setup_three();
    private SmartContract.Token.Setup.Token_Setup_four T_setup_four = new SmartContract.Token.Setup.Token_Setup_four();
    private SmartContract.Token.Setup.Token_Setup_five T_setup_five = new SmartContract.Token.Setup.Token_Setup_five();
    private SmartContract.Token.Setup.Token_Setup_six T_setup_six = new SmartContract.Token.Setup.Token_Setup_six();
    private SmartContract.Token.Setup.Token_Setup_seven T_setup_seven = new SmartContract.Token.Setup.Token_Setup_seven();
    private SmartContract.Token.Setup.Token_Setup_eight T_setup_eight = new SmartContract.Token.Setup.Token_Setup_eight();
    public int cycleCount = 0;
    public void Balance_DO()
    {
        var rt_seven = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_seven.abi,
                                                                        T_setup_seven._contractAddress,
                                                                        T_setup_seven._fromAddress,
                                                                        T_setup_seven._url).token_balance());
        rt_seven.Wait();
        value_seven = rt_seven.Result;
        Console.WriteLine($"\nTokenBalance_seven : {value_seven}\n");
    }

    public void Transfer_Do()
    {
        if (value_seven <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_se_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_on.Wait();
        var info_se_on = rt_se_on.Result;
        if (null != info_se_on)
        {
            Save(info_se_on);
            Console.WriteLine($"\nTransactionHash_se_on = {info_se_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_on = is null");
        }

        var rt_se_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_tw.Wait();
        var info_se_tw = rt_se_tw.Result;
        if (null != info_se_tw)
        {
            Save(info_se_tw);
            Console.WriteLine($"\nTransactionHash_se_tw = {info_se_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_tw = is null");
        }

        var rt_se_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_th.Wait();
        var info_se_th = rt_se_th.Result;
        if (null != info_se_th)
        {
            Save(info_se_th);
            Console.WriteLine($"\nTransactionHash_se_th = {info_se_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_th = is null");
        }

        var rt_se_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_fo.Wait();
        var info_se_fo = rt_se_fo.Result;
        if (null != info_se_fo)
        {
            Save(info_se_fo);
            Console.WriteLine($"\nTransactionHash_se_fo = {info_se_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_fo = is null");
        }

        var rt_se_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_fi.Wait();
        var info_se_fi = rt_se_fi.Result;
        if (null != info_se_fi)
        {
            Save(info_se_fi);
            Console.WriteLine($"\nTransactionHash_se_fi = {info_se_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_fi = is null");
        }

        var rt_se_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_si.Wait();
        var info_se_si = rt_se_si.Result;
        if (null != info_se_si)
        {
            Save(info_se_si);
            Console.WriteLine($"\nTransactionHash_se_si = {info_se_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_si = is null");
        }

        var rt_se_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_seven.abi,
                                                           T_setup_seven._contractAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_seven._privateKey,
                                                           T_setup_seven._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_se_ei.Wait();
        var info_se_ei = rt_se_ei.Result;
        if (null != info_se_ei)
        {
            Save(info_se_ei);
            Console.WriteLine($"\nTransactionHash_se_ei = {info_se_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_se_ei = is null");
        }
    }

    public void Save(KlayTransactionReceipt info)
    {
        foreach (var logs in info.Logs)
        {
            var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
            if (objLog == null) continue;
            using (var db = new Transaction_DB_klaytn())
            {
                db.seven_transaction_data.Add(new seven_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}