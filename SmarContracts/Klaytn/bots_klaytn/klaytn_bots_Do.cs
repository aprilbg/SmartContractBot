using Nethereum.Util;
using SmartContract.Klaytn;
using Receiptinfo;
public class KlaytnBotsDo
{
    decimal _value;
    private eKlaytnType _type;
    private Dictionary<eKlaytnType, KlayTransactionReceipt> _listReceipt = new Dictionary<eKlaytnType, KlayTransactionReceipt>();
    private SmartContract.Token.Setup.K_token_setup basic_setup = new SmartContract.Token.Setup.K_token_setup();
    private Dictionary<eKlaytnType, SmartContract.Token.Setup.K_token_setup> _dicKlaytns = new Dictionary<eKlaytnType, SmartContract.Token.Setup.K_token_setup>();
    public KlaytnBotsDo(eKlaytnType type)
    {
        _type = type;
        _dicKlaytns.Add(eKlaytnType.one, new SmartContract.Token.Setup.Token_Setup_one());
        _dicKlaytns.Add(eKlaytnType.two, new SmartContract.Token.Setup.Token_Setup_two());
        _dicKlaytns.Add(eKlaytnType.three, new SmartContract.Token.Setup.Token_Setup_three());
        _dicKlaytns.Add(eKlaytnType.four, new SmartContract.Token.Setup.Token_Setup_four());
        _dicKlaytns.Add(eKlaytnType.five, new SmartContract.Token.Setup.Token_Setup_five());
        _dicKlaytns.Add(eKlaytnType.six, new SmartContract.Token.Setup.Token_Setup_six());
        _dicKlaytns.Add(eKlaytnType.seven, new SmartContract.Token.Setup.Token_Setup_seven());
        _dicKlaytns.Add(eKlaytnType.eight, new SmartContract.Token.Setup.Token_Setup_eight());
    }
    public void GetInfo()
    {
        if (false == _dicKlaytns.ContainsKey(_type)) throw new Exception("");
        var owner = _dicKlaytns[_type];

        var rt_balance = Task.Run(async () => await new BalanceOf_Token_Klaytn(basic_setup.abi,
                                                                               owner._contractAddress,
                                                                               owner._fromAddress,
                                                                               basic_setup._url).token_balance());
        rt_balance.Wait();
        _value = rt_balance.Result;
        Console.WriteLine($"\nTokenBalance_{_type.ToString()} : {_value}");

    }
    public void Transfer()
    {
        _listReceipt.Clear();
        if (false == _dicKlaytns.ContainsKey(_type)) throw new Exception("");
        if (_value < UnitConversion.Convert.FromWei(3000)) throw new Exception("");

        var owner = _dicKlaytns[_type];
        foreach (var other in _dicKlaytns)
        {
            if (other.Value == owner) continue;

            var transfer = Task.Run(async () => await new Transfer_Token_Klaytn(basic_setup.abi,
                                                                                owner._contractAddress,
                                                                                owner._fromAddress,
                                                                                other.Value._fromAddress,
                                                                                owner._privateKey,
                                                                                basic_setup._url,
                                                                                80).token_transfer());
            transfer.Wait();
            if (transfer.Result != null)
            {
                Console.WriteLine($"Transaction From : {_type.ToString()} | Transaction To : {other.Key.ToString()} | Transaction Hash : {transfer.Result.TransactionHash}");
                _listReceipt.Add(other.Key, transfer.Result);
            }
            else
            {
                continue;
            }
        }
    }
    public void Save()
    {
        foreach (var Receipt in _listReceipt)
        {
            if (Receipt.Value.Logs != null)
            {
                foreach (var logs in Receipt.Value.Logs)
                {
                    var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
                    if (objLog == null) continue;
                    using (var db = new Transaction_DB_klaytn())
                    {
                        db.transaction_data.Add(new Transaction_Logs
                        {
                            CallHashFrom = _type.ToString(),
                            transactionHash = objLog.transactionHash,
                            address = objLog.address,
                            blockHash = objLog.blockHash,
                            blockNumber = objLog.blockNumber,
                            data = objLog.data,
                            logIndex = objLog.logIndex,
                            transactionIndex = objLog.transactionIndex
                        });
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}