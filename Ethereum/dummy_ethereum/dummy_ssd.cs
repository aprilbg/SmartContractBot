public class Dummy_SSD
{
    private System.Threading.Thread? mainThread = null;
    private Bot_SSD bot_ssd = new Bot_SSD();

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
                bot_ssd.Balance_DO();
                bot_ssd.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}