using Nethereum.Hex.HexTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartContract.Klaytn
{
    public class KlayTransactionReceipt
    {
        [JsonProperty(PropertyName = "transactionHash")]
        public string? TransactionHash { get; set; }

        [JsonProperty(PropertyName = "blockNumber")]
        public HexBigInteger? BlockNumber { get; set; }

        [JsonProperty(PropertyName = "blockHash")]
        public string? BlockHash { get; set; }

        [JsonProperty(PropertyName = "status")]
        public HexBigInteger? Status { get; set; }

        [JsonProperty(PropertyName = "contractAddress")]
        public string? ContractAddress { get; set; }

        [JsonProperty(PropertyName = "logs")]
        public JArray? Logs { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }
    }
}
