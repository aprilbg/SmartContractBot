public enum eEthereumType { ETH, SSD, RAM, HARD, SOFT, }
public class ethereum_bot
{
    private EthereumBotsDo _ethereumBotsDo;
    private eEthereumType _type;
    public ethereum_bot(eEthereumType type)
    {
        _type = type;
        _ethereumBotsDo = new EthereumBotsDo(_type);
    }
    public void BalanceOfInfo()
    {
        _ethereumBotsDo.GetInfo();
    }
    public void Transfer_Do()
    {
        _ethereumBotsDo.Transfer();
    }
}