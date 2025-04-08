using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TypingGameJP;
using UnityEngine;

public static class DrawBox
{
	private static int LibraryID = 0;

	private static List<ValueTuple<string, string, string, string, string, string>>[,] Library = new List<ValueTuple<string, string, string, string, string, string>>[10, 2];

	private static Queue<ValueTuple<string, string, string, string, string, string>>[,] QuestionQueue = new Queue<ValueTuple<string, string, string, string, string, string>>[10, 2];

	public static RomajiData mRomajiData = new RomajiData();

	private static Dictionary<string, string> initialMap_Microsoft_Sogou = new Dictionary<string, string>
	{
		{ "", "o" },
		{ "q", "q" },
		{ "w", "w" },
		{ "r", "r" },
		{ "t", "t" },
		{ "y", "y" },
		{ "sh", "u" },
		{ "ch", "i" },
		{ "p", "p" },
		{ "s", "s" },
		{ "d", "d" },
		{ "f", "f" },
		{ "g", "g" },
		{ "h", "h" },
		{ "j", "j" },
		{ "k", "k" },
		{ "l", "l" },
		{ "z", "z" },
		{ "x", "x" },
		{ "c", "c" },
		{ "zh", "v" },
		{ "b", "b" },
		{ "n", "n" },
		{ "m", "m" }
	};

	private static Dictionary<string, string> finalMap_Microsoft = new Dictionary<string, string>
	{
		{ "iu", "q" },
		{ "ia", "w" },
		{ "ua", "w" },
		{ "e", "e" },
		{ "er", "r" },
		{ "uan", "r" },
		{ "ue", "t" },
		{ "uai", "y" },
		{ "v", "y" },
		{ "u", "u" },
		{ "i", "i" },
		{ "o", "o" },
		{ "uo", "o" },
		{ "un", "p" },
		{ "a", "a" },
		{ "iong", "s" },
		{ "ong", "s" },
		{ "iang", "d" },
		{ "uang", "d" },
		{ "en", "f" },
		{ "eng", "g" },
		{ "ang", "h" },
		{ "an", "j" },
		{ "ao", "k" },
		{ "ai", "l" },
		{ "ing", ";" },
		{ "ei", "z" },
		{ "ie", "x" },
		{ "iao", "c" },
		{ "ui", "v" },
		{ "ve", "v" },
		{ "ou", "b" },
		{ "in", "n" },
		{ "ian", "m" }
	};

	private static Dictionary<string, string> finalMap_Sogou = new Dictionary<string, string>
	{
		{ "iu", "q" },
		{ "ia", "w" },
		{ "ua", "w" },
		{ "e", "e" },
		{ "er", "r" },
		{ "uan", "r" },
		{ "ue", "t" },
		{ "uai", "y" },
		{ "v", "y" },
		{ "u", "u" },
		{ "i", "i" },
		{ "o", "o" },
		{ "uo", "o" },
		{ "un", "p" },
		{ "a", "a" },
		{ "iong", "s" },
		{ "ong", "s" },
		{ "iang", "d" },
		{ "uang", "d" },
		{ "en", "f" },
		{ "eng", "g" },
		{ "ang", "h" },
		{ "an", "j" },
		{ "ao", "k" },
		{ "ai", "l" },
		{ "ing", ";" },
		{ "ei", "z" },
		{ "ie", "x" },
		{ "iao", "c" },
		{ "ui", "v" },
		{ "ve", "t" },
		{ "ou", "b" },
		{ "in", "n" },
		{ "ian", "m" }
	};

