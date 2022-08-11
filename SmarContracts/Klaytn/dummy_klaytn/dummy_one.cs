public class Dummy_One
{
    private System.Threading.Thread? mainThread = null;
    private Bot_one bot_one = new Bot_one();

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
                bot_one.Balance_DO();
                bot_one.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}