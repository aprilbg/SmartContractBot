public class Dummy_Matic
{
    private System.Threading.Thread? mainThread = null;
    private matic_bot bot_matic = new matic_bot(eMaticType.matic);

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
                bot_matic.BalanceOfInfo();
                bot_matic.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}