using Nethereum.Util;
using Receiptinfo;
public class MaticBotsDo
{
    decimal _value;
    private eMaticType _type;
    private Dictionary<eMaticType, Receiptinfo.Receiptinfo> _listReceipt = new Dictionary<eMaticType, Receiptinfo.Receiptinfo>();
    private SmartContract.Token.Setup.M_token_setup basic_setup = new SmartContract.Token.Setup.M_token_setup();
    private Dictionary<eMaticType, SmartContract.Token.Setup.M_token_setup> _dicMatics = new Dictionary<eMaticType, SmartContract.Token.Setup.M_token_setup>();
    public int cycleCount = 0;
    public int wholeCount = 0;
    public MaticBotsDo(eMaticType type)
    {
        _type = type;
        _dicMatics.Add(eMaticType.matic, new SmartContract.Token.Setup.token_setup_matic());
        _dicMatics.Add(eMaticType.apple, new SmartContract.Token.Setup.token_setup_apple());
        _dicMatics.Add(eMaticType.ham, new SmartContract.Token.Setup.token_setup_ham());
    }
    public void GetInfo()
    {
        if (false == _dicMatics.ContainsKey(_type)) throw new Exception("");
        var owner = _dicMatics[_type];

        var rt_balance = Task.Run(async () => await new BalanceOf_Token_Matic(basic_setup.abi,
                                                                               owner._contractAddress,
                                                                               owner._fromAddress,
                                                                               basic_setup._url).token_balance());
        rt_balance.Wait();
        _value = rt_balance.Result;
        Console.WriteLine($"\nTokenBalance_{_type.ToString()} : {_value}");
    }
    public void Transfer()
    {
        if (false == _dicMatics.ContainsKey(_type)) throw new Exception("");
        if (_value < UnitConversion.Convert.FromWei(3000)) throw new Exception("");

        var owner = _dicMatics[_type];

        foreach (var other in _dicMatics)
        {
            if (other.Value == owner) continue;

            var transfer = Task.Run(async () => await new Transfer_Token_Matic(basic_setup.abi,
                                                                             owner._contractAddress,
                                                                             owner._fromAddress,
                                                                             other.Value._fromAddress,
                                                                             owner._privateKey,
                                                                             basic_setup._url,
                                                                             80).token_transfer(cycleCount));
            ++cycleCount;
            transfer.Wait();
            if (transfer.Result != null)
            {
                Console.WriteLine($"Transaction From : {_type.ToString()} | Transaction To : {other.Key.ToString()} Transaction Hash : {transfer.Result.TransactionHash}");
                _listReceipt.Add(_type, transfer.Result);
            }
        }
    }
    public void Save()
    {
        ++wholeCount;
        if (wholeCount > 1)
        {
            _listReceipt.Clear();
        }
        foreach (var Receipt in _listReceipt)
        {
            if (Receipt.Value.Logs != null)
            {
                foreach (var logs in Receipt.Value.Logs)
                {
                    var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
                    if (objLog == null) continue;
                    using (var db = new Transaction_DB_matic())
                    {
                        db.transaction_data.Add(new Transaction_Logs
                        {
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