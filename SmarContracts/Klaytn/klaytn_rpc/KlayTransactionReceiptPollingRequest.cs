using System.Threading.Tasks;

namespace SmartContract.Klaytn.JsonRpc.UnityClient
{

    public class klayGetTransactionReceiptPollingRequest : Nethereum.JsonRpc.UnityClient.UnityRequest<KlayTransactionReceipt>
    {
        private string _url;
        private readonly KlayGetTransactionReceiptRequest _klay_gettransactionreceiptrequest;
        public bool CancelPolling { get; set; } = false;

        public klayGetTransactionReceiptPollingRequest(string url)
        {
            _url = url;
            _klay_gettransactionreceiptrequest = new KlayGetTransactionReceiptRequest(url);
        }

        /*
         * @brief secondwait 마다 transactionHash 의 receipt 을 요청하여, 응답 또는 예외 발생이 함수가 종료된다.
         */
        public async Task PollForReceipt(string transactionHash, float secondwait)
        {
            KlayTransactionReceipt receipt = null;
            Result = null;

            while (receipt == null)
            {
                if (!CancelPolling)
                {
                    await _klay_gettransactionreceiptrequest.SendRequest(transactionHash);

                    if (_klay_gettransactionreceiptrequest.Exception == null)
                    {
                        receipt = _klay_gettransactionreceiptrequest.Result;
                    }
                    else
                    {
                        Exception = _klay_gettransactionreceiptrequest.Exception;
                        return;
                    }

                }
                else
                {
                    Exception = _klay_gettransactionreceiptrequest.Exception;
                    return;
                }

                if (Exception == null && receipt == null)
                {
                    await Task.Delay((int)(secondwait * 1000));
                }
            }

            Result = receipt;
        }
    }
}