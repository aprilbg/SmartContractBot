using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Util;
using SmartContract.Klaytn.JsonRpc.UnityClient;

public class BalanceOf_Token_Klaytn
{
    private Contract _contract;
    private KlayCallRequest _klaycallRequest;
    string _fromAddress;
    public BalanceOf_Token_Klaytn(string abi, string contractAddress, string fromAddress, string url)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _klaycallRequest = new KlayCallRequest(url);
    }
    public async Task<decimal> token_balance()
    {
        Function _fnBalanceOfFunction = _contract.GetFunction("balanceOfToken");
        CallInput balanceinput = _fnBalanceOfFunction.CreateCallInput(_fromAddress);
        await _klaycallRequest.SendRequest(balanceinput, BlockParameter.CreateLatest());
        BigInteger token = _fnBalanceOfFunction.DecodeTypeOutput<BigInteger>(_klaycallRequest.Result);
        decimal tokenbalance = UnitConversion.Convert.FromWei(token);
        return tokenbalance;
    }

}