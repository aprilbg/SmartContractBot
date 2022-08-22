public enum eMaticType { apple, ham, matic,}
public class matic_bot
{
    private MaticBotsDo _maticBotsDo;
    private eMaticType _type;
    public matic_bot(eMaticType type)
    {
        _type = type;
        _maticBotsDo = new MaticBotsDo(_type);
    }
    public void BalanceOfInfo()
    {
        _maticBotsDo.GetInfo();
    }
    public void Transfer_Do()
    {
        _maticBotsDo.Transfer();
    }
    public void Save()
    {
        _maticBotsDo.Save();
    }
}