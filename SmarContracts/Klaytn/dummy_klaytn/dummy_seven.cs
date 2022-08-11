public class Dummy_Seven
{
    private System.Threading.Thread? mainThread = null;
    private Bot_seven bot_seven = new Bot_seven();

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
                bot_seven.Balance_DO();
                bot_seven.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}