using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class JsonToGroup : MonoBehaviour
{

    [SerializeField] private TextAsset Groups ;


    private List<Group> CurrentGroupRule;
    

    private void Awake()
    {
        
        DeserializeGroupArray(Groups);
        
    }

    private void DeserializeGroupArray(TextAsset textAsset)
    {
       
        GroupEntity[] groupEntities = JsonConvert.DeserializeObject<GroupEntity[]>(textAsset.text);

        CurrentGroupRule = new List<Group>(groupEntities.Length);

        for (int i = 0; i < groupEntities.Length; i++)
        {
             Group groups = new Group();
             
             groups.GroupName = groupEntities[i].Name;
             
             groups.HeightFloor = groupEntities[i].Height[0];
             groups.HeightUpper = groupEntities[i].Height[1];
             
             groups.BaseYOffsetFloor = groupEntities[i].BaseYoffset[0];
             groups.BaseYOffsetUpper = groupEntities[i].BaseYoffset[1];
             
             groups.BaseXOffsetFloor = groupEntities[i].BaseXoffset[0];
             groups.BaseXOffsetUpper = groupEntities[i].BaseXoffset[1];
             
             groups.ExtraYoffsetFloor = groupEntities[i].ExtraYoffset[0];
             groups.ExtraYoffsetUpper = groupEntities[i].ExtraYoffset[1];
             
             groups.GenerateFloor = groupEntities[i].ExtraCount[0];
             groups.GenerateUpper = groupEntities[i].ExtraCount[1];

             groups.ExtraTypePercent = new List<int>(5);

             groups.PropTypePercent = new List<int>(5);

             for (int j = 0; j < groupEntities[i].ExtraTypePercent.Count; j++)
             {
                 groups.ExtraTypePercent.Add(groupEntities[i].ExtraTypePercent[j]);
                 groups.PropTypePercent.Add( groupEntities[i].ItemPercent[j]);
                 
             }
             
             CurrentGroupRule.Add(groups);
            
        }
        
    }


    private Group GetGroupByHeight(float height)
    {
        for (int i = 0; i < CurrentGroupRule.Count; i++)
        {
            if (height >= CurrentGroupRule[i].HeightFloor && height <  CurrentGroupRule[i].HeightUpper )
            {
                return CurrentGroupRule[i];
            }
        }

        return null;
    }
    
    
    
    
    
}

  