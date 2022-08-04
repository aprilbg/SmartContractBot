Console.WriteLine($"args length:{args.Length}");

Dictionary<string, IActor> dicActor = new Dictionary<string, IActor>();

foreach (var arg in args)
{
    if (false == dicActor.ContainsKey(arg))
    {
        if (arg == "eth") dicActor.Add(arg, new EthActor());
        else if (arg == "matic") dicActor.Add(arg, new MaticActor());
        else if (arg == "klaytn") dicActor.Add(arg, new KlaytnActor());
    }
}

foreach (var actor in dicActor)
{
    actor.Value.Do();
}