using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;
using Nethereum.Signer.Crypto;
using Nethereum.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Linq;
using System.Numerics;

namespace SmartContract.Klaytn
{

    public class KlayKey
    {
        private static readonly SecureRandom SecureRandom = new SecureRandom();
        public static byte DEFAULT_PREFIX = 0x04;
        private readonly Key _ecKey;
        private byte[]? _publicKey;
        private byte[]? _publicKeyCompressed;
        private byte[]? _publicKeyNoPrefix;
        private byte[]? _publicKeyNoPrefixCompressed;
        private string? _ethereumAddress;
        private byte[]? _privateKey;
        private string? _privateKeyHex;

        public KlayKey(string privateKey)
        {
            _ecKey = new Key(privateKey.HexToByteArray(), true);
        }


        public KlayKey(byte[] vch, bool isPrivate)
        {
            _ecKey = new Key(vch, isPrivate);
        }

        public KlayKey(byte[] vch, bool isPrivate, byte prefix)
        {
            _ecKey = new Key(ByteUtil.Merge(new[] { prefix }, vch), isPrivate);
        }

        internal KlayKey(Key ecKey)
        {
            _ecKey = ecKey;
        }

        //public byte[] CalculateCommonSecret(EthECKey publicKey) {
        //    var agreement = new ECDHBasicAgreement();
        //    agreement.Init(_ecKey.PrivateKey);
        //    var z = agreement.CalculateAgreement(publicKey._ecKey.GetPublicKeyParameters());

        //    return BigIntegers.AsUnsignedByteArray(agreement.GetFieldSize(), z);
        //}

        ////Note: Y coordinates can only be forced, so it is assumed 0 and 1 will be the recId (even if implementation allows for 2 and 3)
        //internal int CalculateRecId(ECDSASignature signature, byte[] hash) {
        //    var thisKey = _ecKey.GetPubKey(false); // compressed
        //    return CalculateRecId(signature, hash, thisKey);
        //}

        public static EthECKey GenerateKey(byte[]? seed = null)
        {
            var secureRandom = SecureRandom;
            if (seed != null)
            {
                secureRandom = new SecureRandom();
                secureRandom.SetSeed(seed);
            }

            var gen = new ECKeyPairGenerator("EC");
            var keyGenParam = new KeyGenerationParameters(secureRandom, 256);
            gen.Init(keyGenParam);
            var keyPair = gen.GenerateKeyPair();
            var privateBytes = ((ECPrivateKeyParameters)keyPair.Private).D.ToByteArray();
            if (privateBytes.Length != 32)
                return GenerateKey();
            return new EthECKey(privateBytes, true);
        }

        public static EthECKey GenerateKey()
        {
            var gen = new ECKeyPairGenerator("EC");
            var keyGenParam = new KeyGenerationParameters(SecureRandom, 256);
            gen.Init(keyGenParam);
            var keyPair = gen.GenerateKeyPair();
            var privateBytes = ((ECPrivateKeyParameters)keyPair.Private).D.ToByteArray();
            if (privateBytes.Length != 32)
                return GenerateKey();
            return new EthECKey(privateBytes, true);
        }

        public byte[] GetPrivateKeyAsBytes()
        {
            if (_privateKey == null)
            {
                _privateKey = _ecKey.PrivateKey.D.ToByteArrayUnsigned();
            }
            return _privateKey;
        }

        public string GetPrivateKey()
        {
            if (_privateKeyHex == null)
            {
                _privateKeyHex = GetPrivateKeyAsBytes().ToHex(true);
            }
            return _privateKeyHex;
        }

        public static string GetPublicAddress(string privateKey)
        {
            var key = new EthECKey(privateKey.HexToByteArray(), true);
            return key.GetPublicAddress();
        }

        public static int GetRecIdFromV(byte[] v)
        {
            return GetRecIdFromV(v[0]);
        }


        public static int GetRecIdFromV(byte v)
        {
            var header = v;
            // The header byte: 0x1B = first key with even y, 0x1C = first key with odd y,
            //                  0x1D = second key with even y, 0x1E = second key with odd y
            if (header < 27 || header > 34)
                throw new Exception("Header byte out of range: " + header);
            if (header >= 31)
                header -= 4;
            return header - 27;
        }

        public static int GetRecIdFromVChain(BigInteger vChain, BigInteger chainId)
        {
            return (int)(vChain - chainId * 2 - 35);
        }

        public static BigInteger GetChainFromVChain(BigInteger vChain)
        {
            var start = vChain - 35;
            var even = start % 2 == 0;
            if (even) return start / 2;
            return (start - 1) / 2;
        }

        public EthECDSASignature SignAndCalculateV(byte[] hash, int chainid)
        {
            var signature = _ecKey.Sign(hash);
            int recid = CalculateRecId(signature, hash);

            var vChainId = CalculateV(chainid, recid);
            signature.V = vChainId.ToBytesForRLPEncoding();

            return new EthECDSASignature(signature.R, signature.S, signature.V);
        }

        private int CalculateRecId(ECDSASignature signature, byte[] hash)
        {
            var thiskey = _ecKey.GetPubKey(false);
            return CalculateRecId(signature, hash, thiskey);
        }

        private int CalculateRecId(ECDSASignature signature, byte[] hash, byte[] uncompressedPublicKey)
        {
            var recId = -1;

            for (var i = 0; i < 4; i++)
            {
                var rec = ECKey.RecoverFromSignature(i, signature, hash, false);
                if (rec != null)
                {
                    var k = rec.GetPubKey(false);
                    if (k != null && k.SequenceEqual(uncompressedPublicKey))
                    {
                        recId = i;
                        break;
                    }
                }
            }
            if (recId == -1)
                throw new Exception("Could not construct a recoverable key. This should never happen.");

            return recId;
        }

        internal static BigInteger CalculateV(int chainId, int recId)
        {
            int caculate_v = (chainId * 2) + (recId + 35);
            BigInteger value = new BigInteger(caculate_v);

            return value;
        }
    }
}
