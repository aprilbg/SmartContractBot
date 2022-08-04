using SmartContract.Klaytn.JsonRpc.UnityClient;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Util;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using SmartContract.Klaytn;

class Transfer_Token_Klaytn
{
    public Contract _contract;
    EthApiService eas;
    Nethereum.Web3.Web3 web3;
    string _fromAddress;
    string _toAddress;
    string _privateKey;
    int Value;
    public bool Cycle { get; protected set; }
    private KlkaytnSmartContractTransactionSignedRequest _smartContractTransactionSignedReqeust;
    private klayGetTransactionReceiptPollingRequest _klayGetTransactionReceiptPollingRequest;
    public Transfer_Token_Klaytn(string abi, string contractAddress, string fromAddress, string toAddress, string privateKey, string url, int value)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _toAddress = toAddress;
        _privateKey = privateKey;
        web3 = new Nethereum.Web3.Web3(url);
        eas = new EthApiService(web3.Client);
        Value = value;
        _smartContractTransactionSignedReqeust = new KlkaytnSmartContractTransactionSignedRequest(url, fromAddress, privateKey, 1001);
        _klayGetTransactionReceiptPollingRequest = new klayGetTransactionReceiptPollingRequest(url);
    }
    public async Task<KlayTransactionReceipt> token_transfer(int cycleCount = 0)
    {
        Function _fnTransferFunction = _contract.GetFunction("transfer");
        TransactionInput _transactionInput = _fnTransferFunction.CreateTransactionInput(_fromAddress, _toAddress, UnitConversion.Convert.ToWei(Value));
        await _smartContractTransactionSignedReqeust.SendAndSignedRequest(_transactionInput);
        await _klayGetTransactionReceiptPollingRequest.PollForReceipt(_smartContractTransactionSignedReqeust.Result, 2.0f);
        return _klayGetTransactionReceiptPollingRequest.Result;
    }
}