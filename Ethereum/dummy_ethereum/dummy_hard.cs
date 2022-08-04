public class Dummy_HARD
{
    private System.Threading.Thread? mainThread = null;
    private Bot_HARD bot_hard = new Bot_HARD();

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
                bot_hard.Balance_DO();
                bot_hard.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}