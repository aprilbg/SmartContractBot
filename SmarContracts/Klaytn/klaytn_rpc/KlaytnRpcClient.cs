using Nethereum.JsonRpc.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartContract.Klaytn.Unity.RpcModel;
using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

#if WD_UNITY
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading;
using UnityEngine.Networking;
using Nethereum.Unity.RpcModel;
#else // WD_UNITY
using System.Net.Http;

namespace Nethereum.JsonRpc.UnityClient
{
    public class UnityRequest<TResult>
    {
        public TResult Result { get; set; }

        public Exception Exception { get; set; }
    }
}
#endif // WD_UNITY


namespace SmartContract.Klaytn.JsonRpc.UnityClient
{

    /*
     * 
     */
    public class RpcRequest
    {
        public RpcRequest(object id, string method, params object[] parameterList)
        {
            Id = id;
            Method = method;
            RawParameters = parameterList;
        }

        public object Id { get; set; }
        public string Method { get; private set; }
        public object[] RawParameters { get; private set; }
    }

    /*
     * 
     */

    public class KlaytnRpcClient<TResult> : Nethereum.JsonRpc.UnityClient.UnityRequest<TResult>
    {
        private readonly string _url;
        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public KlaytnRpcClient(string url, JsonSerializerSettings jsonSerializerSettings = null)
        {
            if (jsonSerializerSettings == null)
            {
                jsonSerializerSettings = DefaultJsonSerializerSettingsFactory.BuildDefaultJsonSerializerSettings();
            }

            this._url = url;
            JsonSerializerSettings = jsonSerializerSettings;
        }
#if WD_UNITY
        public async Task SendRequest(RpcRequest request)
        {
            var request_format = new Klaytn.Unity.RpcModel.RpcRequest(request.Id, request.Method, request.RawParameters);
            var rpc_request_json = JsonConvert.SerializeObject(request_format, JsonSerializerSettings);
            var request_bytes = Encoding.UTF8.GetBytes(rpc_request_json);

            byte[] results;
            using (var unity_request = new UnityWebRequest(_url, "POST"))
            {
                var upload_handler = new UploadHandlerRaw(request_bytes);
                unity_request.SetRequestHeader("Content-Type", "application/json");
                upload_handler.contentType = "application/json";
                unity_request.uploadHandler = upload_handler;
                unity_request.downloadHandler = new DownloadHandlerBuffer();

                var r = unity_request.SendWebRequest();
                while (!r.isDone)
                {
                    await Task.Delay(10);
                }


                if (unity_request.error != null)
                {
                    this.Exception = new Exception(unity_request.error);
                    return;
                }
                results = unity_request.downloadHandler.data;
            }

            try
            {
                var response_json = Encoding.UTF8.GetString(results);
                var response_object = JsonConvert.DeserializeObject<RpcResponse>(response_json, JsonSerializerSettings);
                this.Result = response_object.GetResult<TResult>(true, JsonSerializerSettings);
                var exception = HandleRpcError(response_object);
                if (exception != null)
                {
                    this.Exception = exception;
                    return;
                }
                this.Result = response_object.GetResult<TResult>(true, JsonSerializerSettings);
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }
        }
        
#else // WD_UNITY
        static readonly HttpClient client = new HttpClient();

        public async Task SendRequest(RpcRequest request)
        {
            Unity.RpcModel.RpcRequest request_format = new Klaytn.Unity.RpcModel.RpcRequest(request.Id, request.Method, request.RawParameters);
            string rpc_request_json = JsonConvert.SerializeObject(request_format, JsonSerializerSettings);
            byte[] request_bytes = Encoding.UTF8.GetBytes(rpc_request_json);
            var results = await SendDataOrNullAsync(request_bytes);
            try
            {
                var response_json = Encoding.UTF8.GetString(results);
                var response_object = JsonConvert.DeserializeObject<RpcResponse>(response_json, JsonSerializerSettings);
                this.Result = response_object.GetResult<TResult>(true, JsonSerializerSettings);
                var exception = HandleRpcError(response_object);
                if (exception != null)
                {
                    this.Exception = exception;
                    return;
                }
                this.Result = response_object.GetResult<TResult>(true, JsonSerializerSettings);
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }
        }

        async Task<byte[]> SendDataOrNullAsync(byte[] data)
        {
            try
            {
                var byteContent = new ByteArrayContent(data);
                byteContent.Headers.Add("Content-Type", "application/json");
                HttpResponseMessage response = await client.PostAsync(_url, byteContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
#endif // WD_UNITY

        private Klaytn.Unity.RpcModel.RpcResponseException HandleRpcError(RpcResponse response)
        {
            if (response.HasError)
            {
                return new Klaytn.Unity.RpcModel.RpcResponseException(response.Error);
            }
            return null;
        }
    }
}