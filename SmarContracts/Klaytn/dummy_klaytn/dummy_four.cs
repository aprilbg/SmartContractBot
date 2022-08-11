public class Dummy_Four
{
    private System.Threading.Thread? mainThread = null;
    private Bot_four bot_four = new Bot_four();

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
                bot_four.Balance_DO();
                bot_four.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}