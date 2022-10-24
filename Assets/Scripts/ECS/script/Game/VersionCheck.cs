using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class VersionCheck : MonoBehaviour
{
     public struct VersionData
       {
           public string version;
           public string minversion;
           public string reviewversion; // 空字符串-非审核期，非空-审核期
           public string url;
           public string desc;
           public string access;
           public bool stop;            // 是否停服, 停服时不进行更新逻辑判断
       }
   
       struct Version
       {
           public int major;
           public int minor;
           public int patch;
           public int build;
       }
   
       [SerializeField] private VersionCheckDialog dialog;
       [SerializeField] private GameObject versionCheckPanel;
    
       private VersionData versionData;
       private bool needForceUpdate;

       private void Awake()
       {
           if (this.enabled)
           {
               versionCheckPanel.SetActive(true);
           }
       }
   
       void Start()
       {
          // touristButton.gameObject.SetActive(false);
   
           CheckVersion();
   
           dialog.confirmClicked += OnConfirmClicked;
           dialog.cancelClicked += OnCancelClicked;
   
       }
   
       private void OnCancelClicked()
       {
           dialog.gameObject.SetActive(false);
   
           // 如果点击了不再询问，则下次新版本出来之前不再提示
           PlayerPrefs.SetString("NewVersion", versionData.version);
       }
   
       private void OnConfirmClicked()
       {
           if (versionData.stop)
           {
               // 停服了
               Application.Quit();
           }
           else
           {
               Application.OpenURL(versionData.url);
               if(!needForceUpdate)
               {
                  dialog.gameObject.SetActive(false);
               }
               else
               {
                   dialog.gameObject.SetActive(true);
               }
           }
       }
   
       private void CheckVersion()
       {
           string url = "https://games.mirrorworld.fun/game/mirrama/config/android/version.json";
   #if UNITY_ANDROID
           url = "https://games.mirrorworld.fun/game/mirrama/config/android/version.json";
   #elif UNITY_IPHONE
           url = "https://games.mirrorworld.fun/game/mirrama/config/ios/version.json";
   #endif
           StartCoroutine(Get(url));
       }
   
       private IEnumerator Get(string path)
       {
   #if UNITY_IPHONE || UNITY_STANDALONE_OSX
           // ios和mac系统在场景初始化后离开发送http请求会耗时过长，所以加个延迟
           yield return new WaitForSeconds(0.8f);
   #endif
           using (UnityWebRequest request = UnityWebRequest.Get(path))
           {
               yield return request.SendWebRequest();
   
               versionCheckPanel.SetActive(false);
               var result = request.result;
   
               if(request.result == UnityWebRequest.Result.Success)
               {
                   Debug.Log("Version check finish.");
   
                   // newtonjson这种解析方式，类和json结构不需要完全对应
                   var data = JsonConvert.DeserializeObject<VersionData>(request.downloadHandler.text);
                   versionData = data;
   
                   if (data.stop)
                   {
                       // 停服状态下，只有当最高版本小于当前版本时，才不弹窗
                       var currentVersionList = SplitVersion(GlobalDef.GetCurrentVersion());
                       var newestVersionList = SplitVersion(data.version);
                       if(!IsLower(newestVersionList, currentVersionList))
                       {
                           // 弹出关闭游戏的弹窗
                          dialog.displayMessage("", data.desc, "Exit Game");
                       }
                   }
                   else
                   {
   
                   // 先判断是否是审核期
                   // 是否隐藏游客登陆，状态存储 AllPlayerManager
                   if (!string.IsNullOrEmpty(data.reviewversion) && data.reviewversion == GlobalDef.GetCurrentVersion())
                   {
                       // MirrorConfig.touristAccess = data.access;
                       // touristButton.gameObject.SetActive(true);
                   }
   
                   // 显示游客登陆时候，通知
                   if (NeedForceUpdate(data))
                   {
                       // 显示强制更新窗口
                       needForceUpdate = true; 
                       dialog.displayMessage("", data.desc, "Download");
                   }
                   else if (HasNewVersion(data))
                   {
                       string lastNewVersion = PlayerPrefs.GetString("NewVersion");
                       if (lastNewVersion != data.version)
                       {
                           // 显示可选更新窗口
                           // 显示强制更新窗口
                           needForceUpdate = false;
                            dialog.displayMessage("", data.desc, "Download");
                            dialog.EnableCancelButton("Don't ask more");
                       }
                   }
                   }
               }
           }
       }
   
       private bool HasNewVersion(VersionData data)
       {
           var currentVersionList = SplitVersion(GlobalDef.GetCurrentVersion());
           var newestVersionList = SplitVersion(data.version);
   
           return IsLower(currentVersionList, newestVersionList);
       }
   
       /// <summary>
       /// 第一个版本是否比第二个版本低
       /// </summary>
       /// <param name="v1"></param>
       /// <param name="v2"></param>
       /// <returns></returns>
       private bool IsLower(Version v1, Version v2)
       {
           if (v1.major > v2.major)
           {
               return false;
           }
           else if (v1.major < v2.major)
           {
               return true;
           }
           else if (v1.minor > v2.minor)
           {
               return false;
           }
           else if (v1.minor < v2.minor)
           {
               return true;
           }
           else if (v1.patch > v2.patch)
           {
               return false;
           }
           else if (v1.patch < v2.patch)
           {
               return true;
           }
           else if (v1.build > v2.build)
           {
               return false;
           }
           else if(v1.build < v2.build)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
   
       private bool NeedForceUpdate(VersionData data)
       {
           // 判断当前版本是否是最新版本
           var currentVersionList = SplitVersion(GlobalDef.GetCurrentVersion());
           var lowestVersionList = SplitVersion(data.minversion);
   
           return IsLower(currentVersionList, lowestVersionList);
       }
   
       private Version SplitVersion(string versionData)
       {
           Version version = new Version();
           var list = versionData.Split('.');
   
           version.major = int.Parse(list[0]);
           version.minor = int.Parse(list[1]);
           version.patch = int.Parse(list[2]);
           if(list.Length >= 4)
           {
               version.build = int.Parse(list[3]);
           }
   
           return version;
       }
   
     
}
