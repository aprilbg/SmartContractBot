public class Dummy_Four
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_four = new klaytn_bot(eKlaytnType.four);

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
                bot_four.BalanceOfInfo();
                bot_four.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}