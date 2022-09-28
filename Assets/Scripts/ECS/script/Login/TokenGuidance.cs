using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TokenGuidance : MonoBehaviour
{


    public GameObject FirstStep;

    public GameObject SecondStep;

    public GameObject ThirdStep;

    public GameObject FinishGuidence;

    public GameObject Back;


    public Guidence Guidence;

    public TextMeshProUGUI airDropWaitText;

    public bool isAirDropping;

    private long time;
    private long timeLomp = 500;
    private string str = "Airdropping Now";
    private string[] strs = { ".", "..", "..." };
    private int i = 0;

    private void Start()
    {
        isAirDropping = false;

        if ("false" == PlayerPrefs.GetString("HasReceiveToken", "false"))
        {
            OnFirstStep();
        }


    }

    private void Update()
    {
        if (isAirDropping)
        {
            long now = GetTime();
            if (time < now)
            {
                string text_ = str + strs[i % 3];
                airDropWaitText.text = text_;
                time = now + timeLomp;
                ++i;
            }

        }
    }

    private long GetTime()
    {
        //精确到毫秒
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
    }

    public void OnFirstStep()
    {
        Back.SetActive(true);
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

        StartCoroutine(AirDrop());
    }

    IEnumerator AirDrop()
    {
        isAirDropping = true;
        yield return new WaitForSeconds(3);

        OnFourthStep();
        isAirDropping = false;
        yield break;


        string url = "https://api.devnet.solana.com/";
        AirDropPostData data = new AirDropPostData();
        data.jsonrpc = "2.0";
        data.id = System.Guid.NewGuid().ToString();
        data.method = "requestAirdrop";
        data.param = new List<string>();
        data.param.Add("47UkX231ZHpixitg7QrFStawxYDHcKivgvH7Sabv1izY");     // 地址
        data.param.Add("1000000000");

        string postData = JsonUtility.ToJson(data);
        postData = postData.Replace("param", "params");
        postData = postData.Replace("\"1000000000\"", "1000000000");
        using (UnityWebRequest request = UnityWebRequest.Post(url, UnityWebRequest.kHttpVerbPOST))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("authority", "api.devnet.solana.com");
            byte[] postBytes = Encoding.UTF8.GetBytes(postData);
            request.uploadHandler = new UploadHandlerRaw(postBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            isAirDropping = false;
            if (request.result != UnityWebRequest.Result.ConnectionError)
            {
                //Debug.Log(response);
                // 空投成功
                OnFourthStep();
            }
            else
            {
                Debug.LogError($"发起网络请求失败： 确认过闸接口 -{request.error}");
            }
        }
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
