public class Dummy_Seven
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_seven = new klaytn_bot(eKlaytnType.seven);

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
                bot_seven.BalanceOfInfo();
                bot_seven.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}