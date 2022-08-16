public class Dummy_Eight
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_eight = new klaytn_bot(eKlaytnType.eight);

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
                bot_eight.BalanceOfInfo();
                bot_eight.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}