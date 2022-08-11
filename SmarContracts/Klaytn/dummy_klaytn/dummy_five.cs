public class Dummy_Five
{
    private System.Threading.Thread? mainThread = null;
    private Bot_five bot_five = new Bot_five();

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
                bot_five.Balance_DO();
                bot_five.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}