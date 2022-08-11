public class Dummy_ETH
{
    private System.Threading.Thread? mainThread = null;
    private Bot_ETH bot_ETH = new Bot_ETH();

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
                bot_ETH.Balance_DO();
                bot_ETH.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}