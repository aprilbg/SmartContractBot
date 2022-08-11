public class Dummy_Apple
{
    private System.Threading.Thread? mainThread = null;
    private Bot_Apple bot_apple = new Bot_Apple();

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
                bot_apple.Balance_DO();
                bot_apple.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}