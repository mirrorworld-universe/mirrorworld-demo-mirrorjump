using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class FetchMultipleNftsByUpdateAuthoritiesRequest
    {
        [JsonProperty("update_authorities")] public List<string> UpdateAuthorities;

        [JsonProperty("limit")] public long Limit;

        [JsonProperty("offset")] public long Offset;
    }
}