using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidence : MonoBehaviour
{
    public GameObject FirstStep;

    public GameObject SecondStep;

    public GameObject ThirdStep;

    public GameObject FinishGuidence;






    public void OnFirstStep()
    {

        FirstStep.SetActive(true);
    }



    public void OnSecondStep()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        FirstStep.SetActive(false);
        SecondStep.SetActive(true);
    }

    public void OnThirdStep()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        SecondStep.SetActive(false);
        ThirdStep.SetActive(true);
    }


    public void OnFourthStep()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        ThirdStep.SetActive(false);
        FinishGuidence.SetActive(true);
    }


    public void OnFinishedGuidence()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        FinishGuidence.SetActive(false);
        PlayerPrefs.SetString("HasGuidence", "true");

    }




}
