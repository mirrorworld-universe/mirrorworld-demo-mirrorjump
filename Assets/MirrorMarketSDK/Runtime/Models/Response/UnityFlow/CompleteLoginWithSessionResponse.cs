using System;
using Unity.Plastic.Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class CompleteLoginWithSessionResponse
    {
        [JsonProperty("session_token")] public string sessionToken;
    }
}
