using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class FetchMultipleNftsByMintAddressesRequest
    {
        [JsonProperty("mint_addresses")] public List<string> MintAddresses;
    }
}