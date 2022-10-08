using System;
using Unity.Plastic.Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class GetLoginSessionResponse
    {
        [JsonProperty("session_token")] public string sessionToken;
    }
}