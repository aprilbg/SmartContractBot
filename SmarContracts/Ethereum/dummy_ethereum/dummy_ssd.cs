public class Dummy_SSD
{
    private System.Threading.Thread? mainThread = null;
    private ethereum_bot bot_ssd = new ethereum_bot(eEthereumType.SSD);

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
                bot_ssd.BalanceOfInfo();
                bot_ssd.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}