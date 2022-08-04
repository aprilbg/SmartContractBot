using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_six
{
    decimal value_six;
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
        var rt_six = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_six.abi,
                                                                        T_setup_six._contractAddress,
                                                                        T_setup_six._fromAddress,
                                                                        T_setup_six._url).token_balance());
        rt_six.Wait();
        value_six = rt_six.Result;
        Console.WriteLine($"\nTokenBalance_six : {value_six}\n");
    }

    public void Transfer_Do()
    {
        if (value_six <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_si_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_on.Wait();
        var info_si_on = rt_si_on.Result;
        if (null != info_si_on)
        {
            Save(info_si_on);
            Console.WriteLine($"\nTransactionHash_si_on = {info_si_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_on = is null");
        }

        var rt_si_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_tw.Wait();
        var info_si_tw = rt_si_tw.Result;
        if (null != info_si_tw)
        {
            Save(info_si_tw);
            Console.WriteLine($"\nTransactionHash_si_tw = {info_si_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_tw = is null");
        }

        var rt_si_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_th.Wait();
        var info_si_th = rt_si_th.Result;
        if (null != info_si_th)
        {
            Save(info_si_th);
            Console.WriteLine($"\nTransactionHash_si_th = {info_si_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_th = is null");
        }

        var rt_si_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_fo.Wait();
        var info_si_fo = rt_si_fo.Result;
        if (null != info_si_fo)
        {
            Save(info_si_fo);
            Console.WriteLine($"\nTransactionHash_si_fo = {info_si_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_fo = is null");
        }

        var rt_si_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_fi.Wait();
        var info_si_fi = rt_si_fi.Result;
        if (null != info_si_fi)
        {
            Save(info_si_fi);
            Console.WriteLine($"\nTransactionHash_si_fi = {info_si_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_fi = is null");
        }

        var rt_si_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_se.Wait();
        var info_si_se = rt_si_se.Result;
        if (null != info_si_se)
        {
            Save(info_si_se);
            Console.WriteLine($"\nTransactionHash_si_se = {info_si_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_se = is null");
        }

        var rt_si_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_six.abi,
                                                           T_setup_six._contractAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_six._privateKey,
                                                           T_setup_six._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_si_ei.Wait();
        var info_si_ei = rt_si_ei.Result;
        if (null != info_si_ei)
        {
            Save(info_si_ei);
            Console.WriteLine($"\nTransactionHash_si_ei = {info_si_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_si_ei = is null");
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
                db.six_transaction_data.Add(new six_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}