using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TypingGameJP
{
	public class TypingEngine : MonoBehaviour
	{
		private TMP_Text QuestionText;

		private TMP_Text QuestionKanaText;

		private TMP_Text QuestionENText;

		private TMP_Text QuestionNextText;

		private ValueTuple<string, string, string, string, string, string> mCurrentQuestion = new ValueTuple<string, string, string, string, string, string>("", "", "", "", "", "");

		private List<string> mQuestionSeparated;

		private int mCurrentLetterIndex;

		private List<string> mCurrentLetterSpellingSet;

		private string mCurrentSpelling = "";

		private string mLetterBuffer = "";

		private string mCurrentQuestionDone = "";

		private ValueTuple<string, string, string, string, string, string> mNextQuestion = new ValueTuple<string, string, string, string, string, string>("", "", "", "", "", "");

		private bool mWaitTyping;

		private Action OnLetterProceed;

		private Action OnLetterMissed;

		public const bool insertNakaguro = true;

		private RomajiData mRomajiData
		{
			get
			{
				return DrawBox.mRomajiData;
			}
		}

		public string GetCurrentQuestion()
		{
			return this.mCurrentQuestion.Item1;
		}

		public ValueTuple<string, string, string, string, string, string> GetCurrentQuestion_All()
		{
			return this.mCurrentQuestion;
		}

		public string GetCurrentQuestion_AddPoint()
		{
			return this.AddPoints(this.mCurrentQuestion.Item1);
		}

		public string GetCurrentSpelling()
		{
			return this.mCurrentQuestionDone;
		}

		public string GetCurrentExplain()
		{
			return this.mCurrentQuestion.Item4;
		}

		public string GetNextQuestion()
		{
			return this.mNextQuestion.Item1;
		}

		public string GetNextQuestion_AddPoint()
		{
			return this.AddPoints(this.mNextQuestion.Item1);
		}

		public void setupTextFields(TMP_Text question, TMP_Text kana, TMP_Text en, TMP_Text next)
		{
			this.QuestionText = question;
			this.QuestionKanaText = kana;
			this.QuestionENText = en;
			this.QuestionNextText = next;
		}

		public void setOnLetterProceed(Action callback)
		{
			this.OnLetterProceed = callback;
		}

		public void setOnLetterMissed(Action callback)
		{
			this.OnLetterMissed = callback;
		}

		public void doQuestionAndSetNext(SystemLanguage Language, bool isNotSetQuestionText = false)
		{
			this.doQuestion(Language, isNotSetQuestionText);
			this.setNextQuestion(TypingEngine.QuestionMode.All);
		}

		public void doQuestion(SystemLanguage Language, bool isNotSetQuestionText = false)
		{
			this.mCurrentQuestion = this.mNextQuestion;
			string inputText = DrawBox.GetInputText(this.mNextQuestion, Language);
			this.mQuestionSeparated = this.mRomajiData.separateQuestionToWords(inputText);
			this.mCurrentQuestionDone = "";
			if (!isNotSetQuestionText)
			{
				this.QuestionText.SetText(this.mCurrentQuestion.Item1, true);
			}
			if (this.QuestionKanaText)
			{
				if (Language != SystemLanguage.English && Language != SystemLanguage.Japanese /* 한글패치 */ && Language != SystemLanguage.Korean)
				{
					if (Language == SystemLanguage.ChineseSimplified)
					{
						this.QuestionKanaText.SetText(this.mNextQuestion.Item2.Replace("<", "").Replace(">", ""), true);
					}
				}
				else
				{
					this.QuestionKanaText.SetText(this.mNextQuestion.Item2, true);
				}
			}
			if (this.QuestionENText)
			{
				this.QuestionENText.SetText(this.mRomajiData.constructQuestionSpelling(this.mQuestionSeparated, 0), true);
			}
			this.updateCurrentLetter(0);
			this.mWaitTyping = true;
		}

		private string AddPoints(string _txts)
		{
			return _txts + "?";
		}

		public string RemoveEnd(string str, int len)
		{
			if (str.Length < len)
			{
				return string.Empty;
			}
			return str.Remove(str.Length - len);
		}

		public void setNextQuestion(TypingEngine.QuestionMode _mode = TypingEngine.QuestionMode.All)
		{
			this.mNextQuestion = DrawBox.Draw(_mode);
			if (this.QuestionNextText)
			{
				this.QuestionNextText.SetText(this.mNextQuestion.Item1, true);
			}
		}

		public void Finish()
		{
			this.mWaitTyping = false;
		}

		public bool isQuestionDone()
		{
			return this.mCurrentLetterIndex >= this.mQuestionSeparated.Count;
		}

		private void OnGUI()
		{
			if (!this.mWaitTyping || this.mCurrentLetterSpellingSet == null)
			{
				return;
			}
			Event current = Event.current;
			if (current.type == EventType.KeyDown && current.keyCode != KeyCode.None)
			{
				if (current.keyCode == KeyCode.Backspace)
				{
					this.mLetterBuffer = "";
					this.setQuestionENText(true);
					return;
				}
				// 한글패치
				KeyInfo letterByKeycode = this.getLetterByKeycode(current.keyCode);
				if (letterByKeycode.char3 != null && this.mCurrentLetterSpellingSet.Any((string v) => v.Contains(letterByKeycode.char3.Value)))
				{
					this.mLetterBuffer += letterByKeycode.char3.Value.ToString();
				}
				else if (letterByKeycode.char2 != null && this.mCurrentLetterSpellingSet.Any((string v) => v.Contains(letterByKeycode.char2.Value)))
				{
					this.mLetterBuffer += letterByKeycode.char2.Value.ToString();
				}
				else
				{
					this.mLetterBuffer += letterByKeycode.char1.ToString();
				}
				foreach (string text in this.mCurrentLetterSpellingSet)
				{
					if (text.StartsWith(this.mLetterBuffer))
					{
						if (text == this.mLetterBuffer)
						{
							this.mCurrentQuestionDone += text;
							this.updateCurrentLetter(this.mCurrentLetterIndex + 1);
							this.setQuestionENText(true);
						}
						else
						{
							this.mCurrentSpelling = text;
							this.setQuestionENText(false);
						}
						Action onLetterProceed = this.OnLetterProceed;
						if (onLetterProceed == null)
						{
							return;
						}
						onLetterProceed();
						return;
					}
				}
				this.mLetterBuffer = this.mLetterBuffer.Substring(0, this.mLetterBuffer.Length - 1);
				Action onLetterMissed = this.OnLetterMissed;
				if (onLetterMissed == null)
				{
					return;
				}
				onLetterMissed();
			}
		}

		private void updateCurrentLetter(int letter_index)
		{
			this.mCurrentLetterIndex = letter_index;
			if (this.mCurrentLetterIndex < this.mQuestionSeparated.Count)
			{
				this.mCurrentLetterSpellingSet = this.mRomajiData.getRomajiList(this.mQuestionSeparated[this.mCurrentLetterIndex]);
			}
			else
			{
				this.mCurrentLetterSpellingSet = null;
			}
			this.mLetterBuffer = "";
		}

		private void setQuestionENText(bool is_complete)
		{
			if (is_complete)
			{
				if (this.QuestionENText)
				{
					this.QuestionENText.SetText("<color=#333333>" + this.mCurrentQuestionDone + "</color>" + this.mRomajiData.constructQuestionSpelling(this.mQuestionSeparated, this.mCurrentLetterIndex), true);
					return;
				}
			}
			else if (this.QuestionENText)
			{
				this.QuestionENText.SetText(string.Concat(new string[]
				{
					"<color=#333333>",
					this.mCurrentQuestionDone,
					this.mLetterBuffer,
					"</color>",
					this.mCurrentSpelling.Substring(this.mLetterBuffer.Length),
					this.mRomajiData.constructQuestionSpelling(this.mQuestionSeparated, this.mCurrentLetterIndex + 1)
				}), true);
			}
		}

		private KeyInfo getLetterByKeycode(KeyCode code)
		{
			switch (code)
			{
			case KeyCode.Minus:
				return new KeyInfo('-', null, null);
			case KeyCode.Period:
			case KeyCode.Slash:
			case KeyCode.Colon:
			case KeyCode.Less:
				break;
			case KeyCode.Alpha0:
				return new KeyInfo('0', null, null);
			case KeyCode.Alpha1:
				return new KeyInfo('1', null, null);
			case KeyCode.Alpha2:
				return new KeyInfo('2', null, null);
			case KeyCode.Alpha3:
				return new KeyInfo('3', null, null);
			case KeyCode.Alpha4:
				return new KeyInfo('4', null, null);
			case KeyCode.Alpha5:
				return new KeyInfo('5', null, null);
			case KeyCode.Alpha6:
				return new KeyInfo('6', null, null);
			case KeyCode.Alpha7:
				return new KeyInfo('7', null, null);
			case KeyCode.Alpha8:
				return new KeyInfo('8', null, null);
			case KeyCode.Alpha9:
				return new KeyInfo('9', null, null);
			case KeyCode.Semicolon:
				return new KeyInfo(';', null, null);
			case KeyCode.Equals:
				return new KeyInfo(';', null, null);
			default:
				switch (code)
				{
				case KeyCode.A:
					return new KeyInfo('a', new char?('ㅁ'), null);
				case KeyCode.B:
					return new KeyInfo('b', new char?('ㅠ'), null);
				case KeyCode.C:
					return new KeyInfo('c', new char?('ㅊ'), null);
				case KeyCode.D:
					return new KeyInfo('d', new char?('ㅇ'), null);
				case KeyCode.E:
					return new KeyInfo('e', new char?('ㄷ'), new char?('ㄸ'));
				case KeyCode.F:
					return new KeyInfo('f', new char?('ㄹ'), null);
				case KeyCode.G:
					return new KeyInfo('g', new char?('ㅎ'), null);
				case KeyCode.H:
					return new KeyInfo('h', new char?('ㅗ'), null);
				case KeyCode.I:
					return new KeyInfo('i', new char?('ㅑ'), null);
				case KeyCode.J:
					return new KeyInfo('j', new char?('ㅓ'), null);
				case KeyCode.K:
					return new KeyInfo('k', new char?('ㅏ'), null);
				case KeyCode.L:
					return new KeyInfo('l', new char?('ㅣ'), null);
				case KeyCode.M:
					return new KeyInfo('m', new char?('ㅡ'), null);
				case KeyCode.N:
					return new KeyInfo('n', new char?('ㅜ'), null);
				case KeyCode.O:
					return new KeyInfo('o', new char?('ㅐ'), new char?('ㅒ'));
				case KeyCode.P:
					return new KeyInfo('p', new char?('ㅔ'), new char?('ㅖ'));
				case KeyCode.Q:
					return new KeyInfo('q', new char?('ㅂ'), new char?('ㅃ'));
				case KeyCode.R:
					return new KeyInfo('r', new char?('ㄱ'), new char?('ㄲ'));
				case KeyCode.S:
					return new KeyInfo('s', new char?('ㄴ'), null);
				case KeyCode.T:
					return new KeyInfo('t', new char?('ㅅ'), new char?('ㅆ'));
				case KeyCode.U:
					return new KeyInfo('u', new char?('ㅕ'), null);
				case KeyCode.V:
					return new KeyInfo('v', new char?('ㅍ'), null);
				case KeyCode.W:
					return new KeyInfo('w', new char?('ㅈ'), new char?('ㅉ'));
				case KeyCode.X:
					return new KeyInfo('x', new char?('ㅌ'), null);
				case KeyCode.Y:
					return new KeyInfo('y', new char?('ㅛ'), null);
				case KeyCode.Z:
					return new KeyInfo('z', new char?('ㅋ'), null);
				default:
					switch (code)
					{
					case KeyCode.Keypad0:
						return new KeyInfo('0', null, null);
					case KeyCode.Keypad1:
						return new KeyInfo('1', null, null);
					case KeyCode.Keypad2:
						return new KeyInfo('2', null, null);
					case KeyCode.Keypad3:
						return new KeyInfo('3', null, null);
					case KeyCode.Keypad4:
						return new KeyInfo('4', null, null);
					case KeyCode.Keypad5:
						return new KeyInfo('5', null, null);
					case KeyCode.Keypad6:
						return new KeyInfo('6', null, null);
					case KeyCode.Keypad7:
						return new KeyInfo('7', null, null);
					case KeyCode.Keypad8:
						return new KeyInfo('8', null, null);
					case KeyCode.Keypad9:
						return new KeyInfo('9', null, null);
					}
					break;
				}
				break;
			}
			return new KeyInfo(' ', null, null);
		}

		public enum QuestionMode
		{
			All,
			Short,
			Long
		}
	}
}
