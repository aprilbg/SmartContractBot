public class Dummy_Apple
{
    private System.Threading.Thread? mainThread = null;
    private matic_bot bot_apple = new matic_bot(eMaticType.apple);

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
                bot_apple.BalanceOfInfo();
                bot_apple.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}