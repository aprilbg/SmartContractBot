public class Dummy_NFT_four
{
    private System.Threading.Thread? mainThread = null;
    private nft_bot bot = new nft_bot(eNFTType.four);

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
                bot.GetNftInfo();
                bot.SafeTransfer_DO();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            System.Threading.Thread.Sleep(1);
        }
    }
}