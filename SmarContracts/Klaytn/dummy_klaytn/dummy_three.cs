public class Dummy_Three
{
    private System.Threading.Thread? mainThread = null;
    private Bot_three bot_three = new Bot_three();

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
                bot_three.Balance_DO();
                bot_three.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}