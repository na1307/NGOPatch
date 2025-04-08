using Steamworks;
using System;
using UnityEngine;

public static class MumiSteamNet
{
	private static SteamManager steamManagerInstance;

	public static void SetStat(string statid, int statvalue)
	{
		if (!MumiSteamNet.SteamInitialize())
		{
			return;
		}
		SteamUserStats.SetStat(statid, statvalue);
	}

	public static void SetAchieve(string achieveid)
	{
		if (!MumiSteamNet.SteamInitialize())
		{
			return;
		}
		bool flag;
		SteamUserStats.GetAchievement(achieveid, out flag);
		if (flag)
		{
			Debug.Log(achieveid + " : " + flag.ToString());
			return;
		}
		if (SteamUserStats.RequestCurrentStats())
		{
			if (SteamUserStats.SetAchievement(achieveid))
			{
				Debug.Log("実績" + achieveid + "を取得した！");
			}
			else
			{
				Debug.LogWarning("実績 " + achieveid + " を取得できなかった...");
			}
			SteamUserStats.StoreStats();
			return;
		}
		Debug.LogWarning("SteamのCurrentStatsがユーザーデータまだです");
	}

	public static bool GetAchieve(string achieveid)
	{
		bool flag;
		return MumiSteamNet.SteamInitialize() && SteamUserStats.RequestCurrentStats() && SteamUserStats.GetAchievement(achieveid, out flag) && flag;
	}

	public static void ResetAchieve()
	{
		if (MumiSteamNet.SteamInitialize() && SteamUserStats.RequestCurrentStats())
		{
			SteamUserStats.ResetAllStats(true);
		}
	}

	public static bool SteamInitialize()
	{
		if (MumiSteamNet.steamManagerInstance == null)
		{
			MumiSteamNet.steamManagerInstance = new GameObject("SteamManager").AddComponent<SteamManager>();
		}
		if (SteamManager.Initialized)
		{
			string personaName = SteamFriends.GetPersonaName();
			Debug.Log(string.Format("Steamの初期化成功, AppID : {0} Name : {1}", SteamUtils.GetAppID(), personaName));
			return true;
		}
		Debug.LogWarning("Steamの初期化失敗");
		return false;
	}

	public static void StoreStats()
	{
		if (!MumiSteamNet.SteamInitialize())
		{
			return;
		}
		SteamUserStats.StoreStats();
	}

	public static SystemLanguage GetLanguage()
	{
		string text = "";
		if (MumiSteamNet.SteamInitialize())
		{
			text = SteamUtils.GetSteamUILanguage();
		}
		if (text == "japanese")
		{
			return SystemLanguage.Japanese;
		}
		if (text == "english")
		{
			return SystemLanguage.English;
		}
		if (text == "\tschinese")
		{
			return SystemLanguage.ChineseSimplified;
		}
		// 한글패치
		if (text == "koreana")
		{
			return SystemLanguage.Korean;
		}
		return SystemLanguage.English;
	}
}
