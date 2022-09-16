
using System;
using UnityEngine;
using UnityEngine.UI;


public class RoleChange : MonoBehaviour
{

   

    public RolePersistence RolePersistence;


    private void Start()
    {
        if (null != RolePersistence.GetCurrentJumpPlayer())
        {
            transform.gameObject.GetComponent<Image>().sprite  = RolePersistence.GetCurrentJumpPlayer();
        }
       
    }

   
   
}
