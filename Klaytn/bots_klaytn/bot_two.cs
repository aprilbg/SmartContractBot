using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_two
{
    decimal value_two;
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
        var rt_two = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_two.abi,
                                                                        T_setup_two._contractAddress,
                                                                        T_setup_two._fromAddress,
                                                                        T_setup_two._url).token_balance());
        rt_two.Wait();
        value_two = rt_two.Result;
        Console.WriteLine($"\nTokenBalance_two : {value_two}\n");
    }

    public void Transfer_Do()
    {
        if (value_two <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_tw_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_on.Wait();
        var info_tw_on = rt_tw_on.Result;
        if (null != info_tw_on)
        {
            Save(info_tw_on);
            Console.WriteLine($"\nTransactionHash_tw_on = {info_tw_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_on = is null");
        }

        var rt_tw_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_th.Wait();
        var info_tw_th = rt_tw_th.Result;
        if (null != info_tw_th)
        {
            Save(info_tw_th);
            Console.WriteLine($"\nTransactionHash_tw_th = {info_tw_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_th = is null");
        }

        var rt_tw_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_fo.Wait();
        var info_tw_fo = rt_tw_fo.Result;
        if (null != info_tw_fo)
        {
            Save(info_tw_fo);
            Console.WriteLine($"\nTransactionHash_tw_fo = {info_tw_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_fo = is null");
        }

        var rt_tw_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_fi.Wait();
        var info_tw_fi = rt_tw_fi.Result;
        if (null != info_tw_fi)
        {
            Save(info_tw_fi);
            Console.WriteLine($"\nTransactionHash_tw_fi = {info_tw_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_fi = is null");
        }

        var rt_tw_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_si.Wait();
        var info_tw_si = rt_tw_si.Result;
        if (null != info_tw_si)
        {
            Save(info_tw_si);
            Console.WriteLine($"\nTransactionHash_tw_si = {info_tw_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_si = is null");
        }

        var rt_tw_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_se.Wait();
        var info_tw_se = rt_tw_se.Result;
        if (null != info_tw_se)
        {
            Save(info_tw_se);
            Console.WriteLine($"\nTransactionHash_tw_se = {info_tw_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_se = is null");
        }

        var rt_tw_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_two.abi,
                                                           T_setup_two._contractAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_two._privateKey,
                                                           T_setup_two._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_tw_ei.Wait();
        var info_tw_ei = rt_tw_ei.Result;
        if (null != info_tw_ei)
        {
            Save(info_tw_ei);
            Console.WriteLine($"\nTransactionHash_tw_ei = {info_tw_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_tw_ei = is null");
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
                db.two_transaction_data.Add(new two_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}