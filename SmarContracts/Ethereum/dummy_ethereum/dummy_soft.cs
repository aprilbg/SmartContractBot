public class Dummy_SOFT
{
    private System.Threading.Thread? mainThread = null;
    private ethereum_bot bot_soft = new ethereum_bot(eEthereumType.SOFT);

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
                bot_soft.BalanceOfInfo();
                bot_soft.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}