using UnityEngine;
using System.Collections;
using Unity.Plastic.Newtonsoft.Json;

public class BaseWeb3Request
{
    [JsonProperty("confirmation")] public string Confirmation;
}
