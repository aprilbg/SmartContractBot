using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System.Collections;
using System.Threading.Tasks;

namespace SmartContract.Klaytn.JsonRpc.UnityClient
{

    enum ApiMethods
    {
        klay_blockNumber,
        klay_syncing,
        klay_call,
        klay_estimateGas,
        klay_getTransactionCount,
        klay_getTransactionReceipt,
        klay_sendRawTransaction,
        klay_gasPrice,
        klay_getLogs,
        klay_getFilterLogs,
        klay_newFilter,
        klay_uninstallFilter,
    }

    public class RpcRequestBuilder
    {
        public RpcRequestBuilder(string methodname)
        {
            this.methodname = methodname;
        }

        public string methodname { get; }

        public virtual RpcRequest BuildRequest(object id, params object[] paramList)
        {
            if (id == null) id = 1;
            return new RpcRequest(id, methodname, paramList);
        }

        public virtual RpcRequest BuildRequest(object id = null)
        {
            if (id == null) id = 1;
            return new RpcRequest(id, methodname);
        }
    };

    /*
     * KlayBlockNumber
     */
    public class KlayBlockNumber : RpcRequestBuilder
    {
        public KlayBlockNumber() : base(ApiMethods.klay_blockNumber.ToString())
        {
        }
    };

    public class KlayBlockNumberReqeust : KlaytnRpcClient<System.String>
    {
        private readonly KlayBlockNumber _klayblocknumber;

        public KlayBlockNumberReqeust(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klayblocknumber = new KlayBlockNumber();
        }

        public IEnumerator SendRequest(object id = null)
        {
            var RpcRequest = _klayblocknumber.BuildRequest(id);
            yield return base.SendRequest(RpcRequest);
        }
    }

    /*
     * klayGetTransactionReceipt
     */
    public class klayGetTransactionReceipt : RpcRequestBuilder
    {
        public klayGetTransactionReceipt() : base(ApiMethods.klay_getTransactionReceipt.ToString())
        {
        }

        public RpcRequest BuildRequest(string transactionhash, object id = null)
        {
            return base.BuildRequest(id, transactionhash);
        }
    }

    public class KlayGetTransactionReceiptRequest : KlaytnRpcClient<KlayTransactionReceipt>
    {
        private readonly klayGetTransactionReceipt _klaytnGetTransactionReceipt;

        public KlayGetTransactionReceiptRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaytnGetTransactionReceipt = new klayGetTransactionReceipt();
        }

