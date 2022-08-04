using Nethereum.Hex.HexTypes;
using Newtonsoft.Json;

namespace SmartContract.Klaytn
{
    public class KlayFilterLog
    {
        [JsonProperty(PropertyName = "removed")]
        public bool removed { get; set; }

        [JsonProperty(PropertyName = "logIndex")]
        public HexBigInteger? log_index { get; set; }

        [JsonProperty(PropertyName = "transactionIndex")]
        public HexBigInteger? transaction_index { get; set; }

        [JsonProperty(PropertyName = "transactionHash")]
        public string? transaction_hash { get; set; }

        [JsonProperty(PropertyName = "blockHash")]
        public string? block_hash { get; set; }

        [JsonProperty(PropertyName = "blockNumber")]
        public HexBigInteger? block_number { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string? address { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string? data { get; set; }

        [JsonProperty(PropertyName = "topics")]
        public object[]? topic { get; set; }
    }
}
