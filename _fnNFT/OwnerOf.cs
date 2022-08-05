using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using SmartContract.Klaytn.JsonRpc.UnityClient;
class OwnerOfOf_NFT
{
    private Contract _contract;
    private KlayCallRequest _klaycallRequest;
    string _fromAddress;
    public OwnerOfOf_NFT(string abi, string contractAddress, string fromAddress, string url)
    {
        _contract = new Contract(null, abi, contractAddress);
        _fromAddress = fromAddress;
        _klaycallRequest = new KlayCallRequest(url);
    }
    public async Task<string> nft_ownerof(BigInteger tokenId)
    {
        Function _fnownerOfFunction = _contract.GetFunction("ownerOf");
        CallInput owner_input = _fnownerOfFunction.CreateCallInput(tokenId);
        await _klaycallRequest.SendRequest(owner_input, BlockParameter.CreateLatest());
        string _owner = _klaycallRequest.Result;
        string new_owner = _owner.Remove(2,24);
        return new_owner;
    }
}