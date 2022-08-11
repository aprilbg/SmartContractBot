namespace SmartContract.NFT.Setup_account
{
    public class NFT_setup
    {
        public string _contractAddress = "";
        public string _managerAddress = "";
        public string _privateKey = "";
        public string _url = "https://api.baobab.klaytn.net:8651";
        public string abi = @"[
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_owner',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_approved',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'uint256',
				'name': '_tokenId',
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
				'internalType': 'address',
				'name': '_owner',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_operator',
				'type': 'address'
			},
			{
				'indexed': false,
				'internalType': 'bool',
				'name': '_approved',
				'type': 'bool'
			}
		],
		'name': 'ApprovalForAll',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_from',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_to',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'Transfer',
		'type': 'event'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'name': '_allTokens',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': 'tokenId',
				'type': 'uint256'
			}
		],
		'name': '_exists',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'owner',
				'type': 'address'
			}
		],
		'name': '_tokensOfOwner',
		'outputs': [
			{
				'internalType': 'uint256[]',
				'name': '',
				'type': 'uint256[]'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_approved',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'approve',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_owner',
				'type': 'address'
			}
		],
		'name': 'balanceOf',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'getApproved',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_owner',
				'type': 'address'
			},
			{
				'internalType': 'address',
				'name': '_operator',
				'type': 'address'
			}
		],
		'name': 'isApprovedForAll',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'master',
		'outputs': [
			{
				'internalType': 'address payable',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_to',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'mint',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'name',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'ownerOf',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_from',
				'type': 'address'
			},
			{
				'internalType': 'address',
				'name': '_to',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': '_tokenId',
				'type': 'uint256'
			}
		],
		'name': 'safeTransferFrom',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_operator',
				'type': 'address'
			},
			{
				'internalType': 'bool',
				'name': '_approved',
				'type': 'bool'
			}
		],
		'name': 'setApprovalForAll',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'symbol',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': 'index',
				'type': 'uint256'
			}
		],
		'name': 'tokenByIndex',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'owner',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'index',
				'type': 'uint256'
			}
		],
		'name': 'tokenOfOwnerByIndex',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'totalSupply',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	}
]";
    }

    public class nft_one : NFT_setup
    {
        public nft_one()
        {
			_contractAddress = "0x1bca1a18E445538953a339315e09254523C85d0C";
            _managerAddress = "0x9fec1bf8f2d1e013b1bc58ae9d614a496c785672";
            _privateKey = "0x877cbf84eb00ce8ae72243e5cb53d30f3b139dbfef466b8d5d8ba3a212e7a80a";
        }
    }


    public class nft_two : NFT_setup
    {
        public nft_two()
        {
			_contractAddress = "0xC4E4EDe220c270848d097f95c5bF3bce81480C55";
            _managerAddress = "0x6bfc0c8c0d8b9bcdab1179955ffcf65d5261a09d";
            _privateKey = "0x6e4fbfcc3895745144c3f0dcf77535a8c4b23a728b59e57d8c244a068cba9ebd";
        }
    }

    public class nft_three : NFT_setup
    {
        public nft_three()
        {
			_contractAddress = "0x827EEacCDe385e4D92300feAf52eA1F883b4845e";
            _managerAddress = "0x6aa24124b5d1df5d92d814e4c8b7201013830cd4";
            _privateKey = "0xe77fe3fd942263d038be348fd90c987f895c7936ed377c5e15b803ff946d4218";

        }
    }

    public class nft_four : NFT_setup
    {
        public nft_four()
        {
			_contractAddress = "0x9A0F5059B51DaC2ac011555e2fce8BA817df6187";
            _managerAddress = "0x8424649964f1024f414a67c249f7ee89f56aaabe";
            _privateKey = "0xc9879de1efad2cf2ccfcbfdaaf69fe066f1e1a2d3118557c5b0f5f9da44387de";

        }
    }

}