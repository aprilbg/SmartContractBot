using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
class Transfer_Token_ETH
{
    public Contract _contract;
    EthApiService eas;
    Nethereum.Web3.Web3 web3;
    string _fromAddress;
    string _toAddress;
    string _privateKey;
    int Value;
    public bool Cycle { get; protected set; }
    public Transfer_Token_ETH(string abi, string contractAddress, string fromAddress, string toAddress, string privateKey, string url, int value)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _toAddress = toAddress;
        _privateKey = privateKey;
        web3 = new Nethereum.Web3.Web3(url);
        eas = new EthApiService(web3.Client);
        Value = value;
    }
    public async Task<Receiptinfo.Receiptinfo?> token_transfer(int cycleCount = 0)
    {
        Function _fnTransferFunction = _contract.GetFunction("transfer");
        TransactionInput _transactionInput = _fnTransferFunction.CreateTransactionInput(_fromAddress, _toAddress, UnitConversion.Convert.ToWei(Value));
        HexBigInteger gas = await eas.Transactions.EstimateGas.SendRequestAsync(_transactionInput);
        _transactionInput.Gas = gas;
        if (cycleCount == 0)
        {
            HexBigInteger gasPrice = await eas.GasPrice.SendRequestAsync();
            _transactionInput.GasPrice = gasPrice;
        }
        else
        {
            HexBigInteger gasPrice = await eas.GasPrice.SendRequestAsync();
            var tenth = System.Numerics.BigInteger.Divide(gasPrice.Value, 20) * (1 + cycleCount);
            var newGasprice = System.Numerics.BigInteger.Add(gasPrice.Value, tenth);
            _transactionInput.GasPrice = new HexBigInteger(newGasprice);
        }
        HexBigInteger nonce = await eas.Transactions.GetTransactionCount.SendRequestAsync(_fromAddress, BlockParameter.CreateLatest());
        _transactionInput.Nonce = nonce;
        HexBigInteger value = _transactionInput.Value;
        if (value == null)
        {
            value = new HexBigInteger(0);
        }
        LegacyTransaction transaction = new LegacyTransaction(_transactionInput.To,
                                                              value.Value,
                                                              nonce,
                                                              _transactionInput.GasPrice.Value,
                                                              _transactionInput.Gas.Value,
                                                              _transactionInput.Data);
        transaction.Sign(new EthECKey(_privateKey.HexToByteArray(), true));
        string signedTransaction = transaction.GetRLPEncoded().ToHex();
        string hash = await eas.Transactions.SendRawTransaction.SendRequestAsync(signedTransaction);
        TransactionReceipt? receipt = null;
        int i = 0;
        while (receipt == null || i < 20)
        {
            receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(hash);
            i += 1;
            if (receipt == null)
                await Task.Delay(3000);

            if (receipt != null || i == 19)
            {
                break;
            }
        }

        if (receipt == null)
        {
            Console.WriteLine($"check hash : {hash}");
            return null;
        }
        else
        {
            return new Receiptinfo.Receiptinfo
            {
                To = receipt.To,
                Logs = receipt.Logs,
                ContractAddress = receipt.ContractAddress,
                From = receipt.From,
                BlockNumber = receipt.BlockNumber,
                TransactionIndex = receipt.TransactionIndex,
                TransactionHash = receipt.TransactionHash
            };
        }

    }
}