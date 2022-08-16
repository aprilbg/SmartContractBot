public class Dummy_Five
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_five = new klaytn_bot(eKlaytnType.five);

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
                bot_five.BalanceOfInfo();
                bot_five.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}