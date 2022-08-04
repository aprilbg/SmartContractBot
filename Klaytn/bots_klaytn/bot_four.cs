using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_four
{
    decimal value_four;
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
        var rt_four = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_four.abi,
                                                                        T_setup_four._contractAddress,
                                                                        T_setup_four._fromAddress,
                                                                        T_setup_four._url).token_balance());
        rt_four.Wait();
        value_four = rt_four.Result;
        Console.WriteLine($"\nTokenBalance_four : {value_four}\n");
    }

    public void Transfer_Do()
    {
        if (value_four <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_fo_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_on.Wait();
        var info_fo_on = rt_fo_on.Result;
        if (null != info_fo_on)
        {
            Save(info_fo_on);
            Console.WriteLine($"\nTransactionHash_fo_on = {info_fo_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_on = is null");
        }

        var rt_fo_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_tw.Wait();
        var info_fo_tw = rt_fo_tw.Result;
        if (null != info_fo_tw)
        {
            Save(info_fo_tw);
            Console.WriteLine($"\nTransactionHash_fo_tw = {info_fo_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_tw = is null");
        }

        var rt_fo_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_th.Wait();
        var info_fo_th = rt_fo_th.Result;
        if (null != info_fo_th)
        {
            Save(info_fo_th);
            Console.WriteLine($"\nTransactionHash_fo_th = {info_fo_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_th = is null");
        }

        var rt_fo_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_fi.Wait();
        var info_fo_fi = rt_fo_fi.Result;
        if (null != info_fo_fi)
        {
            Save(info_fo_fi);
            Console.WriteLine($"\nTransactionHash_fo_fi = {info_fo_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_fi = is null");
        }

        var rt_fo_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_si.Wait();
        var info_fo_si = rt_fo_si.Result;
        if (null != info_fo_si)
        {
            Save(info_fo_si);
            Console.WriteLine($"\nTransactionHash_fo_si = {info_fo_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_si = is null");
        }

        var rt_fo_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_se.Wait();
        var info_fo_se = rt_fo_se.Result;
        if (null != info_fo_se)
        {
            Save(info_fo_se);
            Console.WriteLine($"\nTransactionHash_fo_se = {info_fo_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_se = is null");
        }

        var rt_fo_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_four.abi,
                                                           T_setup_four._contractAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_four._privateKey,
                                                           T_setup_four._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fo_ei.Wait();
        var info_fo_ei = rt_fo_ei.Result;
        if (null != info_fo_ei)
        {
            Save(info_fo_ei);
            Console.WriteLine($"\nTransactionHash_fo_ei = {info_fo_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fo_ei = is null");
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
                db.four_transaction_data.Add(new four_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}