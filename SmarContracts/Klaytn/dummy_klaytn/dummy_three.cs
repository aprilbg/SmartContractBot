public class Dummy_Three
{
    private System.Threading.Thread? mainThread = null;
    private klaytn_bot bot = new klaytn_bot(eKlaytnType.three);

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
                bot.BalanceOfInfo();
                bot.Transfer_Do();
                bot.Save();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}