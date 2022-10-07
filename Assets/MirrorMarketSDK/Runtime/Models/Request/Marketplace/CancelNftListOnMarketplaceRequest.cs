using Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class CancelNftListOnMarketplaceRequest
    {
        [JsonProperty("mint_address")] public string MintAddress;

        [JsonProperty("price")] public float Price;

        [JsonProperty("confirmation")] public string Confirmation;
    }
}