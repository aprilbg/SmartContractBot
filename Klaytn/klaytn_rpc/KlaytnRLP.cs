using Nethereum.RLP;
using Nethereum.Signer;
using Nethereum.Util;
using System;
#if WD_UNITY
using UnityEngine;
#endif // WD_UNITY

namespace SmartContract.Klaytn
{
#if WD_UNITY
    public static class DebugLoger
    {
        public static void DebugByteHex(string name, byte[] hexbyte)
        {
            if (hexbyte == null)
            {
                return;
            }

            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.OSXEditor)
            {
                string convert = BitConverter.ToString(hexbyte);
                string log = convert.Replace("-", "");

                string lower = log.ToLower();

                Debug.Log(name);
                Debug.Log(lower);
            }
        }
    }
#endif // WD_UNITY
}

namespace SmartContract.Klaytn.Singer
{

    public class KlaytnRLPSinger
    {
        public byte[] TxType = null;
        public byte[][] Data { get; private set; }
        public byte[][] ChainData { get; private set; }

        private readonly int numberOfEncodingElements;

        private byte[] rlpRawWithNoSignature; // 서명 되지 않는 rlp
        private byte[] rlpSignedEncoded; // 서명된 rlp

        public KlaytnRLPSinger(byte txtype, byte[][] data, byte[][] chaindata = null) : this(txtype, data, data.Length, chaindata)
        {
        }

        public KlaytnRLPSinger(byte txtype, byte[][] data, int numberOfEncodingElements, byte[][] chaindata)
        {
            this.numberOfEncodingElements = numberOfEncodingElements;
            this.Data = data;
            this.ChainData = chaindata;
            this.TxType = new byte[1] { txtype };
        }

        public byte[] GetRLPEncodeRaw()
        {
            byte[][] txData = new[] { TxType, Data[0], Data[1], Data[2], Data[3], Data[4], Data[5], Data[6] };

            byte[][] txChainData = new[] { RLP.EncodeDataItemsAsElementOrListAndCombineAsList(txData), ChainData[0], ChainData[1], ChainData[2] };
            rlpRawWithNoSignature = RLP.EncodeDataItemsAsElementOrListAndCombineAsList(txChainData);

            return rlpRawWithNoSignature;
        }

        public byte[] RawHash
        {
            get
            {
                var plainMsg = GetRLPEncodeRaw();

                return new Sha3Keccack().CalculateHash(plainMsg);
            }
        }

        public void Sign(Klaytn.KlayKey key, int chainid = 1001)
        {
            byte[] rawhash = RawHash;

            System.Numerics.BigInteger chain = new System.Numerics.BigInteger(ChainData[0]);
            Signature = key.SignAndCalculateV(rawhash, chainid);

            rlpSignedEncoded = null;
        }

        public byte[] GetRLPEncoded()
        {
            if (rlpSignedEncoded != null)
            {
                return rlpSignedEncoded;
            }

            byte[][] input_rsv = { Signature.V, Signature.R, Signature.S };

            byte[][] input_rlp = new[] {
                RLP.EncodeElement(Data[0]),
                RLP.EncodeElement(Data[1]),
                RLP.EncodeElement(Data[2]),
                RLP.EncodeElement(Data[3]),
                RLP.EncodeElement(Data[4]),
                RLP.EncodeElement(Data[5]),
                RLP.EncodeElement(Data[6]),
                RLP.EncodeList(RLP.EncodeDataItemsAsElementOrListAndCombineAsList(input_rsv))
            };

#if WD_UNITY
            for (int i = 0; i < input_rlp.Length; ++i)
            {
                DebugLoger.DebugByteHex(string.Format("element {0}", i), input_rlp[i]);
            }
#endif // WD_UNITY
            byte[] result = RLP.EncodeList(input_rlp);

            rlpSignedEncoded = new byte[result.Length + 1];
            rlpSignedEncoded[0] = TxType[0];
            Array.Copy(result, 0, rlpSignedEncoded, 1, result.Length);

#if WD_UNITY
            DebugLoger.DebugByteHex("result", rlpSignedEncoded);
#endif // WD_UNITY
            return rlpSignedEncoded;
        }

        public EthECDSASignature Signature { get; private set; }
    }
}
