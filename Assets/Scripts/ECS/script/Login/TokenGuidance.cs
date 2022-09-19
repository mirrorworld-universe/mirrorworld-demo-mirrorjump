using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TokenGuidance : MonoBehaviour
{


  public GameObject FirstStep;

  public GameObject SecondStep;
  
  public GameObject ThirdStep;

  public GameObject FinishGuidence;

  public GameObject Back;


  public Guidence Guidence;
  
  
  private void Start()
  {
    //if  need guidance

    if ("false" == PlayerPrefs.GetString("HasReceiveToken", "false"))
    {
       OnFirstStep();
    }
    
    
  }


  public void OnFirstStep()
  {
     Back.SetActive(true);
     FirstStep.SetActive(true);
  }
  
  

  public void OnSecondStep()
  {
    FirstStep.SetActive(false);
    SecondStep.SetActive(true);
  }
  
  public void OnThirdStep()
  {
    SecondStep.SetActive(false);
    ThirdStep.SetActive(true);
  }


  public void OnFourthStep()
  {
    ThirdStep.SetActive(false);
    FinishGuidence.SetActive(true);
  }


  public void OnFinishedGuidence()
  {
     FinishGuidence.SetActive(false);
     Back.SetActive(false);
     PlayerPrefs.SetString("HasReceiveToken", "true");
     
     if ("false" == PlayerPrefs.GetString("HasGuidence", "false"))
     {
       Guidence.OnFirstStep();
     }


  }


  public void OnLogin()
  {
    //before login
    
    //login success
    SceneManager.LoadScene("Menu");
  }
  
  
}
