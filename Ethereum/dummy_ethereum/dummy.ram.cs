public class Dummy_RAM
{
    private System.Threading.Thread? mainThread = null;
    private Bot_RAM bot_ram = new Bot_RAM();

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
                bot_ram.Balance_DO();
                bot_ram.Transfer_Do();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}