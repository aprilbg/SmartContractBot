using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_five
{
    decimal value_five;
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
        var rt_five = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_five.abi,
                                                                        T_setup_five._contractAddress,
                                                                        T_setup_five._fromAddress,
                                                                        T_setup_five._url).token_balance());
        rt_five.Wait();
        value_five = rt_five.Result;
        Console.WriteLine($"\nTokenBalance_five : {value_five}\n");
    }

    public void Transfer_Do()
    {
        if (value_five <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_fi_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_on.Wait();
        var info_fi_on = rt_fi_on.Result;
        if (null != info_fi_on)
        {
            Save(info_fi_on);
            Console.WriteLine($"\nTransactionHash_fi_on = {info_fi_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_on = is null");
        }

        var rt_fi_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_tw.Wait();
        var info_fi_tw = rt_fi_tw.Result;
        if (null != info_fi_tw)
        {
            Save(info_fi_tw);
            Console.WriteLine($"\nTransactionHash_fi_tw = {info_fi_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_tw = is null");
        }

        var rt_fi_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_th.Wait();
        var info_fi_th = rt_fi_th.Result;
        if (null != info_fi_th)
        {
            Save(info_fi_th);
            Console.WriteLine($"\nTransactionHash_fi_th = {info_fi_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_th = is null");
        }

        var rt_fi_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_fo.Wait();
        var info_fi_fo = rt_fi_fo.Result;
        if (null != info_fi_fo)
        {
            Save(info_fi_fo);
            Console.WriteLine($"\nTransactionHash_fi_fo = {info_fi_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_fo = is null");
        }

        var rt_fi_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_si.Wait();
        var info_fi_si = rt_fi_si.Result;
        if (null != info_fi_si)
        {
            Save(info_fi_si);
            Console.WriteLine($"\nTransactionHash_fi_si = {info_fi_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_si = is null");
        }

        var rt_fi_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_se.Wait();
        var info_fi_se = rt_fi_se.Result;
        if (null != info_fi_se)
        {
            Save(info_fi_se);
            Console.WriteLine($"\nTransactionHash_fi_se = {info_fi_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_se = is null");
        }

        var rt_fi_ei = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_five.abi,
                                                           T_setup_five._contractAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_five._privateKey,
                                                           T_setup_five._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_fi_ei.Wait();
        var info_fi_ei = rt_fi_ei.Result;
        if (null != info_fi_ei)
        {
            Save(info_fi_ei);
            Console.WriteLine($"\nTransactionHash_fi_ei = {info_fi_ei.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_fi_ei = is null");
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
                db.five_transaction_data.Add(new five_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}