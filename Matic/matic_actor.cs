class MaticActor : IActor
{
    public void Do()
    {
        Console.WriteLine("MaticActor Do");
        {
            var dummy = new Dummy_Matic();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Apple();
            dummy.Start();
        }

        {
            var dummy = new Dummy_Ham();
            dummy.Start();
        }
    }
}