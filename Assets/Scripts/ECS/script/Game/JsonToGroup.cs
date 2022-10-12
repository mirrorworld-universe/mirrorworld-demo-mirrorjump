using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class JsonToObject : MonoBehaviour
{

    [SerializeField] private TextAsset[] Groups = new TextAsset[5];
    [SerializeField] private TextAsset equipmentJson;



    private void Start()
    {
        processVisualEffects();
        
    }

    private void processVisualEffects()
    {
        // RawVisualEffectData[] rawArray = JsonConvert.DeserializeObject<RawVisualEffectData[]>(visualEffectJson.text);

    }
    
    
}

  