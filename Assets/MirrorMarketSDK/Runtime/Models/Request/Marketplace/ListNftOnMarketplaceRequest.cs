﻿
using System;

namespace MirrorworldSDK.Models
{
    [Serializable]
    public class ListNftOnMarketplaceRequest : BaseWeb3Request
    {
        public string mint_address;

        public decimal price;
    }
}