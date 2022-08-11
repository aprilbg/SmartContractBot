class KlaytnActor : IActor
{
    public void Do()
    {
        Console.WriteLine("KlaytnActor Do");
        {
            var dummy = new Dummy_One();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Two();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Three();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Four();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Five();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Six();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Seven();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Eight();
            dummy.Start();
        }
    }
}