using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer.Crypto;
using Org.BouncyCastle.Math;
using SmartContract.Klaytn.Singer;
using System;

namespace SmartContract.Klaytn
{

    public static class BigIntConfigration
    {
        public static BigInteger _2X = new BigInteger("0x02");
    };
    public class ECDSASignatureFactory
    {
        public static ECDSASignature FromComponents(byte[] r, byte[] s)
        {
            return new ECDSASignature(new BigInteger(1, r), new BigInteger(1, s));
        }

        public static ECDSASignature FromComponents(byte[] r, byte[] s, byte[] v)
        {
            var signature = FromComponents(r, s);
            signature.V = v;
            return signature;
        }

        public static ECDSASignature ExtractECDSASignature(byte[] signatureArray, byte[] chainId)
        {
            var signature_v = new[] { (byte)(signatureArray[64] + 35) };
            BigInteger v = new BigInteger(signature_v);

            BigInteger bigInt_ChainId = new BigInteger(chainId);
            BigInteger bigInt_final_v = v.Add(bigInt_ChainId.Multiply(BigIntConfigration._2X));


            var r = new byte[32];
            Array.Copy(signatureArray, r, 32);
            var s = new byte[32];
            Array.Copy(signatureArray, 32, s, 0, 32);

            return ECDSASignatureFactory.FromComponents(r, s, bigInt_final_v.ToByteArray());
        }
    }

    public class KlaySmartContracctTransacitonSigner
    {
        public string SignTransaciton(
            string privateKey,
            System.Numerics.BigInteger chainId,
            string from,
            string to,
            System.Numerics.BigInteger value,
            System.Numerics.BigInteger nonce,
            System.Numerics.BigInteger gasPrice,
            System.Numerics.BigInteger gasLimit,
            string data,
            byte txType = 0x30)
        {
            return SignTransaciton(privateKey.HexToByteArray(), chainId, from, to, value, nonce, gasPrice, gasLimit, data, txType);
        }

        public string SignTransaciton(
            byte[] privateKey,
            System.Numerics.BigInteger chainId,
            string from,
            string to,
            System.Numerics.BigInteger value,
            System.Numerics.BigInteger nonce,
            System.Numerics.BigInteger gasPrice,
            System.Numerics.BigInteger gasLimit,
            string data,
            byte txType = 0x30)
        {
            TransactionChainId transactionId = new TransactionChainId(txType, chainId, from, to, value, nonce, gasPrice, gasLimit, data);
            return SignTransaciton(privateKey, transactionId);
        }

        private string SignTransaciton(byte[] privatekey, TransactionChainId transactionchainId)
        {
            transactionchainId.Sign(new KlayKey(privatekey, true));
            return transactionchainId.GetRLPEncoded().ToHex();
        }
    }

    public class TransactionChainId
    {

        protected KlaytnRLPSinger SimpleRlpSigner { get; set; }

        public TransactionChainId(byte type,
            System.Numerics.BigInteger chainId,
            string from,
            string to,
            System.Numerics.BigInteger value,
            System.Numerics.BigInteger nonce,
            System.Numerics.BigInteger gasPrice,
            System.Numerics.BigInteger gasLimit,
            string data) : this(
                type,
                nonce.ToBytesForRLPEncoding(),
                gasPrice.ToBytesForRLPEncoding(),
                gasLimit.ToBytesForRLPEncoding(),
                from.HexToByteArray(),
                to.HexToByteArray(),
                value.ToBytesForRLPEncoding(),
                data.HexToByteArray(),
                chainId.ToBytesForRLPEncoding())
        {
        }

        public TransactionChainId(
            byte type,
            byte[] nonce,
            byte[] gasPrice,
            byte[] gasLimit,
            byte[] from,
            byte[] to,
            byte[] value,
            byte[] data,
            byte[] chainid)
        {

            System.Numerics.BigInteger zero = new System.Numerics.BigInteger(0);
            SimpleRlpSigner = new KlaytnRLPSinger(
                type,
                GetElementsInDataOrder(nonce, gasPrice, gasLimit, to, value, from, data),
                8,
                GetElementsInChainOrder(chainid, zero.ToBytesForRLPEncoding(), zero.ToBytesForRLPEncoding()));
        }

        private byte[][] GetElementsInDataOrder(
            byte[] nonce,
            byte[] gasPrice,
            byte[] gas,
            byte[] to,
            byte[] value,
            byte[] from,
            byte[] data)
        {
            return new[] { nonce, gasPrice, gas, to, value, from, data };
        }

        public byte[][] GetElementsInChainOrder(byte[] chainid, byte[] input1, byte[] input2)
        {
            return new[] { chainid, input1, input2 };
        }

        public void Sign(KlayKey key)
        {
            SimpleRlpSigner.Sign(key);
        }

        public byte[] GetRLPEncoded()
        {
            return SimpleRlpSigner.GetRLPEncoded();
        }
    };
}
