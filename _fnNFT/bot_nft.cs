using System.Numerics;
using Nethereum.Util;
using SmartContract.Klaytn;
public class Bot_nft
{
    BigInteger token_id;
    string? _owner;
    KlayTransactionReceipt info = new KlayTransactionReceipt();
    private SmartContract.NFT.Setup.NFT_token_setup setup_nft = new SmartContract.NFT.Setup.NFT_token_setup();
    public void Balance_DO()
    {
        var rt_id = Task.Run(async () => await new BalanceOf_NFT(setup_nft.abi,
                                                                  setup_nft._contractAddress,
                                                                  setup_nft._fromAddress,
                                                                  setup_nft._url).nft_tokenid());
        rt_id.Wait();
        token_id = rt_id.Result;
        var rt_own = Task.Run(async () => await new OwnerOfOf_NFT(setup_nft.abi,
                                                                  setup_nft._contractAddress,
                                                                  setup_nft._fromAddress,
                                                                  setup_nft._url).nft_ownerof(token_id));
        rt_own.Wait();
        _owner = rt_own.Result;
        Console.WriteLine($"\n TokenId : {token_id}\n TokenOwner = {_owner}");
    }
    public void SafeTransfer_DO()
    {
        var rt_nft = Task.Run(async () =>
        {
            await new Transfer_NFT(setup_nft.abi,
                                   setup_nft._contractAddress,
                                   setup_nft._fromAddress,
                                   setup_nft._toAddress,
                                   setup_nft._privateKey,
                                   setup_nft._url,
                                   token_id).nft_transfer();
            return;
        });
        rt_nft.Wait();
    }
}