public class Dummy_Six
{
    private System.Threading.Thread? mainThread = null;
    private Bot_six bot_six = new Bot_six();

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
                bot_six.Balance_DO();
                bot_six.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}