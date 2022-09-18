using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidence : MonoBehaviour
{
  public GameObject FirstStep;
  
    public GameObject SecondStep;
    
    public GameObject ThirdStep;
  
    public GameObject FinishGuidence;
  
   
    
    
    private void Start()
    {
      //if  need guidance
  
      if ("false" == PlayerPrefs.GetString("HasGuidence", "false"))
      {
         OnFirstStep();
      }
      
      
    }
  
  
    public void OnFirstStep()
    {
     
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
       PlayerPrefs.SetString("HasGuidence", "true");
  
    }
  
  
   
    
}
