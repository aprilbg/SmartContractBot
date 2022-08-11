public class Dummy_Ham
{
    private System.Threading.Thread? mainThread = null;
    private Bot_Ham bot_ham = new Bot_Ham();

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
                bot_ham.Balance_DO();
                bot_ham.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}