	public static void SetLibrary(List<TextAsset> _textCSVs)
	{
		if (DrawBox.LibraryID == 10000)
		{
			return;
		}
		for (int i = 0; i < DrawBox.Library.GetLength(0); i++)
		{
			for (int j = 0; j < DrawBox.Library.GetLength(1); j++)
			{
				DrawBox.Library[i, j] = new List<ValueTuple<string, string, string, string, string, string>>();
			}
		}
		for (int k = 0; k < DrawBox.QuestionQueue.GetLength(0); k++)
		{
			for (int l = 0; l < DrawBox.QuestionQueue.GetLength(1); l++)
			{
				DrawBox.QuestionQueue[k, l] = new Queue<ValueTuple<string, string, string, string, string, string>>();
			}
		}
		for (int m = 0; m < _textCSVs.Count; m++)
		{
			foreach (KeyValuePair<string, Dictionary<string, string>> keyValuePair in ReadCSV.ReadCSVFile(_textCSVs[m]))
			{
				if (keyValuePair.Value.ContainsKey("view"))
				{
					ValueTuple<string, string, string, string, string, string> valueTuple;
					if (keyValuePair.Value.ContainsKey("sogou_sou") && keyValuePair.Value.ContainsKey("microsoft_sou"))
					{
						valueTuple = new ValueTuple<string, string, string, string, string, string>(keyValuePair.Value["view"], keyValuePair.Value["input"], keyValuePair.Value["effect_id"], keyValuePair.Value["explain"], keyValuePair.Value["microsoft_sou"], keyValuePair.Value["sogou_sou"]);
					}
					else
					{
						valueTuple = new ValueTuple<string, string, string, string, string, string>(keyValuePair.Value["view"], keyValuePair.Value["input"], keyValuePair.Value["effect_id"], keyValuePair.Value["explain"], "", "");
					}
					int num = 10;
					if (DrawBox.GetInputText_fast(valueTuple, SettingsManager.GetLanguageFromID(m)).Length <= num)
					{
						DrawBox.Library[m, 0].Add(valueTuple);
					}
					else
					{
						DrawBox.Library[m, 1].Add(valueTuple);
					}
				}
			}
		}
		for (int n = 0; n < DrawBox.Library.GetLength(0); n++)
		{
			for (int num2 = 0; num2 < DrawBox.Library.GetLength(1); num2++)
			{
				DrawBox.ResetQueue(n, num2);
			}
		}
		DrawBox.LibraryID = 10000;
	}

	private static void GenerateDualListText()
	{
		List<ValueTuple<string, string, string, string, string, string>>[,] library = DrawBox.Library;
		int upperBound = library.GetUpperBound(0);
		int upperBound2 = library.GetUpperBound(1);
		for (int i = library.GetLowerBound(0); i <= upperBound; i++)
		{
			for (int j = library.GetLowerBound(1); j <= upperBound2; j++)
			{
				List<ValueTuple<string, string, string, string, string, string>> list = library[i, j];
				string text5 = "";
				foreach (ValueTuple<string, string, string, string, string, string> valueTuple in list)
				{
					string text2 = DrawBox.RemoveAccents(DrawBox.Removes(valueTuple.Item2));
					string text3 = DrawBox.ApplyFunctionToNonTaggedParts(text2, (string text) => DrawBox.GenerateDual(text, 1));
					string text4 = DrawBox.ApplyFunctionToNonTaggedParts(text2, (string text) => DrawBox.GenerateDual(text, 2));
					text5 = text5 + valueTuple.Item1 + " : ";
					text5 = text5 + text2 + " : ";
					text5 = text5 + text2.Replace(">", "").Replace("<", "") + " : ";
					text5 = text5 + text3 + " : ";
					text5 += text4;
					text5 += "\n";
				}
				Debug.Log(text5);
			}
		}
	}

	public static ValueTuple<string, string, string, string, string, string> Draw(TypingEngine.QuestionMode _mode)
	{
		int languageID = SettingsManager.GetLanguageID(SettingsManager.GetLanguage());
		int num = ((_mode == TypingEngine.QuestionMode.Short) ? 0 : 1);
		if (DrawBox.QuestionQueue[languageID, num].Count == 0)
		{
			DrawBox.ResetQueue(languageID, num);
		}
		return DrawBox.QuestionQueue[languageID, num].Dequeue();
	}

	private static void ResetQueue(int LanguageID, int drawID)
	{
		DrawBox.QuestionQueue[LanguageID, drawID] = new Queue<ValueTuple<string, string, string, string, string, string>>();
		foreach (ValueTuple<string, string, string, string, string, string> valueTuple in DrawBox.Library[LanguageID, drawID])
		{
			DrawBox.QuestionQueue[LanguageID, drawID].Enqueue(valueTuple);
		}
		DrawBox.QuestionQueue[LanguageID, drawID] = DrawBox.Shuffle<ValueTuple<string, string, string, string, string, string>>(DrawBox.QuestionQueue[LanguageID, drawID]);
	}

	public static Queue<T> Shuffle<T>(Queue<T> queue)
	{
		return new Queue<T>(queue.OrderBy((T a) => Guid.NewGuid()).ToList<T>());
	}

	public static string GetInputText_fast(ValueTuple<string, string, string, string, string, string> _texts, SystemLanguage _Language)
	{
		if (_Language == SystemLanguage.English || _Language == SystemLanguage.Japanese /* 한글패치 */ || _Language == SystemLanguage.Korean)
		{
			return DrawBox.mRomajiData.constructQuestionSpelling(DrawBox.mRomajiData.separateQuestionToWords(DrawBox.GetInputText(_texts, _Language)), 0);
		}
		if (_Language != SystemLanguage.ChineseSimplified)
		{
			return "";
		}
		return _texts.Item2;
	}

