
using System;
using UnityEngine;
using UnityEngine.UI;


public class RoleChange : MonoBehaviour
{

   

    public RolePersistence RolePersistence;


    private void Start()
    {

        if (null == PlayerPrefs.GetString("CurrentRole") || null == PlayerPrefs.GetString("CurrentRarity"))
        {
            transform.gameObject.GetComponent<Image>().sprite = RolePersistence.GetDefaultRoleJump();
        }
        else
        {
            transform.gameObject.GetComponent<Image>().sprite =
                RolePersistence.GetRoleImageJump(PlayerPrefs.GetString("CurrentRole"),
                    PlayerPrefs.GetString("CurrentRarity"));
        }
        
      
       
    }

   
   
}
