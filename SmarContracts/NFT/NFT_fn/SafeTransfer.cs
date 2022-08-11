using SmartContract.Klaytn.JsonRpc.UnityClient;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.RPC;
using SmartContract.Klaytn;
using System.Numerics;

class Transfer_NFT
{
    public Contract _contract;
    private KlkaytnSmartContractTransactionSignedRequest _smartContractTransactionSignedReqeust;
    private klayGetTransactionReceiptPollingRequest _klayGetTransactionReceiptPollingRequest;
    string _fromAddress;
    string _toAddress;
    BigInteger _tokenId;
    public Transfer_NFT(string abi, string contractAddress, string fromAddress ,string toAddress, string privateKey, string url, BigInteger token_id)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _toAddress = toAddress;
        _tokenId = token_id;
        _smartContractTransactionSignedReqeust = new KlkaytnSmartContractTransactionSignedRequest(url, fromAddress, privateKey, 1001);
        _klayGetTransactionReceiptPollingRequest = new klayGetTransactionReceiptPollingRequest(url);
    }
    public async Task<KlayTransactionReceipt> nft_transfer()
    {
        Function _fnTransferFunction = _contract.GetFunction("safeTransferFrom");
        TransactionInput _transactionInput = _fnTransferFunction.CreateTransactionInput(_fromAddress, _fromAddress, _toAddress, _tokenId);
        await _smartContractTransactionSignedReqeust.SendAndSignedRequest(_transactionInput);
        if(_smartContractTransactionSignedReqeust.Result == null)
        {
            return null;
        }
        await _klayGetTransactionReceiptPollingRequest.PollForReceipt(_smartContractTransactionSignedReqeust.Result, 2.0f);
        return _klayGetTransactionReceiptPollingRequest.Result;
    }

}