using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : Singleton<NetworkManager>
{
    public void SendUserBasicInfoReq(string user_id)
    {
        // TODO

        EventDispatcher.Instance.userInfoDataReceived.Invoke(null);
    }

    public void SendUserScoreReq(UserScoreUpdateReq req)
    {
        // TODO
        EventDispatcher.Instance.userScoreReceived.Invoke(null);
    }

    public void UpdateMintStatusReq(string user_id)
    {
        // TODO
        EventDispatcher.Instance.updateMintReceived.Invoke(null);
    }

    public void UpdateAirdropSolReq(string user_id)
    {
        // TODO
        EventDispatcher.Instance.updateAirdopReceived.Invoke(null);
    }
}

// Get User Basic Info 返回数据
public class UserBasicInfoRes
{
    public string status;
    public UserInfoData data;
    public int code;
    public string message;
}

public class UserInfoData
{
    public string name;
    public List<UserInfoPackageData> package;
    public List<UserInfoSceneData> scenes;
    public long highest_score;
    public bool airdrop_sol;
}

public class UserInfoPackageData
{
    public int token_id;
    public string rarity;
    public string type;
    public string token_url;
    public string image;
    public bool is_default;
}

public class UserInfoSceneData
{
    public string scene_name;
    public int scene_id;
}

// User score update 请求数据
public class UserScoreUpdateReq
{
    public string user_id;
    public long score;
    public string scene;
}
// User score update 返回数据
public class UserScoreUpdateRes
{
    public string status;
    public UserScoreUpdateData data;
    public int code;
    public string message;
}

public class UserScoreUpdateData
{
    public List<UserInfoSceneData> new_scenes;
    public long highest_score;
}

public class UpdateMintStatusReq
{
    public string user_id;
}

public class UpdateMintStatusRes
{
    public string status;
    public UpdateMintStateData data;
    public int code;
    public string message;
}

public class UpdateMintStateData
{
    public string user_id;
    public bool mint_statue;
}

public class UpdateAirdropSolReq
{
    public string user_id;
}

public class UpdateAirdropSolRes
{
    public string status;
    public UpdateAirdropSolData data;
    public int code;
    public string message;
}

public class UpdateAirdropSolData
{
    public string user_id;
    public bool airdrop_sol;
}