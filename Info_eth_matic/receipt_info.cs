using Nethereum.Hex.HexTypes;
using Newtonsoft.Json.Linq;

namespace Receiptinfo;
public class Receiptinfo
{
    public string To { get; set; } = null!;
    public JArray Logs { get; set; } = null!;
    public string ContractAddress { get; set; } = null!;
    public string From { get; set; } = null!;
    public HexBigInteger BlockNumber { get; set; } = null!;
    public HexBigInteger TransactionIndex { get; set; } = null!;
    public string TransactionHash { get; set; } = null!;
}

public class ReceiptLog
{
    public string address { get; set; } = null!;
    public string blockHash { get; set; } = null!;
    public string blockNumber { get; set; } = null!;
    public string data { get; set; } = null!;
    public string logIndex { get; set; } = null!;
    public string transactionHash { get; set; } = null!;
    public string transactionIndex { get; set; } = null!;
}