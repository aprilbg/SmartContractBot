using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_three
{
    decimal value_three;
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
        var rt_three = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_three.abi,
                                                                        T_setup_three._contractAddress,
                                                                        T_setup_three._fromAddress,
                                                                        T_setup_three._url).token_balance());
        rt_three.Wait();
        value_three = rt_three.Result;
        Console.WriteLine($"\nTokenBalance_three : {value_three}\n");
    }

    public void Transfer_Do()
    {
        if (value_three <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_th_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_on.Wait();
        var info_th_on = rt_th_on.Result;
        if (null != info_th_on)
        {
            Save(info_th_on);
            Console.WriteLine($"\nTransactionHash_th_on = {info_th_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_on = is null");
        }

        var rt_th_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_tw.Wait();
        var info_th_tw = rt_th_tw.Result;
        if (null != info_th_tw)
        {
            Save(info_th_tw);
            Console.WriteLine($"\nTransactionHash_th_tw = {info_th_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_tw = is null");
        }

        var rt_th_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_fo.Wait();
        var info_th_fo = rt_th_fo.Result;
        if (null != info_th_fo)
        {
            Save(info_th_fo);
            Console.WriteLine($"\nTransactionHash_th_fo = {info_th_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_fo = is null");
        }

        var rt_th_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_fi.Wait();
        var info_th_fi = rt_th_fi.Result;
        if (null != info_th_fi)
        {
            Save(info_th_fi);
            Console.WriteLine($"\nTransactionHash_th_fi = {info_th_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_fi = is null");
        }

        var rt_th_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_si.Wait();
        var info_th_si = rt_th_si.Result;
        if (null != info_th_si)
        {
            Save(info_th_si);
            Console.WriteLine($"\nTransactionHash_th_si = {info_th_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_si = is null");
        }

        var rt_th_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_se.Wait();
        var info_th_se = rt_th_se.Result;
        if (null != info_th_se)
        {
            Save(info_th_se);
            Console.WriteLine($"\nTransactionHash_th_se = {info_th_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_se = is null");
        }

        var rt_th_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_three.abi,
                                                           T_setup_three._contractAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_three._privateKey,
                                                           T_setup_three._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_th_ei.Wait();
        var info_th_ei = rt_th_ei.Result;
        if (null != info_th_ei)
        {
            Save(info_th_ei);
            Console.WriteLine($"\nTransactionHash_th_ei = {info_th_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_th_ei = is null");
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
                db.three_transaction_data.Add(new three_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}