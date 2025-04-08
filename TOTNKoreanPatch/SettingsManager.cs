using System;
using UnityEngine;

public static class SettingsManager
{
	private const string setting_id = "setting_";

	public static int[] settingValues { get; private set; } = new int[32];

	public static bool isSavedSettings
	{
		get
		{
			return SaveFace.Has("setting_" + 1.ToString());
		}
	}

	public static void SaveSettingsJson()
	{
		for (int i = 0; i < SettingsManager.settingValues.Length; i++)
		{
			SaveFace.Save("setting_" + i.ToString(), (float)SettingsManager.settingValues[i]);
		}
		SaveFace.SaveJson();
		SettingsManager.AcceptSettings();
	}

	public static void LoadSettingsJson()
	{
		for (int i = 0; i < SettingsManager.settingValues.Length; i++)
		{
			SettingsManager.settingValues[i] = (int)SaveFace.Load("setting_" + i.ToString(), 0f);
		}
		SettingsManager.AcceptSettings();
	}

	public static void AcceptSettings()
	{
		mumiMasterVolume.BGM = (float)SettingsManager.settingValues[1] * 0.2f;
		mumiMasterVolume.SE = (float)SettingsManager.settingValues[2] * 0.2f;
		MumiWindow.Initialize(SettingsManager.settingValues[3]);
		mumiTrans.SetLanguage(SettingsManager.GetLanguage());
		TransTextComponent.InitializeTexts();
	}

	public static SystemLanguage GetLanguage()
	{
		switch (SettingsManager.settingValues[0])
		{
		case 0:
			return SystemLanguage.Japanese;
		case 1:
			return SystemLanguage.English;
		case 2:
			return SystemLanguage.ChineseSimplified;
		// 한글패치
		case 3:
			return SystemLanguage.Korean;
		default:
			return SystemLanguage.English;
		}
	}

	public static int GetLanguageID(SystemLanguage _lgg)
	{
		if (_lgg == SystemLanguage.English)
		{
			return 1;
		}
		if (_lgg == SystemLanguage.Japanese)
		{
			return 0;
		}
		if (_lgg == SystemLanguage.ChineseSimplified)
		{
			return 2;
		}
		// 한글패치
		if (_lgg == SystemLanguage.Korean)
		{
			return 3;
		}
		return 1;
	}

	public static SystemLanguage GetLanguageFromID(int LanguageID)
	{
		switch (LanguageID)
		{
		case 0:
			return SystemLanguage.Japanese;
		case 1:
			return SystemLanguage.English;
		case 2:
			return SystemLanguage.ChineseSimplified;
		// 한글패치
		case 3:
			return SystemLanguage.Korean;
		default:
			return SystemLanguage.English;
		}
	}
}
