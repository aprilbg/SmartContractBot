using Nethereum.Util;
using Receiptinfo;
using SmartContract.Klaytn;
public class Bot_eight
{
    decimal value_eight;
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
        var rt_eight = Task.Run(async () => await new BalanceOf_Token_Klaytn(T_setup_eight.abi,
                                                                        T_setup_eight._contractAddress,
                                                                        T_setup_eight._fromAddress,
                                                                        T_setup_eight._url).token_balance());
        rt_eight.Wait();
        value_eight = rt_eight.Result;
        Console.WriteLine($"\nTokenBalance_eight : {value_eight}\n");
    }

    public void Transfer_Do()
    {
        if (value_eight <= UnitConversion.Convert.FromWei(300))
        {
            return;
        }

        var rt_ei_on = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_one._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_on.Wait();
        var info_ei_on = rt_ei_on.Result;
        if (null != info_ei_on)
        {
            Save(info_ei_on);
            Console.WriteLine($"\nTransactionHash_ei_on = {info_ei_on.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_on = is null");
        }

        var rt_ei_tw = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_two._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_tw.Wait();
        var info_ei_tw = rt_ei_tw.Result;
        if (null != info_ei_tw)
        {
            Save(info_ei_tw);
            Console.WriteLine($"\nTransactionHash_ei_tw = {info_ei_tw.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_tw = is null");
        }

        var rt_ei_th = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_three._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_th.Wait();
        var info_ei_th = rt_ei_th.Result;
        if (null != info_ei_th)
        {
            Save(info_ei_th);
            Console.WriteLine($"\nTransactionHash_ei_th = {info_ei_th.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_th = is null");
        }

        var rt_ei_fo = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_four._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_fo.Wait();
        var info_ei_fo = rt_ei_fo.Result;
        if (null != info_ei_fo)
        {
            Save(info_ei_fo);
            Console.WriteLine($"\nTransactionHash_ei_fo = {info_ei_fo.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_fo = is null");
        }

        var rt_ei_fi = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_five._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_fi.Wait();
        var info_ei_fi = rt_ei_fi.Result;
        if (null != info_ei_fi)
        {
            Save(info_ei_fi);
            Console.WriteLine($"\nTransactionHash_ei_fi = {info_ei_fi.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_fi = is null");
        }

        var rt_ei_si = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_six._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_si.Wait();
        var info_ei_si = rt_ei_si.Result;
        if (null != info_ei_si)
        {
            Save(info_ei_si);
            Console.WriteLine($"\nTransactionHash_ei_si = {info_ei_si.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_si = is null");
        }

        var rt_ei_se = Task.Run(async () =>
        {
            KlayTransactionReceipt? receiptinfo = null;
            while (true)
            {
                receiptinfo = await new Transfer_Token_Klaytn(T_setup_eight.abi,
                                                           T_setup_eight._contractAddress,
                                                           T_setup_eight._fromAddress,
                                                           T_setup_seven._fromAddress,
                                                           T_setup_eight._privateKey,
                                                           T_setup_eight._url,
                                                           80).token_transfer(cycleCount);
                ++cycleCount;
                if (null != receiptinfo) break;
            }
            return receiptinfo;
        });
        rt_ei_se.Wait();
        var info_ei_se = rt_ei_se.Result;
        if (null != info_ei_se)
        {
            Save(info_ei_se);
            Console.WriteLine($"\nTransactionHash_ei_se = {info_ei_se.TransactionHash}\n");
        }
        else
        {
            Console.WriteLine("TransactionHash_ei_se = is null");
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
                db.eight_transaction_data.Add(new eight_Transaction_Logs { transactionHash = objLog.transactionHash, address = objLog.address, blockHash = objLog.blockHash, blockNumber = objLog.blockNumber, data = objLog.data, logIndex = objLog.logIndex, transactionIndex = objLog.transactionIndex });
                db.SaveChanges();
            }
        }
    }
}