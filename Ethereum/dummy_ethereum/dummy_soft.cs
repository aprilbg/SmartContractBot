public class Dummy_SOFT
{
    private System.Threading.Thread? mainThread = null;
    private Bot_SOFT bot_soft = new Bot_SOFT();

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
                bot_soft.Balance_DO();
                bot_soft.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}