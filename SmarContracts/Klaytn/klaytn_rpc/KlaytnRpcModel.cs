using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SmartContract.Klaytn.Unity.RpcModel
{
    internal static class RpcResoponseExtensions
    {
        public static T GetResult<T>(this RpcResponse response, bool returnDefaultIfNull = true, JsonSerializerSettings settings = null)
        {
            if (response.Result == null)
            {
                if (!returnDefaultIfNull && default(T) != null)
                {
                    throw new Exception("Unable to convert the result (null) to type " + typeof(T));
                }
                return default(T);
            }
            try
            {
                if (settings == null)
                {
                    return response.Result.ToObject<T>();
                }
                else
                {
                    JsonSerializer jsonSerializer = JsonSerializer.Create(settings);
                    return response.Result.ToObject<T>(jsonSerializer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to convert the result to type " + typeof(T), ex);
            }
        }
    }

    [JsonObject]
    internal class RpcResponse
    {
        [JsonConstructor]
        protected RpcResponse()
        {
            JsonRpcVersion = "2.0";
        }

        protected RpcResponse(object id)
        {
            this.Id = id;
            JsonRpcVersion = "2.0";
        }

        public RpcResponse(object id, RpcError error) : this(id)
        {
            this.Error = error;
        }

        public RpcResponse(object id, JToken result) : this(id)
        {
            this.Result = result;
        }

        [JsonProperty("id", Required = Required.AllowNull)]
        public object Id { get; private set; }

        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string JsonRpcVersion { get; private set; }

        [JsonProperty("result", Required = Required.Default)] //TODO somehow enforce this or an error, not both
        public JToken Result { get; private set; }

        [JsonProperty("error", Required = Required.Default)]
        public RpcError Error { get; private set; }

        [JsonIgnore]
        public bool HasError { get { return this.Error != null; } }
    }

    [JsonObject]
    internal class RpcRequest
    {
        [JsonConstructor]
        public RpcRequest(object id, string method, params object[] parameterList)
        {
            this.Id = id;
            this.JsonRpcVersion = "2.0";
            this.Method = method;
            this.RawParameters = parameterList;
        }

        public RpcRequest(object id, string method, Dictionary<string, object> parameterMap)
        {
            this.Id = id;
            this.JsonRpcVersion = "2.0";
            this.Method = method;
            this.RawParameters = parameterMap;
        }

        [JsonProperty("id")]
        public object Id { get; private set; }

        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string JsonRpcVersion { get; private set; }

        [JsonProperty("method", Required = Required.Always)]
        public string Method { get; private set; }

        [JsonProperty("params")]
        [JsonConverter(typeof(RpcParametersJsonConverter))]
        public object RawParameters { get; private set; }
    }

    internal class RpcParametersJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    try
                    {
                        JObject jObject = JObject.Load(reader);
                        return jObject.ToObject<Dictionary<string, object>>();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Request parameters can only be an associative array, list or null.");
                    }
                case JsonToken.StartArray:
                    return JArray.Load(reader).ToObject<object[]>(serializer);
                case JsonToken.Null:
                    return null;
            }
            throw new Exception("Request parameters can only be an associative array, list or null.");
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }

    [JsonObject]
    internal class RpcError
    {
        [JsonConstructor]
        private RpcError()
        {
        }
        /// <summary>
        /// Rpc error code (Required)
        /// </summary>
        [JsonProperty("code", Required = Required.Always)]
        public int Code { get; private set; }

        /// <summary>
        /// Error message (Required)
        /// </summary>
        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; private set; }

        /// <summary>
        /// Error data (Optional)
        /// </summary>
        [JsonProperty("data")]
        public JToken Data { get; private set; }
    }
    internal class RpcResponseException : Exception
    {
        public RpcResponseException(RpcError error) : base(error.Message)
        {
            RpcError = error;
        }

        public RpcError RpcError { get; }
    }
}
