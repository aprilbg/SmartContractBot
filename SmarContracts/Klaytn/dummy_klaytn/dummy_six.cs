public class Dummy_Six
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_six = new klaytn_bot(eKlaytnType.six);

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
                bot_six.BalanceOfInfo();
                bot_six.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}