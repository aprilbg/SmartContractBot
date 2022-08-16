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
    public async Task<List<BigInteger>> nft_tokenid()
    {
        Function _fnBalanceOfFunction = _contract.GetFunction("_tokensOfOwner");
        CallInput balance_input = _fnBalanceOfFunction.CreateCallInput(_fromAddress);
        await _klaycallRequest.SendRequest(balance_input, BlockParameter.CreateLatest());
        var rm_prefix = _klaycallRequest.Result.Replace("0x", "");
        var rm_data = rm_prefix.Remove(0, 128);
        var length = rm_data.Length / 64;

        string[] arrStr = new string[length];
        var tokenIds = new List<BigInteger>();
        for (int i = 0; i < length; ++i)
        {
            arrStr[i] = rm_data.Substring(i * 64, 64);
            var value = BigInteger.Parse(arrStr[i], System.Globalization.NumberStyles.HexNumber);
            if (value != 0) tokenIds.Add(value);
        }
        return tokenIds;
    }
}