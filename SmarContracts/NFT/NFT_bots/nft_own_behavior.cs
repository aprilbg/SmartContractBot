using System.Numerics;
using Receiptinfo;
using SmartContract.Klaytn;

public class NftOwnBehavior
{
    private eNFTType _type;
    private Dictionary<eNFTType, KlayTransactionReceipt> _listReceipt = new Dictionary<eNFTType, KlayTransactionReceipt>();
    private SmartContract.NFT.Setup_account.NFT_setup basic_setup = new SmartContract.NFT.Setup_account.NFT_setup();
    private Dictionary<eNFTType, SmartContract.NFT.Setup_account.NFT_setup> _dicNfts = new Dictionary<eNFTType, SmartContract.NFT.Setup_account.NFT_setup>();
    private Dictionary<eNFTType, List<BigInteger>> _dicHasList = new Dictionary<eNFTType, List<BigInteger>>();
    public int wholeCount = 0;
    public NftOwnBehavior(eNFTType type)
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
            var rt_one_id = Task.Run(async () => await new BalanceOf_NFT(basic_setup.abi,
                                                                        owner._contractAddress,
                                                                        nft.Value._managerAddress,
                                                                        basic_setup._url).nft_tokenid());
            rt_one_id.Wait();
            _dicHasList.Add(nft.Key, rt_one_id.Result);
            foreach (var item in rt_one_id.Result)
            {
                Console.WriteLine($"Owner is : {_type.ToString()} | Owner NFT Id is : {item} | Hold Manager is : {nft.Key}");
            }
        }
    }

    public void SafeTransfer()
    {
        if (false == _dicNfts.ContainsKey(_type)) throw new Exception("");
        if (false == _dicHasList.ContainsKey(_type)) throw new Exception("");

        var owner = _dicNfts[_type];

        List<BigInteger> rest_id = new List<BigInteger>();
        if (null != _dicHasList[_type]) rest_id = _dicHasList[_type];
        if (rest_id.Count <= 0) return;

        List<eNFTType> none_list = new List<eNFTType>();

        foreach (var key_val in _dicHasList)
        {
            if (key_val.Key == _type) continue;
            if (key_val.Value.Count == 0)
            {
                none_list.Add(key_val.Key);
            }
        }

        List<BigInteger> copy_rest_ids = new List<BigInteger>();
        foreach (var id in rest_id)
            copy_rest_ids.Add(id);

        foreach (var none_manager in none_list)
        {
            var none_id_info = _dicNfts[none_manager];
            BigInteger? success_id = null;
            foreach (var id in copy_rest_ids)
            {
                var sf_none_manager = Task.Run(async () => await new Transfer_NFT(basic_setup.abi,
                                                                          owner._contractAddress,
                                                                          owner._managerAddress,
                                                                          none_id_info._managerAddress,
                                                                          owner._privateKey,
                                                                          basic_setup._url,
                                                                          id
                                                                          ).nft_transfer());
                sf_none_manager.Wait();
                if (sf_none_manager != null)
                {
                    var rt = sf_none_manager.Result;
                    Console.WriteLine($"Call : {this._type.ToString()} | To : {none_manager.ToString()} | hash : {rt.TransactionHash}");
                    success_id = id;
                    _listReceipt.Add(_type, rt);
                    break;
                }
            }
            if (null != success_id) copy_rest_ids.Remove((BigInteger)success_id);
        }

        if (copy_rest_ids.Count > 0)
        {
            List<eNFTType> ranList = new List<eNFTType>();
            foreach (var node in Enum.GetValues(typeof(eNFTType)))
            {
                if (_type == (eNFTType)node) continue;
                ranList.Add((eNFTType)node);
            }

            foreach (var copy_rest_id in copy_rest_ids)
            {
                var ran = new Random();
                var selectedIndex = ran.Next(0, ranList.Count);
                var selectedNftType = ranList[selectedIndex];

                var selectedNft = _dicNfts[selectedNftType];

                var sf_none_manager = Task.Run(async () => await new Transfer_NFT(basic_setup.abi,
                                                                          owner._contractAddress,
                                                                          owner._managerAddress,
                                                                          selectedNft._managerAddress,
                                                                          owner._privateKey,
                                                                          basic_setup._url,
                                                                          copy_rest_id
                                                                          ).nft_transfer());
                sf_none_manager.Wait();
                if (sf_none_manager != null)
                {
                    var rt = sf_none_manager.Result;
                    Console.WriteLine($"{this._type.ToString()} hash : {rt.TransactionHash}");
                    ranList.RemoveAt(selectedIndex);
                    _listReceipt.Add(_type, rt);
                }
            }
        }
    }
    public void Save()
    {
        ++wholeCount;
        if (wholeCount > 1)
        {
            _listReceipt.Clear();
        }
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