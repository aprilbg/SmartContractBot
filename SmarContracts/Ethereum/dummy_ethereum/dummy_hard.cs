public class Dummy_HARD
{
    private System.Threading.Thread? mainThread = null;
    private ethereum_bot bot_hard = new ethereum_bot(eEthereumType.HARD);

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
                bot_hard.BalanceOfInfo();
                bot_hard.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}