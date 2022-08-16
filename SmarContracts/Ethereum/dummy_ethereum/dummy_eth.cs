public class Dummy_ETH
{
    private System.Threading.Thread? mainThread = null;
    private ethereum_bot bot_ETH = new ethereum_bot(eEthereumType.ETH);

    public void Start()
    {
        if(null == mainThread)
        {
            mainThread = new System.Threading.Thread(MainLoop);
        }
        mainThread.Start();
    }

    protected void MainLoop()
    {
        while (true)
        {
            try
            {
                bot_ETH.BalanceOfInfo();
                bot_ETH.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}