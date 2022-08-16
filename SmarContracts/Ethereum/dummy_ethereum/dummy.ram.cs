public class Dummy_RAM
{
    private System.Threading.Thread? mainThread = null;
    private ethereum_bot bot_ram = new ethereum_bot(eEthereumType.RAM);

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
                bot_ram.BalanceOfInfo();
                bot_ram.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}