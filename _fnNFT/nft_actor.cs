class NFTactor : IActor
{
    public void Do()
    {
        Console.WriteLine("NFT DO");
        {
            var dummy = new Dummy_NFT();
            dummy.Start();
        }
    }
}