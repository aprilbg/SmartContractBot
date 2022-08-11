namespace SmartContract.Token.Setup
{
    public class K_token_setup
    {
        public string _contractAddress = "0x80CF1d172c657Edd39356f769C41080B35b8d99c";
        public string _fromAddress = "0xf3c1341bf9000a50ba3dd9bdb0434262f28e1d6f";
        public string _privateKey = "0xd1a7f69de6a19541327b8fc0389cc3f203c40f4a043bf133783488741f1e32c8";
        public string _url = "https://api.baobab.klaytn.net:8651";
        public string abi =
        @"[
	{
		'constant': true,
		'inputs': [],
		'name': 'name',
		'outputs': [
			{
				'name': '',
				'type': 'string'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': false,
		'inputs': [
			{
				'name': '_spender',
				'type': 'address'
			},
			{
				'name': '_value',
				'type': 'uint256'
			}
		],
		'name': 'approve',
		'outputs': [
			{
				'name': '',
				'type': 'bool'
			}
		],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [],
		'name': 'totalSupply',
		'outputs': [
			{
				'name': '',
				'type': 'uint256'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': false,
		'inputs': [
			{
				'name': '_from',
				'type': 'address'
			},
			{
				'name': '_to',
				'type': 'address'
			},
			{
				'name': '_value',
				'type': 'uint256'
			}
		],
		'name': 'transferFrom',
		'outputs': [
			{
				'name': '',
				'type': 'bool'
			}
		],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [],
		'name': 'decimals',
		'outputs': [
			{
				'name': '',
				'type': 'uint8'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': false,
		'inputs': [
			{
				'name': '_value',
				'type': 'uint256'
			}
		],
		'name': 'burn',
		'outputs': [
			{
				'name': '',
				'type': 'bool'
			}
		],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [
			{
				'name': '',
				'type': 'address'
			}
		],
		'name': 'balanceOf',
		'outputs': [
			{
				'name': '',
				'type': 'uint256'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [],
		'name': 'symbol',
		'outputs': [
			{
				'name': '',
				'type': 'string'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [],
		'name': 'tokenOwner',
		'outputs': [
			{
				'name': '',
				'type': 'address'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': false,
		'inputs': [
			{
				'name': '_to',
				'type': 'address'
			},
			{
				'name': '_value',
				'type': 'uint256'
			}
		],
		'name': 'transfer',
		'outputs': [
			{
				'name': '',
				'type': 'bool'
			}
		],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [
			{
				'name': '_owner',
				'type': 'address'
			}
		],
		'name': 'balanceOfToken',
		'outputs': [
			{
				'name': '',
				'type': 'uint256'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'constant': false,
		'inputs': [
			{
				'name': '_spender',
				'type': 'address'
			},
			{
				'name': '_value',
				'type': 'uint256'
			},
			{
				'name': '_extraData',
				'type': 'bytes'
			}
		],
		'name': 'approveAndCall',
		'outputs': [
			{
				'name': '',
				'type': 'bool'
			}
		],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'constant': true,
		'inputs': [
			{
				'name': '_owner',
				'type': 'address'
			},
			{
				'name': '_spender',
				'type': 'address'
			}
		],
		'name': 'allowance',
		'outputs': [
			{
				'name': '',
				'type': 'uint256'
			}
		],
		'payable': false,
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'payable': false,
		'stateMutability': 'nonpayable',
		'type': 'constructor'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'name': 'from',
				'type': 'address'
			},
			{
				'indexed': true,
				'name': 'to',
				'type': 'address'
			},
			{
				'indexed': false,
				'name': 'value',
				'type': 'uint256'
			}
		],
		'name': 'Transfer',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'name': 'owner',
				'type': 'address'
			},
			{
				'indexed': true,
				'name': 'spender',
				'type': 'address'
			},
			{
				'indexed': false,
				'name': 'value',
				'type': 'uint256'
			}
		],
		'name': 'Approval',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'name': 'from',
				'type': 'address'
			},
			{
				'indexed': false,
				'name': 'value',
				'type': 'uint256'
			}
		],
		'name': 'Burn',
		'type': 'event'
	}
]";
    }
    public class Token_Setup_one : K_token_setup
    {

    }
    public class Token_Setup_two : K_token_setup
    {
        public Token_Setup_two()
        {
            _contractAddress = "0x58BCe7f9738759a4c0DD323819530dbbAb889270";
            _fromAddress = "0x4a48fbf0c74ca0c524b28ee29663c5852083fbfb";
            _privateKey = "0x3e218b58b93ee1933721c6c9ce7b5fbea81317a5209d2421f6b354b53c1d8d8e";
        }
    }
    public class Token_Setup_three : K_token_setup
    {
        public Token_Setup_three()
        {
            _contractAddress = "0x30819c4B519284dA78000b7a52D6B765ccFB2957";
            _fromAddress = "0x3986d0ce130ca3c01e28b7ea9a45162fa6f0d174";
            _privateKey = "0x496e9b34d66df9fd51be9209a3b13ed629849c2b672ab04134951052a051dfb8";
        }
    }
    public class Token_Setup_four : K_token_setup
    {
        public Token_Setup_four()
        {
            _contractAddress = "0xfeC5d20fe5B362aa4fa85b3B80640bc6C5136524";
            _fromAddress = "0x0960c6d129f5338c6ade8e339b9a4105ac8771ed";
            _privateKey = "0xd900f4ce0cc3b52c775afa475d90445aefc459d808198609fed35f09bf6bfaee";
        }
    }
    public class Token_Setup_five : K_token_setup
    {
        public Token_Setup_five()
        {
            _contractAddress = "0x59b502041238C4715Ae68F629eE62a4539F9C548";
            _fromAddress = "0x9ff6ea25c33a42f3da163b32f5f7f7bf13d10218";
            _privateKey = "0x23ed824ea83c437bb61f7118350828347dd0e6b74836c5b7dbc50e50b875e194";
        }
    }
    public class Token_Setup_six : K_token_setup
    {
        public Token_Setup_six()
        {
            _contractAddress = "0xc8e16323AE085C69dB7Ea791a3B0c828Af9A3d64";
            _fromAddress = "0xe57ad5a119ecbfceed41c3ad70955fbd74a7dece";
            _privateKey = "0x1f69675cd7be32f0a82d8974ae64f7f03dc6c450c69a7a36c06792f4cf6f9bad";
        }
    }
    public class Token_Setup_seven : K_token_setup
    {
        public Token_Setup_seven()
        {
            _contractAddress = "0xBaC70b988087e11D58844a298c7fb4A1F6C66658";
            _fromAddress = "0x626269369e75032c8c2ed457f0afdb7f3095026e";
            _privateKey = "0xfaecaa7cd7a6e9db48cc01102bb910b5091414fd89225530f04ab7dac41bc6ae";
        }
    }
    public class Token_Setup_eight : K_token_setup
    {
        public Token_Setup_eight()
        {
            _contractAddress = "0xE3F0AbA2720433f66809BebACb229562b91D1391";
            _fromAddress = "0xfce3474d6d5de3cc4db9e607b204f7fc4d755b4c";
            _privateKey = "0xd3ec4ff65da4d2437ffa04293143ba7448fb88547860e290306666bc209ca3ef";
        }
    }
}