	public static string GetInputText(ValueTuple<string, string, string, string, string, string> _texts, SystemLanguage _Language)
	{
		string item = _texts.Item2;
		if (_Language == SystemLanguage.English /* 한글패치 */ || _Language == SystemLanguage.Korean)
		{
			return DrawBox.Removes(item);
		}
		if (_Language == SystemLanguage.Japanese)
		{
			return DrawBox.KataKana2Hiragana(DrawBox.Removes(item));
		}
		if (_Language != SystemLanguage.ChineseSimplified)
		{
			return "まだ未設定";
		}
		int num = SettingsManager.settingValues[4];
		return DrawBox.GenerateDual_fromEffects(_texts, num);
	}

	public static string Removes(string input)
	{
		input = input.Replace(" ", "").Replace("\u3000", "").Replace("\u309c", "");
		return input;
	}

	public static string RemoveAccents(string input)
	{
		input = input.Replace("ü", "v").Replace("ǖ", "v").Replace("ǘ", "v")
			.Replace("ǚ", "v")
			.Replace("ǜ", "v");
		string text = input.Normalize(NormalizationForm.FormD);
		return new Regex("\\p{M}").Replace(text, string.Empty);
	}

	public static string KataKana2Hiragana(string katakana)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in katakana)
		{
			if (c >= 'ァ' && c <= 'ン')
			{
				char c2 = c - '`';
				stringBuilder.Append(c2);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static Dictionary<string, string> GetInitialMap(int mode)
	{
		if (mode - 1 <= 1)
		{
			return DrawBox.initialMap_Microsoft_Sogou;
		}
		return null;
	}

	private static Dictionary<string, string> GetFinalMap(int mode)
	{
		if (mode == 1)
		{
			return DrawBox.finalMap_Microsoft;
		}
		if (mode != 2)
		{
			return null;
		}
		return DrawBox.finalMap_Sogou;
	}

	public static string GenerateDual_fromEffects(ValueTuple<string, string, string, string, string, string> _texts, int mode)
	{
		switch (mode)
		{
		case 0:
			return DrawBox.ReplaceTag(_texts.Item2);
		case 1:
			return DrawBox.ReplaceTag(_texts.Item5);
		case 2:
			return DrawBox.ReplaceTag(_texts.Item6);
		default:
			return "ERROR";
		}
	}

	private static string ReplaceTag(string _txx)
	{
		return _txx.Replace(">", "").Replace("<", "");
	}

	public static string GenerateDual(string pinyin, int mode)
	{
		if (mode == 0)
		{
			return pinyin;
		}
		string text = "";
		string text2 = pinyin;
		while (pinyin.Length > 0)
		{
			string text3 = "";
			string text4 = "";
			foreach (KeyValuePair<string, string> keyValuePair in DrawBox.GetInitialMap(mode))
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in DrawBox.GetFinalMap(mode))
				{
					string text5 = keyValuePair.Key + keyValuePair2.Key;
					if (pinyin.StartsWith(text5) && text5.Length > text3.Length)
					{
						text3 = text5;
						text4 = keyValuePair.Value + keyValuePair2.Value;
					}
				}
			}
			if (text3.Length == 0)
			{
				return text2;
			}
			text += text4;
			pinyin = pinyin.Substring(text3.Length);
		}
		return text;
	}

	private static string ApplyFunctionToTags(string input, Func<string, string> func)
	{
		return Regex.Replace(input, "<([^>]+)>", delegate(Match match)
		{
			string value = match.Groups[1].Value;
			return "<" + func(value) + ">";
		});
	}

	public static string ApplyFunctionToNonTaggedParts(string input, Func<string, string> func)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		int num = 0;
		foreach (char c in input)
		{
			if (c == '<')
			{
				if (num == 0 && stringBuilder2.Length > 0)
				{
					stringBuilder.Append(func(stringBuilder2.ToString()));
					stringBuilder2.Clear();
				}
				num++;
				if (num > 0)
				{
					stringBuilder3.Append(c);
				}
			}
			else if (c == '>')
			{
				num--;
				stringBuilder3.Append(c);
				if (num == 0)
				{
					string text = stringBuilder3.ToString();
					stringBuilder.Append(text.Substring(1, text.Length - 2));
					stringBuilder3.Clear();
				}
			}
			else if (num > 0)
			{
				stringBuilder3.Append(c);
			}
			else
			{
				stringBuilder2.Append(c);
			}
		}
		if (stringBuilder2.Length > 0)
		{
			stringBuilder.Append(func(stringBuilder2.ToString()));
		}
		return stringBuilder.ToString();
	}
}
