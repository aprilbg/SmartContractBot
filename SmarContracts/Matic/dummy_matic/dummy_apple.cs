public class Dummy_Apple
{
    private System.Threading.Thread? mainThread = null;
    private matic_bot bot = new matic_bot(eMaticType.apple);

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
                bot.BalanceOfInfo();
                bot.Transfer_Do();
                bot.Save();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}