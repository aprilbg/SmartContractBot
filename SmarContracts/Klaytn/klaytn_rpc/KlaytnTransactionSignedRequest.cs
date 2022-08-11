using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System.Collections;
using System.Numerics;
using System.Threading.Tasks;

namespace SmartContract.Klaytn.JsonRpc.UnityClient
{
    public class KlkaytnSmartContractTransactionSignedRequest : Nethereum.JsonRpc.UnityClient.UnityRequest<string>
    {
        private string _url;
        private readonly string _privatekey;
        private readonly string _account;
        private readonly BigInteger? _chainid;
        private readonly KlaySmartContracctTransacitonSigner _smartcontractTransactinoSigner;

        private readonly KlayGasPriceReqeust _klayGasPriceRequest;
        private readonly KlayEstimateGasReqeust _klayEstimateGasRequest;
        private readonly KlayGetTransactionCountReqeust _klayGetTransactionCountRequest;
        private readonly KlaySendRawTransactionRequest _klaySendRawTransactionRequest;


        public KlkaytnSmartContractTransactionSignedRequest(string url, string account, string privatekey, BigInteger? chainid = null)
        {
            _chainid = chainid;
            _account = account.RemoveHexPrefix();
            _privatekey = privatekey;
            _smartcontractTransactinoSigner = new KlaySmartContracctTransacitonSigner();

            _klayGasPriceRequest = new KlayGasPriceReqeust(url);
            _klayEstimateGasRequest = new KlayEstimateGasReqeust(url);
            _klayGetTransactionCountRequest = new KlayGetTransactionCountReqeust(url);
            _klaySendRawTransactionRequest = new KlaySendRawTransactionRequest(url);
        }

        public async Task SendAndSignedRequest(TransactionInput transactioninput)
        {
            if (transactioninput == null)
            {
                return;
            }

            if (transactioninput.Gas == null)
            {
                await _klayEstimateGasRequest.SendRequest(transactioninput);

                HexBigInteger gas;

                if (_klayEstimateGasRequest.Exception == null)
                {
                    gas = _klayEstimateGasRequest.Result;
                }
                else
                {
                    return;
                }

                BigInteger halfGas = BigInteger.Divide(gas.Value, 2);
                BigInteger newEstimateGas = BigInteger.Add(gas.Value, halfGas);

                transactioninput.Gas = new HexBigInteger(newEstimateGas);
            }

            if (transactioninput.GasPrice == null)
            {
                await _klayGasPriceRequest.SendRequest();

                if (_klayGasPriceRequest.Exception == null)
                {
                    transactioninput.GasPrice = _klayGasPriceRequest.Result;
                }
                else
                {
                    return;
                }
            }

            var nonce = transactioninput.Nonce;
            if (nonce == null)
            {
                await _klayGetTransactionCountRequest.SendRequest(_account);

                if (_klayGetTransactionCountRequest.Exception == null)
                {
                    nonce = _klayGetTransactionCountRequest.Result;
                }
                else
                {
                    return;
                }
            }

            var value = transactioninput.Value;
            if (value == null)
            {
                value = new HexBigInteger(0);
            }

            string signedTransaction = _smartcontractTransactinoSigner.SignTransaciton(_privatekey, _chainid.Value,
                transactioninput.From, transactioninput.To, value.Value, nonce, transactioninput.GasPrice.Value, transactioninput.Gas.Value, transactioninput.Data);

            await _klaySendRawTransactionRequest.SendRequest(signedTransaction);

            if (_klaySendRawTransactionRequest.Exception == null)
            {
                Result = _klaySendRawTransactionRequest.Result;
            }
            else
            {
                Exception = _klaySendRawTransactionRequest.Exception;
            }
        }
    }
}
