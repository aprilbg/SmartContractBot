using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using SmartContract.Klaytn.JsonRpc.UnityClient;
class BalanceOf_NFT
{
    private Contract _contract;
    private KlayCallRequest _klaycallRequest;
    string _fromAddress;
    public BalanceOf_NFT(string abi, string contractAddress, string fromAddress, string url)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _klaycallRequest = new KlayCallRequest(url);
    }
    public async Task<BigInteger> nft_tokenid()
    {
        Function _fnBalanceOfFunction = _contract.GetFunction("balanceOf");
        CallInput balance_input = _fnBalanceOfFunction.CreateCallInput(_fromAddress);
        await _klaycallRequest.SendRequest(balance_input, BlockParameter.CreateLatest());
        BigInteger tokenId = _fnBalanceOfFunction.DecodeTypeOutput<BigInteger>(_klaycallRequest.Result);
        return tokenId;
    }
}