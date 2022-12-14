using Nethereum.Util;
using Receiptinfo;
public class EthereumBotsDo
{
    decimal _value;
    private eEthereumType _type;
    private Dictionary<eEthereumType, Receiptinfo.Receiptinfo> _listReceipt = new Dictionary<eEthereumType, Receiptinfo.Receiptinfo>();
    private SmartContract.Token.Setup.E_token_setup basic_setup = new SmartContract.Token.Setup.E_token_setup();
    private Dictionary<eEthereumType, SmartContract.Token.Setup.E_token_setup> _dicEthereums = new Dictionary<eEthereumType, SmartContract.Token.Setup.E_token_setup>();
    public int cycleCount = 0;
    public EthereumBotsDo(eEthereumType type)
    {
        _type = type;
        _dicEthereums.Add(eEthereumType.ETH, new SmartContract.Token.Setup.Token_Setup_ETH());
        _dicEthereums.Add(eEthereumType.SSD, new SmartContract.Token.Setup.Token_Setup_SSD());
        _dicEthereums.Add(eEthereumType.RAM, new SmartContract.Token.Setup.Token_Setup_RAM());
        _dicEthereums.Add(eEthereumType.HARD, new SmartContract.Token.Setup.Token_Setup_HARD());
        _dicEthereums.Add(eEthereumType.SOFT, new SmartContract.Token.Setup.Token_Setup_SOFT());
    }
    public void GetInfo()
    {
        if (false == _dicEthereums.ContainsKey(_type)) throw new Exception("");
        var owner = _dicEthereums[_type];

        var rt_balance = Task.Run(async () => await new BalanceOf_Token_ETH(basic_setup.abi,
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
        if (false == _dicEthereums.ContainsKey(_type)) throw new Exception("");
        if (_value < UnitConversion.Convert.FromWei(3000)) throw new Exception("");

        var owner = _dicEthereums[_type];

        foreach (var other in _dicEthereums)
        {
            if (other.Value == owner) continue;

            var transfer = Task.Run(async () => await new Transfer_Token_ETH(basic_setup.abi,
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
                    using (var db = new Transaction_DB_eth())
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
