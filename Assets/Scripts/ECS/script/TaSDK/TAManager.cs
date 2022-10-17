using System.Collections;
using System.Collections.Generic;
using ThinkingAnalytics;
using UnityEngine;

public class TAManager :Singleton<TAManager>
{
    
    public void InitShuShuSDK()
    {
        Debug.Log("[ThinkingSDK Unity_PC_V" + "InitShuShuSDK");
      
        new GameObject("ThinkingAnalytics", typeof(ThinkingAnalyticsAPI));

     
        string appId = Constant.shushuAppID;
        string serverUrl = Constant.shushuReportUrl;
        ThinkingAnalyticsAPI.TAMode mode = ThinkingAnalyticsAPI.TAMode.NORMAL;
        ThinkingAnalyticsAPI.TATimeZone timeZone = ThinkingAnalyticsAPI.TATimeZone.Local;
        ThinkingAnalyticsAPI.Token token = new ThinkingAnalyticsAPI.Token(appId, serverUrl, mode, timeZone);
        ThinkingAnalyticsAPI.StartThinkingAnalytics(token);
        ThinkingAnalyticsAPI.EnableAutoTrack(AUTO_TRACK_EVENTS.ALL);
        
        Dictionary<string, object> superProperties = new Dictionary<string, object>()
        {
            {"AppID", Constant.AppID}
        };
        ThinkingAnalyticsAPI.SetSuperProperties(superProperties);
        
        
    }

