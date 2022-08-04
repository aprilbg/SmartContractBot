public class Dummy_Two
{
    private System.Threading.Thread? mainThread = null;
    private Bot_two bot_two = new Bot_two();

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
                bot_two.Balance_DO();
                bot_two.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}