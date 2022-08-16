public class Dummy_Three
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_three = new klaytn_bot(eKlaytnType.three);

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
                bot_three.BalanceOfInfo();
                bot_three.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}