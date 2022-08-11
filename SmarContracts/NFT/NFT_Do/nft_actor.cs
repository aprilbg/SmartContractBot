class NFTactor : IActor
{
    public void Do()
    {
        Console.WriteLine("NFT DO");
        {
            var dummy = new Dummy_NFT_one();
            dummy.Start();
        }

        {
            var dummy = new Dummy_NFT_two();
            dummy.Start();
        }

        {
            var dummy = new Dummy_NFT_three();
            dummy.Start();
        }
        
        {
            var dummy = new Dummy_NFT_four();
            dummy.Start();
        }
    }
}