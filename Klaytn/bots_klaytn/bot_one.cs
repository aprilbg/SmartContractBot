using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_one
{
    decimal value_one;
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
        var rt_one = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_one.abi,
                                                                        T_setup_one._contractAddress,
                                                                        T_setup_one._fromAddress,
                                                                        T_setup_one._url).token_balance());
        rt_one.Wait();
        value_one = rt_one.Result;
        Console.WriteLine($"\nTokenBalance_one : {value_one}\n");
    }

    public void Transfer_Do()
    {
        if (value_one <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_on_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_tw.Wait();
        var info_on_tw = rt_on_tw.Result;
        if (null != info_on_tw)
        {
            Save(info_on_tw);
            Console.WriteLine($"\nTransactionHash_on_tw = {info_on_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_tw = is null");
        }

        var rt_on_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_th.Wait();
        var info_on_th = rt_on_th.Result;
        if (null != info_on_th)
        {
            Save(info_on_th);
            Console.WriteLine($"\nTransactionHash_on_th = {info_on_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_th = is null");
        }

        var rt_on_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_fo.Wait();
        var info_on_fo = rt_on_fo.Result;
        if (null != info_on_fo)
        {
            Save(info_on_fo);
            Console.WriteLine($"\nTransactionHash_on_fo = {info_on_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_fo = is null");
        }

        var rt_on_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_fi.Wait();
        var info_on_fi = rt_on_fi.Result;
        if (null != info_on_fi)
        {
            Save(info_on_fi);
            Console.WriteLine($"\nTransactionHash_on_fi = {info_on_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_fi = is null");
        }

        var rt_on_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_si.Wait();
        var info_on_si = rt_on_si.Result;
        if (null != info_on_si)
        {
            Save(info_on_si);
            Console.WriteLine($"\nTransactionHash_on_si = {info_on_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_si = is null");
        }

        var rt_on_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_se.Wait();
        var info_on_se = rt_on_se.Result;
        if (null != info_on_se)
        {
            Save(info_on_se);
            Console.WriteLine($"\nTransactionHash_on_se = {info_on_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_se = is null");
        }

        var rt_on_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_one.abi,
                                                           T_setup_one._contractAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_one._privateKey,
                                                           T_setup_one._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_on_ei.Wait();
        var info_on_ei = rt_on_ei.Result;
        if (null != info_on_ei)
        {
            Save(info_on_ei);
            Console.WriteLine($"\nTransactionHash_on_ei = {info_on_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_on_ei = is null");
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
                db.one_transaction_data.Add(new one_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}