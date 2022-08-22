public enum eKlaytnType { one, two, three, four, five, six, seven, eight, }
public class klaytn_bot
{
    private KlaytnBotsDo _klaytnBotsDo;
    private eKlaytnType _type;
    public klaytn_bot(eKlaytnType type)
    {
        _type = type;
        _klaytnBotsDo = new KlaytnBotsDo(_type);
    }
    public void BalanceOfInfo()
    {
        _klaytnBotsDo.GetInfo();
    }
    public void Transfer_Do()
    {
        _klaytnBotsDo.Transfer();
    }
    public void Save()
    {
        _klaytnBotsDo.Save();
    }
}