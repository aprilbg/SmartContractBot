using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Util;
public class BalanceOf_Token_ETH 
{
    private Contract _contract;
    Nethereum.Web3.Web3 web3;
    Nethereum.RPC.Eth.Transactions.EthCall _balanceOfToken = null!;
    string _fromAddress;
    public BalanceOf_Token_ETH(string abi, string contractAddress, string fromAddress, string url)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        web3 = new Nethereum.Web3.Web3(url);
        _balanceOfToken = new Nethereum.RPC.Eth.Transactions.EthCall(web3.Client);
    }
    public async Task<decimal> token_balance()
    {
        Function _fnBalanceOfFunction = _contract.GetFunction("balanceOfToken");
        CallInput _callinput = _fnBalanceOfFunction.CreateCallInput(_fromAddress);
        string output;       
        output = await _balanceOfToken.SendRequestAsync(_callinput, BlockParameter.CreateLatest());
        BigInteger token = _fnBalanceOfFunction.DecodeTypeOutput<BigInteger>(output);
        decimal _totalTokenCount = UnitConversion.Convert.FromWei(token);
        return _totalTokenCount;
    }
}