public class Dummy_NFT
{
    private System.Threading.Thread? mainThread = null;
    private Bot_nft bot_nft = new Bot_nft();

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
                bot_nft.Balance_DO();
                bot_nft.SafeTransfer_DO();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}