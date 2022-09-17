
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
            transform.gameObject.GetComponent<Image>().sprite = RolePersistence.GetDefaultRole();
        }
        else
        {
            transform.gameObject.GetComponent<Image>().sprite =
                RolePersistence.GetRoleImage(PlayerPrefs.GetString("CurrentRole"),
                    PlayerPrefs.GetString("CurrentRarity"));
        }
        
      
       
    }

   
   
}