    //set functions
    // public void SetWalletAddress(string walletAddress)
    // {
    //     this.walletAddress = walletAddress;
    // }
    //
    //
    // public void SetNFTIdStr(string nftIdStr)
    // {
    //     this.nftIdStr = nftIdStr;
    // }
    //
    // //user login
    // public void AccountLogin()
    // {   
    //     
    //    
    //     if (!MirrorConfig.shushuSDKOpen)
    //     {
    //         return;
    //     }
    //     if(walletAddress == null || nftIdStr == null)
    //     {
    //         Debug.LogError("Shushu:Lack of wallet or nft str");
    //         return;
    //     }
    //
    //     string accountId = walletAddress + "_" + nftIdStr;
    //     ThinkingAnalyticsAPI.Login(accountId);
    //
    //     DeviceFirst(accountId,ThinkingAnalyticsAPI.GetDeviceId());
    // }
    //
    // public void AccountLogout()
    // {
    //     ThinkingAnalyticsAPI.Logout();
    // }

   

    

    
    //
    // // NFT Switch 
    // public void SwitchNft(string token_id,string token_id_after )
    // {
    //
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"token_id", token_id},
    //         {"token_id_after", token_id_after}
    //     };
    //     ThinkingAnalyticsAPI.Track("nft_switch",properties);                      
    // }
    //
    //
    // public void ClassLevelUp(int classBefore, int classAfter,List<object> currencies)
    // {   
    //     
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"class_before", classBefore},
    //         {"class_after", classAfter},
    //         {"currency_array", currencies}
    //     };
    //     ThinkingAnalyticsAPI.Track("class_level_up",properties);    
    // }
    //
    // public void LevelUp(int level_before, int level_after,List<Currency> currencies)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"level_before", level_before},
    //         {"level_after", level_after},
    //         {"currency_array", currencies}
    //     };
    //     ThinkingAnalyticsAPI.Track("level_up",properties);    
    // }
    //
    //
    //
    // public void SkillManage(List<string> skill_before, List<string> skill_after)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"skill_before", skill_before},
    //         {"skill_after", skill_after}
    //     };
    //     ThinkingAnalyticsAPI.Track("skill_manage",properties);   
    //     
    // }
    //
    // public void GetEquip(string equip_id,string equip_location,string change_reason)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"equip_id", equip_id},
    //         {"equip_location", equip_location},
    //         {"change_reason", change_reason}
    //     };
    //     ThinkingAnalyticsAPI.Track("get_equip",properties);   
    // }
    //
    //
    //
    //
    // public void Login(string last_login_time)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"last_login_time", last_login_time}
    //     };
    //     ThinkingAnalyticsAPI.Track("login",properties);   
    // }
    //
    //
    //
    // public void LogoutStart()
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.TimeEvent("logout");
    // }
    //
    //
    // public void LogoutEnd()
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.Track("logout");
    // }
    // public void WearEquip(string equip_id,string equip_location)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"equip_id", equip_id},
    //         {"equip_location", equip_location}
    //     };
    //     ThinkingAnalyticsAPI.Track("wear_equip",properties);  
    // }
    //
    // public void BoostEquip(string equip_id,string equip_location, int equip_level_before , int equip_level_after,List<object> currencies )
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"equip_id", equip_id},
    //         {"equip_location", equip_location},
    //         {"equip_level_before", equip_level_before},
    //         {"equip_level_after", equip_level_after},
    //         {"currency_array", currencies}
    //     };
    //     ThinkingAnalyticsAPI.Track("boost_equip",properties); 
    // }
    //
    //
    // public void BattleStart(string battle_type,string mode,string level_id,List<string> equip_list,List<string> skill_list)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"battle_type", battle_type},
    //         {"level_id", level_id},
    //         {"equip_list", equip_list},
    //         {"skill_list", skill_list},
    //         {"battle_difficulty",mode}
    //     };
    //     ThinkingAnalyticsAPI.Track("battle_start",properties); 
    // }
    //
    // public void MWMCost(string change_reason, float change_amount, float amount_after)
    // {
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"change_reason", change_reason},
    //         {"change_amount", change_amount},
    //         {"amount_after", amount_after}
    //     };
    //     
    //     ThinkingAnalyticsAPI.Track("mwm_cost",properties); 
    // }
    //
    //
    // public void BattleEndStart()
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.TimeEvent("battle_end");
    // }
    // public void BattleEnd(string battle_type,string level_id,string mode,List<string> equip_list,List<string> skill_list,List<int> skill_used_detail,bool if_succeed,bool if_boss_level,int death_time,string failed_reason,int exp_amt)
    // {   
    //     
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"battle_type", battle_type},
    //         {"level_id", level_id},
    //         {"equip_list", equip_list},
    //         {"skill_list",skill_list},
    //         {"skill_used_detail", skill_used_detail},
    //         {"if_succeed", if_succeed},
    //         {"if_boss_level", if_boss_level},
    //         {"death_time", death_time},
    //         {"failed_reason", failed_reason},
    //         {"exp_amt",exp_amt},
    //         {"battle_difficulty",mode}
    //     };
    //     ThinkingAnalyticsAPI.Track("battle_end",properties); 
    // }
    //
    //
    //
    // public void StorySkip(string level_id)
    // {   
    //     
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"level_id", level_id}
    //     };
    //     ThinkingAnalyticsAPI.Track("story_skip",properties);  
    // }
    //
    //
    // public void StoryFinish(string level_id)
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"level_id", level_id}
    //     };
    //     ThinkingAnalyticsAPI.Track("story_finish",properties);  
    //     
    // }
    //
    // public void Deposit(bool if_copied,string address_copied )
    // {
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"if_copied", if_copied},
    //         {"address_copied",address_copied}
    //     };
    //     ThinkingAnalyticsAPI.Track("wallet_copy",properties);  
    // }
    //
    // public void Withdrawl(string from_address,string to_address,float withdrawl_amount)
    // { 
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"from_address", from_address},
    //         {"to_address", to_address},
    //         {"withdrawl_amount", withdrawl_amount}
    //     };
    //     ThinkingAnalyticsAPI.Track("withdrawl_submit",properties);      
    // }
    //
    //
    //
    //
    //
    // public void ButtonClick(string entrance,string button_id )
    // {   
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"entrance", entrance},
    //         {"button_id", button_id}
    //     };
    //     ThinkingAnalyticsAPI.Track("button_click",properties);  
    // }
    //
    //
    // public void OpenWithdraw(string entrance,string button_id )
    // {   
    //     
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"entrance", entrance},
    //         {"button_id", button_id}
    //     };
    //     ThinkingAnalyticsAPI.Track("button_click",properties);  
    // }
    //
    // public void PopDeposit(string entrance,string button_id )
    // {   
    //     
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"entrance", entrance},
    //         {"button_id", button_id}
    //     };
    //     ThinkingAnalyticsAPI.Track("button_click",properties);  
    // }
    //
    //
    //
    //
    //
    //
    // public void SetSkills(string skills)
    // {
    //     this.skills = skills;
    // }
    //
    //
    //
    //
    //
    //
    //
    // // supper properties methods group
    // public void Activity(string activity_id, string activity_name)
    // {
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"activity_id", activity_id},
    //         {"activity_name", activity_name}
    //     };
    //     ThinkingAnalyticsAPI.Track("activity", properties);
    // }
    //
    //
    //
    //
    //
    //
    // public void SetDynamicPropMaxStoryLevel(string curr_max_story_level)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropMaxStoryLevel(curr_max_story_level));
    // }
    // public void SetDynamicPropMaxDungeonLevel(string curr_max_dungeon_level)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropMaxDungeonLevel(curr_max_dungeon_level));
    // }
    //
    //
    // // todo: 需要补充维护 领取任务数值更新
    // public void SetDynamicPropMwm(float curr_mwm_game_num)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropMwm(curr_mwm_game_num));
    // }
    //
    //
    //
    // // todo: 需要补充维护购买门票数值更新
    // public void SetDynamicPropStamina(int curr_stamina)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //
    //    
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropStamina(curr_stamina));
    // }
    //
    //

    // public void SetDynamicPropEquip(List<string> equips)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropEquip(equips));
    // }
    //
    // public void SetDynamicPropSkills(List<string> skills)
    // {
    //     if (!this.isShootEvent)
    //     {
    //         return;
    //     }
    //
    //     ThinkingAnalyticsAPI.SetDynamicSuperProperties(new DynamicPropSkills(skills));
    // }
    //





    // supper properties class


    // public class DynamicPropSkills : IDynamicSuperProperties
    // {
    //     List<string> curr_skill;
    //
    //
    //     public DynamicPropSkills(List<string> curr_skill)
    //     {
    //         this.curr_skill = curr_skill;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //         TAManager.Instance.curr_skill = curr_skill;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //     }
    // }
    // public class DynamicPropEquip : IDynamicSuperProperties
    // {
    //     List<string> curr_equip;
    //     public DynamicPropEquip(List<string> curr_equip)
    //     {
    //         this.curr_equip = curr_equip;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //
    //         TAManager.Instance.curr_equip = curr_equip;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //
    //     }
    // }
    //
    // public class DynamicPropStamina : IDynamicSuperProperties
    // {
    //     int curr_stamina;
    //     public DynamicPropStamina(int curr_stamina)
    //     {
    //         this.curr_stamina = curr_stamina;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //         TAManager.Instance.curr_stamina = curr_stamina;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //     }
    // }
    // public class DynamicPropMwm : IDynamicSuperProperties
    // {
    //     float curr_mwm_game_num;
    //     public DynamicPropMwm(float curr_mwm_game_num)
    //     {
    //         this.curr_mwm_game_num = curr_mwm_game_num;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //         TAManager.Instance.curr_mwm_game_num = curr_mwm_game_num;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //     }
    // }
    // public class DynamicPropMaxStoryLevel : IDynamicSuperProperties
    // {
    //     string curr_max_story_level;
    //     public DynamicPropMaxStoryLevel(string curr_max_story_level)
    //     {
    //         this.curr_max_story_level = curr_max_story_level;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //         TAManager.Instance.curr_max_story_level = curr_max_story_level;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //     }
    // }
    //
    // // 1.定义动态公共属性实现，此例为设置 UTC 时间的动态公共属性
    // public class DynamicPropMaxDungeonLevel : IDynamicSuperProperties
    // {
    //     string curr_max_dungeon_level;
    //     public DynamicPropMaxDungeonLevel(string curr_max_dungeon_level)
    //     {
    //         this.curr_max_dungeon_level = curr_max_dungeon_level;
    //     }
    //
    //     public Dictionary<string, object> GetDynamicSuperProperties()
    //     {
    //         TAManager.Instance.curr_max_dungeon_level = curr_max_dungeon_level;
    //         return new Dictionary<string, object>() {
    //             {"curr_skill",TAManager.Instance.curr_skill},
    //             {"curr_equip",TAManager.Instance.curr_equip},
    //             {"curr_stamina",TAManager.Instance.curr_stamina},
    //             {"curr_mwm_game_num",TAManager.Instance.curr_mwm_game_num},
    //             {"curr_max_dungeon_level",TAManager.Instance.curr_max_dungeon_level},
    //             {"curr_max_story_level",TAManager.Instance.curr_max_story_level},
    //
    //         };
    //     }
    // }
    //
    //
    //
    // public void GetMWM(string change_reason, float change_amount, float amount_after)
    // {
    //     
    //     Dictionary<string, object> properties = new Dictionary<string, object>(){
    //         {"change_reason", change_reason},
    //         {"change_amount",change_amount},
    //         {"amount_after",amount_after}
    //     };
    //     ThinkingAnalyticsAPI.Track("mwm_get",properties);  
    //     
    //     
    // }


   

    // public void SetEquips(string equips)
    // {
    //     this.equip = equips;
    // }
    //
    // public string Skills()
    // {
    //     return skills;
    // }
    //
    // public string Equips()
    // {
    //     return this.equip;
    // }
    

    // public void DeviceFirst(string accountID,string deviceID)
    // {
    //     Dictionary<string, object> properties = new Dictionary<string, object>()
    //     {
    //         {"first_check_id", accountID},
    //         {"device_id", deviceID}
    //     };
    //
    //     ThinkingAnalyticsAPI.Track(new TDFirstEvent("first_device_add", properties));
    // }
    //
    //
    // public  void ClearSkillInfo()
    // {
    //
    //   
    //     for (int i = 0; i < skillsCount.Length; i++)
    //     {
    //         skillsCount[i] = 0;
    //     }
    // }
    //
    // public List<int> GetSkillsInfo()
    // {  
    //
    //     List<int> list = new List<int>();
    //
    //     for(int i = 0;i < this.skillsCount.Length; i++)
    //     {
    //         list.Add(this.skillsCount[i]);  
    //     }
    //   
    //     return list;
    // }
    //
    //
    // public void SetSkillsInfo(int position)
    // {
    //    
    //    skillsCount[position] = skillsCount[position]+1;
    //
    //
    // }
    //
    //
    //
    // public void UserSetRent(bool isRent)
    // {
    //     ThinkingAnalyticsAPI.UserSet(new Dictionary<string, object>()
    //         {
    //             {"if_rent", isRent}
    //         }
    //     );
    //     
    // }
    //
    //
    //
    // // UserSet:curr_max_story_level
    // public void SetCurrentMaxStoryLevel(string curr_max_story_level)
    // {
    //     ThinkingAnalyticsAPI.UserSet(new Dictionary<string, object>()
    //         {
    //             {"curr_max_story_level", curr_max_story_level}
    //         }
    //     );
    // }
    //
    //
    // public void UserSet(string last_appear,bool if_logout)
    // {
    //     ThinkingAnalyticsAPI.UserSet(new Dictionary<string, object>()
    //         {
    //             {"last_appear", last_appear},
    //             {"if_logout", if_logout}
    //         }
    //     );
    // }
    //
    //
    //
    // public void UserSetOnceAddress(string address)
    // {
    //     ThinkingAnalyticsAPI.UserSetOnce(new Dictionary<string, object>()
    //         {
    //             {"game_balance_address", address}
    //         }
    //     );
    // }
    //
    // public void UserSetOnceFirstAppear(string first_appear,bool if_login)
    // {
    //     
    //     ThinkingAnalyticsAPI.UserSetOnce(new Dictionary<string, object>()
    //         {
    //             {"first_appear", first_appear},
    //             {"if_login", if_login}
    //         }
    //     );
    //     
    // }
    

}
