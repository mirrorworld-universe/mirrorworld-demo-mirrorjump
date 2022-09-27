
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject OptionMenu;

    public GameObject OptionMenuDetails;

    public GameObject Bg;

    public GameObject exit;

    public GameObject returnButton;

    public Button soundOn;
    public Button soundOff;


    public void OpenOptions()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        SoundManager.Instance.PlaySound(SoundName.Pop);
        Bg.SetActive(true);
        exit.SetActive(true);
        OptionMenu.SetActive(true);
        OptionMenuDetails.SetActive(false);
        returnButton.SetActive(false);

        soundOn.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound(SoundName.AudioSwitch);
            OnSoundOn();
        });
        soundOff.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlaySound(SoundName.AudioSwitch);
            OnSoundOff();
        });

        bool isMute = SoundManager.Instance.GetSoundState();

        if (isMute)
        {
            OnSoundOff();
        }
        else
        {
            OnSoundOn();
        }
    }

    private void OnSoundOff()
    {
        SoundManager.Instance.SetSoundState(true);

        SetButtonSelected(soundOff , true);
        SetButtonSelected(soundOn, false);
    }

    private void OnSoundOn()
    {
        SoundManager.Instance.SetSoundState(false);

        SetButtonSelected(soundOff, false);
        SetButtonSelected(soundOn, true);
    }

    public void SetButtonSelected(Button btn, bool isSelect)
    {
        if (isSelect)
        {
            btn.GetComponent<Image>().color = Color.black;
            btn.GetComponentInChildren<TextMeshProUGUI>().color = new Color(249 / 255f, 253 / 255f, 35 / 255f);
        }
        else
        {
            btn.GetComponent<Image>().color = Color.clear;
            btn.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void ExitOptions()
    {
        SoundManager.Instance.PlaySound(SoundName.Close);
        Bg.SetActive(false);
        exit.SetActive(false);
        OptionMenu.SetActive(false);
        OptionMenuDetails.SetActive(false);
        returnButton.SetActive(false);
    }


    public void BackOptionMenu()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        returnButton.SetActive(false);
        OptionMenuDetails.SetActive(false);
        OptionMenu.SetActive(true);
    }
    
    

    public void AboutMirrorJump()
    {
        SoundManager.Instance.PlaySound(SoundName.Button);
        OptionMenu.SetActive(false);
        OptionMenuDetails.SetActive(true);
        returnButton.SetActive(true);
    }

    public void OpenFeedback()
    {
        SoundManager.Instance.PlaySound(SoundName.OpenUrl);
        Application.OpenURL("https://app-staging.mirrorworld.fun/auth/login");
    }
    
    public void OpenFAQ()
    {
        SoundManager.Instance.PlaySound(SoundName.OpenUrl);
        Application.OpenURL("https://developer.mirrorworld.fun/#1696cb75-cb3b-46c0-9d3d-dea7c0f87f74");
    }
    
    public void OpenMirrorSDKLink()
    {
        SoundManager.Instance.PlaySound(SoundName.OpenUrl);
        Application.OpenURL("https://mirrorworld.fun/");
    }
    
   
}
