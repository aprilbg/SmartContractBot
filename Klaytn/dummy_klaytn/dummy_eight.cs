public class Dummy_Eight
{
    private System.Threading.Thread? mainThread = null;
    private Bot_eight bot_eight = new Bot_eight();

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
                bot_eight.Balance_DO();
                bot_eight.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}