        public Task SendRequest(string transactionhash, object id = null)
        {
            var RpcRequest = _klaytnGetTransactionReceipt.BuildRequest(transactionhash.EnsureHexPrefix(), id);
            return base.SendRequest(RpcRequest);
        }
    }

    /*
     * KlayGasPrice
     */
    public class KlayGasPrice : RpcRequestBuilder
    {
        public KlayGasPrice() : base(ApiMethods.klay_gasPrice.ToString())
        {
        }
    }

    public class KlayGasPriceReqeust : KlaytnRpcClient<HexBigInteger>
    {
        private KlayGasPrice _klayGasPrice;

        public KlayGasPriceReqeust(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klayGasPrice = new KlayGasPrice();
        }

        public Task SendRequest(object id = null)
        {
            var RpcReqeust = _klayGasPrice.BuildRequest(id);
            return base.SendRequest(RpcReqeust);
        }
    }

    /*
     * KlayEstimateGas
     */
    public class KlayEstimateGas : RpcRequestBuilder
    {
        public KlayEstimateGas() : base(ApiMethods.klay_estimateGas.ToString())
        {
        }

        public RpcRequest BuildRequest(CallInput callinput, object id = null)
        {
            var RpcRequest = base.BuildRequest(id, callinput);
            return RpcRequest;
        }
    }

    public class KlayEstimateGasReqeust : KlaytnRpcClient<HexBigInteger>
    {
        private readonly KlayEstimateGas _klayEstimateGas;

        public KlayEstimateGasReqeust(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klayEstimateGas = new KlayEstimateGas();
        }

        public Task SendRequest(CallInput callinput, object id = null)
        {
            var RpcRequerst = _klayEstimateGas.BuildRequest(callinput, id);
            return base.SendRequest(RpcRequerst);
        }
    }

    /*
     * KlayGetTransactionCount
     */
    public class KlayGetTransactionCount : RpcRequestBuilder
    {
        public KlayGetTransactionCount() : base(ApiMethods.klay_getTransactionCount.ToString())
        {
        }

        public RpcRequest BuildReqeust(string address, BlockParameter block, object id = null)
        {
            return base.BuildRequest(id, address, block);
        }
    }

    public class KlayGetTransactionCountReqeust : KlaytnRpcClient<HexBigInteger>
    {
        private readonly KlayGetTransactionCount _KlayGetTransactionCount;

        public KlayGetTransactionCountReqeust(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _KlayGetTransactionCount = new KlayGetTransactionCount();
        }

        public Task SendRequest(string address, object id = null)
        {
            var RpcReqest = _KlayGetTransactionCount.BuildReqeust(address.EnsureHexPrefix(), BlockParameter.CreateLatest(), id);
            return base.SendRequest(RpcReqest);
        }
    }

    /*
     * KlaySendRawTransaction
     */
    public class KlaySendRawTransaction : RpcRequestBuilder
    {
        public KlaySendRawTransaction() : base(ApiMethods.klay_sendRawTransaction.ToString())
        {
        }

        public RpcRequest BuildRequest(string raw, object id = null)
        {
            return base.BuildRequest(id, raw);
        }
    };

    public class KlaySendRawTransactionRequest : KlaytnRpcClient<System.String>
    {
        private readonly KlaySendRawTransaction _klaysendrawtransaction;

        public KlaySendRawTransactionRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaysendrawtransaction = new KlaySendRawTransaction();
        }

        public Task SendRequest(string raw, object id = null)
        {
            var RpcRequest = _klaysendrawtransaction.BuildRequest(raw.EnsureHexPrefix(), id);
            return base.SendRequest(RpcRequest);
        }
    }

    /*
     * klay call
     */
    public class KlayCall : RpcRequestBuilder
    {
        public KlayCall() : base(ApiMethods.klay_call.ToString())
        {
        }

        public RpcRequest BuildRequest(CallInput callinput, Nethereum.RPC.Eth.DTOs.BlockParameter block, object id = null)
        {
            return base.BuildRequest(id, callinput, block);
        }
    }

    public class KlayCallRequest : KlaytnRpcClient<System.String>
    {
        private readonly KlayCall _klaycall;

        public KlayCallRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaycall = new KlayCall();
        }

        public Task SendRequest(CallInput callinput, Nethereum.RPC.Eth.DTOs.BlockParameter block, object id = null)
        {
            var RpcRequest = _klaycall.BuildRequest(callinput, block, id);
            return base.SendRequest(RpcRequest);
        }
    }

    /*
     * 
     */
    public class KlayNewFilter : RpcRequestBuilder
    {
        public KlayNewFilter() : base(ApiMethods.klay_newFilter.ToString())
        {
        }

        public RpcRequest BuildRequest(Nethereum.RPC.Eth.DTOs.NewFilterInput new_filter_input, object id = null)
        {
            return base.BuildRequest(id, new_filter_input);
        }
    };

    public class KlayNewFilterReqeust : KlaytnRpcClient<HexBigInteger>
    {
        private readonly KlayNewFilter _klaynewfilter;

        public KlayNewFilterReqeust(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaynewfilter = new KlayNewFilter();
        }

        public Task SendRequest(Nethereum.RPC.Eth.DTOs.NewFilterInput new_filter_input, object id = null)
        {
            var RpcRequest = _klaynewfilter.BuildRequest(new_filter_input, id);
            return base.SendRequest(RpcRequest);
        }
    }

    /*
     * 
     */
    public class KlayUninstallFilter : RpcRequestBuilder
    {
        public KlayUninstallFilter() : base(ApiMethods.klay_uninstallFilter.ToString())
        {
        }

        public RpcRequest BuildRequest(HexBigInteger filter_id, object id = null)
        {
            return base.BuildRequest(id, filter_id);
        }
    }

    public class KlayUninstallFilterRequest : KlaytnRpcClient<bool>
    {
        private readonly KlayUninstallFilter _klayuninstallfilter;

        public KlayUninstallFilterRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klayuninstallfilter = new KlayUninstallFilter();
        }

        public Task SendRequest(HexBigInteger filter_id, object id = null)
        {
            var RpcRequest = _klayuninstallfilter.BuildRequest(filter_id, id);
            return base.SendRequest(RpcRequest);
        }
    }

    /*
     * @brief. Polling method for a filter, which returns an array of logs which occurred since last poll.
     */
    public class KlayGetFilterLogs : RpcRequestBuilder
    {
        public KlayGetFilterLogs() : base(ApiMethods.klay_getFilterLogs.ToString())
        {
        }

        public RpcRequest BuildRequest(HexBigInteger filter_id, object id = null)
        {
            return base.BuildRequest(id, filter_id);
        }
    };

    /*
     * klay_getFilterChanges --> klay_getFilterLogs 로 변경
     * KlayGetFilterChangesRequest --> KlayGetFilterLogs 로변경
     */

    public class KlayGetFilterLogsRequest : KlaytnRpcClient<KlayFilterLog[]>
    {
        public KlayGetFilterLogs _klaygetfilterLogs;

        public KlayGetFilterLogsRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaygetfilterLogs = new KlayGetFilterLogs();
        }

        public Task SendRequest(HexBigInteger filter_id, object id = null)
        {
            var RpcRequest = _klaygetfilterLogs.BuildRequest(filter_id, id);
            return base.SendRequest(RpcRequest);
        }
    };

    /*
     * @brief. klay_getLogs
     * @note.
     * The number of maximum returned results in a single query (Default: 10,000)
     * The execution duration limit of a single query (Default: 10 seconds).
     */
    public class KlayGetLogs : RpcRequestBuilder
    {
        public KlayGetLogs() : base(ApiMethods.klay_getLogs.ToString())
        {
        }

        public RpcRequest BuildRequest(BlockParameter from_block, BlockParameter to_block, string address, object[] topics = null, string blockhash = "", object id = null)
        {
            return base.BuildRequest(id, from_block, to_block, address, topics, blockhash);
        }
    }

    public class KlayGetLogsRequest : KlaytnRpcClient<KlayFilterLog[]>
    {
        private readonly KlayGetLogs _klaygetlogs;

        public KlayGetLogsRequest(string url, JsonSerializerSettings jsonSerializerSettings = null) : base(url, jsonSerializerSettings)
        {
            _klaygetlogs = new KlayGetLogs();
        }

        public Task SendRequest(BlockParameter from_block, BlockParameter to_block, string address, object[] topics = null, string blockhash = "", object id = null)
        {
            var RpcRequest = _klaygetlogs.BuildRequest(from_block, to_block, address, topics, blockhash, id);
            return base.SendRequest(RpcRequest);
        }
    }
}
