public class Dummy_One
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_one = new klaytn_bot(eKlaytnType.one);

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
                bot_one.BalanceOfInfo();
                bot_one.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}