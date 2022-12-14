using System.Numerics;
using Receiptinfo;
using SmartContract.Klaytn;

public class NftOtherBehavior
{
    private eNFTType _type;
    private Dictionary<eNFTType, KlayTransactionReceipt> _listReceipt = new Dictionary<eNFTType, KlayTransactionReceipt>();
    private SmartContract.NFT.Setup_account.NFT_setup basic_setup = new SmartContract.NFT.Setup_account.NFT_setup();
    private Dictionary<eNFTType, SmartContract.NFT.Setup_account.NFT_setup> _dicNfts = new Dictionary<eNFTType, SmartContract.NFT.Setup_account.NFT_setup>();
    private Dictionary<eNFTType, List<BigInteger>> _dicHasList = new Dictionary<eNFTType, List<BigInteger>>();
    public NftOtherBehavior(eNFTType type)
    {
        _type = type;
        _dicNfts.Add(eNFTType.one, new SmartContract.NFT.Setup_account.nft_one());
        _dicNfts.Add(eNFTType.two, new SmartContract.NFT.Setup_account.nft_two());
        _dicNfts.Add(eNFTType.three, new SmartContract.NFT.Setup_account.nft_three());
        _dicNfts.Add(eNFTType.four, new SmartContract.NFT.Setup_account.nft_four());
    }

    public void GetInfo()
    {
        _dicHasList.Clear();
        if (false == _dicNfts.ContainsKey(_type)) throw new Exception("");
        var owner = _dicNfts[_type];

        foreach (var nft in _dicNfts)
        {
            if (nft.Key == _type) continue;

            var rt_one_id = Task.Run(async () => await new BalanceOf_NFT(basic_setup.abi,
                                                                        nft.Value._contractAddress,
                                                                        owner._managerAddress,
                                                                        basic_setup._url).nft_tokenid());
            rt_one_id.Wait();
            _dicHasList.Add(nft.Key, rt_one_id.Result);
            foreach (var item in rt_one_id.Result)
            {
                Console.WriteLine($"Contract : {nft.Key.ToString()} | Owner is : {_type.ToString()} | Owner NFT Id is : {item} | Hold Manager is : {nft.Key}");
            }
        }
    }

    public void SafeTransfer()
    {
        _listReceipt.Clear();
        if (false == _dicNfts.ContainsKey(_type)) throw new Exception("");
        var owner = _dicNfts[_type];

        foreach (var nft in _dicNfts)
        {
            if (false == _dicHasList.ContainsKey(nft.Key)) continue;
            var hasList = _dicHasList[nft.Key];
            foreach (var id in hasList)
            {
                var sf_none_manager = Task.Run(async () => await new Transfer_NFT(basic_setup.abi,
                                                                           nft.Value._contractAddress,
                                                                           owner._managerAddress,
                                                                           nft.Value._managerAddress,
                                                                           owner._privateKey,
                                                                           basic_setup._url,
                                                                           id
                                                                           ).nft_transfer());
                sf_none_manager.Wait();
                if (sf_none_manager != null)
                {
                    var rt = sf_none_manager.Result;
                    Console.WriteLine($"go back to {this._type.ToString()} hash : {rt.TransactionHash}");
                    _listReceipt.Add(nft.Key, rt);
                }
            }

        }
    }
    public void Save()
    {
        foreach (var Receipt in _listReceipt)
        {
            if (Receipt.Value.Logs != null)
            {
                foreach (var logs in Receipt.Value.Logs)
                {
                    var objLog = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptLog>(logs.ToString());
                    if (objLog == null) continue;
                    using (var db = new Transaction_DB_nft())
                    {
                        db.transaction_data.Add(new Transaction_Logs
                        {
                            CallHashFrom = _type.ToString(),
                            transactionHash = objLog.transactionHash,
                            address = objLog.address,
                            blockHash = objLog.blockHash,
                            blockNumber = objLog.blockNumber,
                            data = objLog.data,
                            logIndex = objLog.logIndex,
                            transactionIndex = objLog.transactionIndex
                        });
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}