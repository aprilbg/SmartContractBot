public class Dummy_Matic
{
    private System.Threading.Thread? mainThread = null;
    private Bot_Matic bot_matic = new Bot_Matic();

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
                bot_matic.Balance_DO();
                bot_matic.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}