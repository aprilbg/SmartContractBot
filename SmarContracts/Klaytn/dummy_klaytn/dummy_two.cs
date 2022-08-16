public class Dummy_Two
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot_two = new klaytn_bot(eKlaytnType.two);

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
                bot_two.BalanceOfInfo();
                bot_two.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}