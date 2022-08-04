class EthActor : IActor
{
    public void Do()
    {
        Console.WriteLine("EthActor Do");
        {
            var dummy = new Dummy_ETH();
            dummy.Start();
        }

        {
            var dummy = new Dummy_SSD();
            dummy.Start();
        }

        {
            var dummy = new Dummy_RAM();
            dummy.Start();
        }

        {
            var dummy = new Dummy_HARD();
            dummy.Start();
        }

        {
            var dummy = new Dummy_SOFT();
            dummy.Start();
        }

    }
}