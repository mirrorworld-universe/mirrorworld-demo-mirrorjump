using Unity.Plastic.Newtonsoft.Json;

namespace MirrorworldSDK.Models
{
    public class BasicEmailLoginRequest
    {
        [JsonProperty("email")] public string Email;

        [JsonProperty("password")] public string Password;
    }
}