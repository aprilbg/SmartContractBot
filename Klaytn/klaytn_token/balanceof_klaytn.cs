using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Util;
using SmartContract.Klaytn.JsonRpc.UnityClient;

public class BalanceOf_Token_Klaytn
{
    private Contract _contract;
    Nethereum.Web3.Web3 web3;
    Nethereum.RPC.Eth.Transactions.EthCall _balanceOfToken = null!;
    private KlayCallRequest _klaycallRequest;
    string _fromAddress;
    public BalanceOf_Token_Klaytn(string abi, string contractAddress, string fromAddress, string url)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        web3 = new Nethereum.Web3.Web3(url);
        _balanceOfToken = new Nethereum.RPC.Eth.Transactions.EthCall(web3.Client);
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