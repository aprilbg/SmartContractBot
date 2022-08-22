public enum eNFTType { one, two, three, four, }

public class nft_bot
{
    private NftOwnBehavior _ownBehavior;
    private NftOtherBehavior _otherBehavior;
    private eNFTType _type;
    public nft_bot(eNFTType type)
    {
        _type = type;
        _ownBehavior = new NftOwnBehavior(_type);
        _otherBehavior = new NftOtherBehavior(_type);
    }


    public void GetNftInfo()
    {
        _ownBehavior.GetInfo();
        _otherBehavior.GetInfo();
    }

    public void SafeTransfer_DO()
    {
        _ownBehavior.SafeTransfer();
        _otherBehavior.SafeTransfer();
    }
    public void Save()
    {
        _ownBehavior.Save();
        _otherBehavior.Save();
    }
}
