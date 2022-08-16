namespace SmartContract.Token.Setup
{
    public class E_token_setup
    {
        public string _contractAddress = "";
        public string _fromAddress = "";
        public string _privateKey = "";
        public string _url = "https://ropsten.infura.io/v3/9aa3d95b3bc440fa88ea12eaa4456161";
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
    public class Token_Setup_ETH : E_token_setup
    {
        public Token_Setup_ETH()
        {
            _contractAddress = "0x5DA3Cf991cF76b94120c2E1DbA25607185817453";
            _fromAddress = "0xdeEcE376741d4D41b760c9bB98710E7ec080D6BE";
            _privateKey = "8321cddbc7ec78c06b713a6fa09ffe04de9b99211ac1f08fc6e37ee0c2ef5e74";
        }
    }

    public class Token_Setup_SSD : E_token_setup
    {
        public Token_Setup_SSD() : base()// 부모의 생성자까지 호출
        {
            _contractAddress = "0x58D1f5E6267eB4F395E3b3679CF02A4b298D9911";
            _fromAddress = "0x267334D55c17e79044b480872012Db1eB8Ed3ac4";
            _privateKey = "abe8484357e6a1b75d85703232b4e9ee29575fb4293b22d58475d927cecf6e59";
        }
    }
    public class Token_Setup_RAM : E_token_setup
    {
        public Token_Setup_RAM()
        {
            _contractAddress = "0x94AeD0EA582DB776b91d57a14AD436D9Eeef1b4b";
            _fromAddress = "0x7e77F71079FCA309633AA6ea03109e2298c5Ce67";
            _privateKey = "7cc4d2f6f4aed3ec607cac96b82bc2390709c127732f1abb5eb4312838128552";
        }
    }
    public class Token_Setup_HARD : E_token_setup
    {
        public Token_Setup_HARD()
        {
            _contractAddress = "0x352E1971408511f98A1a8DCB19f5ea558B5BC7A7";
            _fromAddress = "0xe5Dc9Fc5Eb61877E10fB95B870d9bf611eaF7088";
            _privateKey = "7eb584d8fca020bd9905bc825d5bb6dec2df4108f1cd7a6819d541059c7223bf";
        }
    }
    public class Token_Setup_SOFT : E_token_setup
    {
        public Token_Setup_SOFT()
        {
            _contractAddress = "0xDA47490488FDa107c5292c040b7c313Af70AD82c";
            _fromAddress = "0x0238a4D020316a8C9411A40f6627C6A6A7f32d20";
            _privateKey = "92fc3bb86acb56647d2eb4decfcefc36517f99cf1e1fd94527ce5a1e61f63684";
        }
    }
}