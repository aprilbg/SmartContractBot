public class Dummy_Ham
{
    private System.Threading.Thread? mainThread = null;
    private matic_bot bot_ham = new matic_bot(eMaticType.ham);

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
                bot_ham.BalanceOfInfo();
                bot_ham.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}