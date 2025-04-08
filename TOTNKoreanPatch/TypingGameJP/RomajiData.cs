using System;
using System.Collections.Generic;
using System.Text;

namespace TypingGameJP
{
	public class RomajiData
	{
		private Dictionary<string, List<string>> mRomajiList = new Dictionary<string, List<string>>();

		public RomajiData()
		{
			this.setRomaji("か", "ka");
			this.setRomaji("き", "ki");
			this.setRomaji("く", "ku");
			this.setRomaji("け", "ke");
			this.setRomaji("こ", "ko");
			this.setRomaji("さ", "sa");
			this.setRomaji("し", "si");
			this.setRomaji("し", "shi");
			this.setRomaji("す", "su");
			this.setRomaji("せ", "se");
			this.setRomaji("そ", "so");
			this.setRomaji("た", "ta");
			this.setRomaji("ち", "ti");
			this.setRomaji("ち", "chi");
			this.setRomaji("つ", "tu");
			this.setRomaji("つ", "tsu");
			this.setRomaji("て", "te");
			this.setRomaji("と", "to");
			this.setRomaji("な", "na");
			this.setRomaji("に", "ni");
			this.setRomaji("ぬ", "nu");
			this.setRomaji("ね", "ne");
			this.setRomaji("の", "no");
			this.setRomaji("は", "ha");
			this.setRomaji("ひ", "hi");
			this.setRomaji("ふ", "hu");
			this.setRomaji("ふ", "fu");
			this.setRomaji("へ", "he");
			this.setRomaji("ほ", "ho");
			this.setRomaji("ま", "ma");
			this.setRomaji("み", "mi");
			this.setRomaji("む", "mu");
			this.setRomaji("め", "me");
			this.setRomaji("も", "mo");
			this.setRomaji("や", "ya");
			this.setRomaji("ゐ", "yi");
			this.setRomaji("ゆ", "yu");
			this.setRomaji("ゑ", "ye");
			this.setRomaji("よ", "yo");
			this.setRomaji("ら", "ra");
			this.setRomaji("り", "ri");
			this.setRomaji("る", "ru");
			this.setRomaji("れ", "re");
			this.setRomaji("ろ", "ro");
			this.setRomaji("わ", "wa");
			this.setRomaji("を", "wo");
			this.setRomaji("か", "ca");
			this.setRomaji("し", "ci");
			this.setRomaji("く", "cu");
			this.setRomaji("せ", "ce");
			this.setRomaji("こ", "co");
			this.setRomaji("ゔ", "vu");
			this.setRomaji("が", "ga");
			this.setRomaji("ぎ", "gi");
			this.setRomaji("ぐ", "gu");
			this.setRomaji("げ", "ge");
			this.setRomaji("ご", "go");
			this.setRomaji("ざ", "za");
			this.setRomaji("じ", "zi");
			this.setRomaji("じ", "ji");
			this.setRomaji("ず", "zu");
			this.setRomaji("ぜ", "ze");
			this.setRomaji("ぞ", "zo");
			this.setRomaji("だ", "da");
			this.setRomaji("ぢ", "di");
			this.setRomaji("づ", "du");
			this.setRomaji("で", "de");
			this.setRomaji("ど", "do");
			this.setRomaji("ば", "ba");
			this.setRomaji("び", "bi");
			this.setRomaji("ぶ", "bu");
			this.setRomaji("べ", "be");
			this.setRomaji("ぼ", "bo");
			this.setRomaji("ぱ", "pa");
			this.setRomaji("ぴ", "pi");
			this.setRomaji("ぷ", "pu");
			this.setRomaji("ぺ", "pe");
			this.setRomaji("ぽ", "po");
			this.setRomaji("いぇ", "ye");
			this.setRomaji("うぁ", "wha");
			this.setRomaji("うぃ", "whi");
			this.setRomaji("うぇ", "whe");
			this.setRomaji("うぉ", "who");
			this.setRomaji("うぁ", "uxa");
			this.setRomaji("うぁ", "ula");
			this.setRomaji("うぃ", "wi");
			this.setRomaji("うぃ", "uxi");
			this.setRomaji("うぃ", "uli");
			this.setRomaji("うぇ", "we");
			this.setRomaji("うぇ", "uxe");
			this.setRomaji("うぇ", "ule");
			this.setRomaji("うぉ", "uxo");
			this.setRomaji("うぉ", "ulo");
			this.setRomaji("ゔぁ", "va");
			this.setRomaji("ゔぃ", "vi");
			this.setRomaji("ゔぇ", "ve");
			this.setRomaji("ゔぉ", "vo");
			this.setRomaji("ゔぁ", "vuxa");
			this.setRomaji("ゔぃ", "vuxi");
			this.setRomaji("ゔぇ", "vuxe");
			this.setRomaji("ゔぉ", "vuxo");
			this.setRomaji("ゔぁ", "vula");
			this.setRomaji("ゔぃ", "vuli");
			this.setRomaji("ゔぇ", "vule");
			this.setRomaji("ゔぉ", "vulo");
			this.setRomaji("きゃ", "kya");
			this.setRomaji("きゅ", "kyu");
			this.setRomaji("きょ", "kyo");
			this.setRomaji("きゃ", "kixya");
			this.setRomaji("きゅ", "kixyu");
			this.setRomaji("きょ", "kixyo");
			this.setRomaji("きゃ", "kilya");
			this.setRomaji("きゅ", "kilyu");
			this.setRomaji("きょ", "kilyo");
			this.setRomaji("にゃ", "nya");
			this.setRomaji("にゅ", "nyu");
			this.setRomaji("にょ", "nyo");
			this.setRomaji("にゃ", "nixya");
			this.setRomaji("にゅ", "nixyu");
			this.setRomaji("にょ", "nixyo");
			this.setRomaji("にゃ", "nilya");
			this.setRomaji("にゅ", "nilyu");
			this.setRomaji("にょ", "nilyo");
			this.setRomaji("ひゃ", "hya");
			this.setRomaji("ひゅ", "hyu");
			this.setRomaji("ひょ", "hyo");
			this.setRomaji("ひゃ", "hixya");
			this.setRomaji("ひゅ", "hixyu");
			this.setRomaji("ひょ", "hixyo");
			this.setRomaji("ひゃ", "hilya");
			this.setRomaji("ひゅ", "hilyu");
			this.setRomaji("ひょ", "hilyo");
			this.setRomaji("ふぁ", "fa");
			this.setRomaji("ふぁ", "fuxa");
			this.setRomaji("ふぁ", "huxa");
			this.setRomaji("ふぁ", "fula");
			this.setRomaji("ふぁ", "hula");
			this.setRomaji("ふぃ", "fi");
			this.setRomaji("ふぃ", "fuxi");
			this.setRomaji("ふぃ", "huxi");
			this.setRomaji("ふぃ", "fuli");
			this.setRomaji("ふぃ", "huli");
			this.setRomaji("ふゅ", "fyu");
			this.setRomaji("ふゅ", "fuxyu");
			this.setRomaji("ふゅ", "huxyu");
			this.setRomaji("ふゅ", "fulyu");
			this.setRomaji("ふゅ", "hulyu");
			this.setRomaji("ふぇ", "fe");
			this.setRomaji("ふぇ", "fuxe");
			this.setRomaji("ふぇ", "huxe");
			this.setRomaji("ふぇ", "fule");
			this.setRomaji("ふぇ", "hule");
			this.setRomaji("ふぉ", "fo");
			this.setRomaji("ふぉ", "fuxo");
			this.setRomaji("ふぉ", "huxo");
			this.setRomaji("ふぉ", "fulo");
			this.setRomaji("ふぉ", "hulo");
			this.setRomaji("みゃ", "mya");
			this.setRomaji("みゅ", "myu");
			this.setRomaji("みょ", "myo");
			this.setRomaji("みゃ", "mixya");
			this.setRomaji("みゅ", "mixyu");
			this.setRomaji("みょ", "mixyo");
			this.setRomaji("みゃ", "milya");
			this.setRomaji("みゅ", "milyu");
			this.setRomaji("みょ", "milyo");
			this.setRomaji("りゃ", "rya");
			this.setRomaji("りゅ", "ryu");
			this.setRomaji("りょ", "ryo");
			this.setRomaji("りゃ", "rixya");
			this.setRomaji("りゅ", "rixyu");
			this.setRomaji("りょ", "rixyo");
			this.setRomaji("りゃ", "rilya");
			this.setRomaji("りゅ", "rilyu");
			this.setRomaji("りょ", "rilyo");
			this.setRomaji("ぎゃ", "gya");
			this.setRomaji("ぎゅ", "gyu");
			this.setRomaji("ぎょ", "gyo");
			this.setRomaji("ぎゃ", "gixya");
			this.setRomaji("ぎゅ", "gixyu");
			this.setRomaji("ぎょ", "gixyo");
			this.setRomaji("ぎゃ", "gilya");
			this.setRomaji("ぎゅ", "gilyu");
			this.setRomaji("ぎょ", "gilyo");
			this.setRomaji("じゃ", "ja");
			this.setRomaji("じゅ", "ju");
			this.setRomaji("じょ", "jo");
			this.setRomaji("じゃ", "zya");
			this.setRomaji("じゅ", "zyu");
			this.setRomaji("じょ", "zyo");
			this.setRomaji("じゃ", "jixya");
			this.setRomaji("じゅ", "jixyu");
			this.setRomaji("じょ", "jixyo");
			this.setRomaji("じゃ", "zixya");
			this.setRomaji("じゅ", "zixyu");
			this.setRomaji("じょ", "zixyo");
			this.setRomaji("じゃ", "jilya");
			this.setRomaji("じゅ", "jilyu");
			this.setRomaji("じょ", "jilyo");
			this.setRomaji("じゃ", "zilya");
			this.setRomaji("じゅ", "zilyu");
			this.setRomaji("じょ", "zilyo");
			this.setRomaji("じゃ", "jya");
			this.setRomaji("じぃ", "jyi");
			this.setRomaji("じゅ", "jyu");
			this.setRomaji("じょ", "jyo");
			this.setRomaji("じぇ", "je");
			this.setRomaji("じぇ", "zye");
			this.setRomaji("じぇ", "jixe");
			this.setRomaji("じぇ", "jile");
			this.setRomaji("ぢゃ", "dya");
			this.setRomaji("ぢゅ", "dyu");
			this.setRomaji("ぢょ", "dyo");
			this.setRomaji("ぢゃ", "dixya");
			this.setRomaji("ぢゅ", "dixyu");
			this.setRomaji("ぢょ", "dixyo");
			this.setRomaji("ぢゃ", "dilya");
			this.setRomaji("ぢゅ", "dilyu");
			this.setRomaji("ぢょ", "dilyo");
			this.setRomaji("どぅ", "dwu");
			this.setRomaji("どぅ", "doxu");
			this.setRomaji("どぅ", "dolu");
			this.setRomaji("びゃ", "bya");
			this.setRomaji("びゅ", "byu");
			this.setRomaji("びょ", "byo");
			this.setRomaji("びゃ", "bixya");
			this.setRomaji("びゅ", "bixyu");
			this.setRomaji("びょ", "bixyo");
			this.setRomaji("びゃ", "bilya");
			this.setRomaji("びゅ", "bilyu");
			this.setRomaji("びょ", "bilyo");
			this.setRomaji("ぴゃ", "pya");
			this.setRomaji("ぴゅ", "pyu");
			this.setRomaji("ぴょ", "pyo");
			this.setRomaji("ぴゃ", "pixya");
			this.setRomaji("ぴゅ", "pixyu");
			this.setRomaji("ぴょ", "pixyo");
			this.setRomaji("ぴゃ", "pilya");
			this.setRomaji("ぴゅ", "pilyu");
			this.setRomaji("ぴょ", "pilyo");
			this.setRomaji("でゃ", "dha");
			this.setRomaji("でぃ", "dhi");
			this.setRomaji("でゅ", "dhu");
			this.setRomaji("でぇ", "dhe");
			this.setRomaji("でょ", "dho");
			this.setRomaji("でゃ", "dexya");
			this.setRomaji("でぃ", "dexi");
			this.setRomaji("でゅ", "dexyu");
			this.setRomaji("でぇ", "dexe");
			this.setRomaji("でょ", "dexyo");
			this.setRomaji("でゃ", "delya");
			this.setRomaji("でぃ", "deli");
			this.setRomaji("でゅ", "delyu");
			this.setRomaji("でぇ", "dele");
			this.setRomaji("でょ", "delyo");
			this.setRomaji("つぁ", "tsa");
			this.setRomaji("つぃ", "tsi");
			this.setRomaji("つぇ", "tse");
			this.setRomaji("つぉ", "tso");
			this.setRomaji("つぁ", "tuxa");
			this.setRomaji("つぃ", "tuxi");
			this.setRomaji("つぇ", "tuxe");
			this.setRomaji("つぉ", "tuxo");
			this.setRomaji("つぁ", "tsuxa");
			this.setRomaji("つぃ", "tsuxi");
			this.setRomaji("つぇ", "tsuxe");
			this.setRomaji("つぉ", "tsuxo");
			this.setRomaji("つぁ", "tula");
			this.setRomaji("つぃ", "tuli");
			this.setRomaji("つぇ", "tule");
			this.setRomaji("つぉ", "tulo");
			this.setRomaji("つぁ", "tsula");
			this.setRomaji("つぃ", "tsuli");
			this.setRomaji("つぇ", "tsule");
			this.setRomaji("つぉ", "tsulo");
			this.setRomaji("てゃ", "tha");
			this.setRomaji("てぃ", "thi");
			this.setRomaji("てゅ", "thu");
			this.setRomaji("てぇ", "the");
			this.setRomaji("てょ", "tho");
			this.setRomaji("てゃ", "texya");
			this.setRomaji("てぃ", "texi");
			this.setRomaji("てゅ", "texyu");
			this.setRomaji("てぇ", "texe");
			this.setRomaji("てょ", "texyo");
			this.setRomaji("てゃ", "telya");
			this.setRomaji("てぃ", "teli");
			this.setRomaji("てゅ", "telyu");
			this.setRomaji("てぇ", "tele");
			this.setRomaji("てょ", "telyo");
			this.setRomaji("とぁ", "twa");
			this.setRomaji("とぃ", "twi");
			this.setRomaji("とぅ", "twu");
			this.setRomaji("とぇ", "twe");
			this.setRomaji("とぉ", "two");
			this.setRomaji("とぁ", "toxa");
			this.setRomaji("とぃ", "toxi");
			this.setRomaji("とぅ", "toxu");
			this.setRomaji("とぇ", "toxe");
			this.setRomaji("とぉ", "toxo");
			this.setRomaji("とぁ", "tola");
			this.setRomaji("とぃ", "toli");
			this.setRomaji("とぅ", "tolu");
			this.setRomaji("とぇ", "tole");
			this.setRomaji("とぉ", "tolo");
			this.setRomaji("しゃ", "sya");
			this.setRomaji("しゅ", "syu");
			this.setRomaji("しぇ", "sye");
			this.setRomaji("しょ", "syo");
			this.setRomaji("しゃ", "sha");
			this.setRomaji("しゅ", "shu");
			this.setRomaji("しぇ", "she");
			this.setRomaji("しょ", "sho");
			this.setRomaji("しゃ", "sixya");
			this.setRomaji("しゅ", "sixyu");
			this.setRomaji("しぇ", "sixe");
			this.setRomaji("しょ", "sixyo");
			this.setRomaji("しゃ", "shixya");
			this.setRomaji("しゅ", "shixyu");
			this.setRomaji("しぇ", "shixe");
			this.setRomaji("しょ", "shixyo");
			this.setRomaji("しゃ", "silya");
			this.setRomaji("しゅ", "silyu");
			this.setRomaji("しぇ", "sile");
			this.setRomaji("しょ", "silyo");
			this.setRomaji("しゃ", "shilya");
			this.setRomaji("しゅ", "shilyu");
			this.setRomaji("しぇ", "shile");
			this.setRomaji("しょ", "shilyo");
			this.setRomaji("ちゃ", "tya");
			this.setRomaji("ちゅ", "tyu");
			this.setRomaji("ちぇ", "tye");
			this.setRomaji("ちょ", "tyo");
			this.setRomaji("ちゃ", "cha");
			this.setRomaji("ちゅ", "chu");
			this.setRomaji("ちぇ", "che");
			this.setRomaji("ちょ", "cho");
			this.setRomaji("ちゃ", "cya");
			this.setRomaji("ちぃ", "cyi");
			this.setRomaji("ちゅ", "cyu");
			this.setRomaji("ちぇ", "cye");
			this.setRomaji("ちょ", "cyo");
			this.setRomaji("ちゃ", "tixya");
			this.setRomaji("ちゅ", "tixyu");
			this.setRomaji("ちぇ", "tixe");
			this.setRomaji("ちょ", "tixyo");
			this.setRomaji("ちゃ", "chixya");
			this.setRomaji("ちゅ", "chixyu");
			this.setRomaji("ちぇ", "chixe");
			this.setRomaji("ちょ", "chixyo");
			this.setRomaji("ちゃ", "tilya");
			this.setRomaji("ちゅ", "tilyu");
			this.setRomaji("ちぇ", "tile");
			this.setRomaji("ちょ", "tilyo");
			this.setRomaji("ちゃ", "chilya");
			this.setRomaji("ちゅ", "chilyu");
			this.setRomaji("ちぇ", "chile");
			this.setRomaji("ちょ", "chilyo");
			this.setRomaji("くぁ", "qa");
			this.setRomaji("くぃ", "qi");
			this.setRomaji("くぇ", "qe");
			this.setRomaji("くぉ", "qo");
			foreach (KeyValuePair<string, List<string>> keyValuePair in new Dictionary<string, List<string>>(this.mRomajiList))
			{
				foreach (string text in keyValuePair.Value)
				{
					this.setRomaji("っ" + keyValuePair.Key, text.Substring(0, 1) + text);
					this.setRomaji("っ" + keyValuePair.Key, "xtu" + text);
					this.setRomaji("っ" + keyValuePair.Key, "ltu" + text);
					this.setRomaji("っ" + keyValuePair.Key, "xtsu" + text);
					this.setRomaji("っ" + keyValuePair.Key, "ltsu" + text);
					this.setRomaji("ん" + keyValuePair.Key, "nn" + text);
					this.setRomaji("ん" + keyValuePair.Key, "n" + text);
				}
			}
			this.setRomaji("あ", "a");
			this.setRomaji("い", "i");
			this.setRomaji("い", "yi");
			this.setRomaji("う", "u");
			this.setRomaji("う", "wu");
			this.setRomaji("う", "whu");
			this.setRomaji("え", "e");
			this.setRomaji("お", "o");
			this.setRomaji("ぁ", "xa");
			this.setRomaji("ぃ", "xi");
			this.setRomaji("ぅ", "xu");
			this.setRomaji("ぇ", "xe");
			this.setRomaji("ぉ", "xo");
			this.setRomaji("ぁ", "la");
			this.setRomaji("ぃ", "li");
			this.setRomaji("ぅ", "lu");
			this.setRomaji("ぇ", "le");
			this.setRomaji("ぉ", "lo");
			this.setRomaji("ぃ", "lyi");
			this.setRomaji("ぇ", "lye");
			this.setRomaji("っ", "xtu");
			this.setRomaji("っ", "xtsu");
			this.setRomaji("っ", "ltu");
			this.setRomaji("っ", "ltsu");
			this.setRomaji("ー", "-");
			this.setRomaji("ん", "nn");
			this.setRomaji("ん", "xn");
			this.setRomaji("a", "a");
			this.setRomaji("b", "b");
			this.setRomaji("c", "c");
			this.setRomaji("d", "d");
			this.setRomaji("e", "e");
			this.setRomaji("f", "f");
			this.setRomaji("g", "g");
			this.setRomaji("h", "h");
			this.setRomaji("i", "i");
			this.setRomaji("j", "j");
			this.setRomaji("k", "k");
			this.setRomaji("l", "l");
			this.setRomaji("m", "m");
			this.setRomaji("n", "n");
			this.setRomaji("o", "o");
			this.setRomaji("p", "p");
			this.setRomaji("q", "q");
			this.setRomaji("r", "r");
			this.setRomaji("s", "s");
			this.setRomaji("t", "t");
			this.setRomaji("u", "u");
			this.setRomaji("v", "v");
			this.setRomaji("w", "w");
			this.setRomaji("x", "x");
			this.setRomaji("y", "y");
			this.setRomaji("z", "z");
			this.setRomaji("A", "a");
			this.setRomaji("B", "b");
			this.setRomaji("C", "c");
			this.setRomaji("D", "d");
			this.setRomaji("E", "e");
			this.setRomaji("F", "f");
			this.setRomaji("G", "g");
			this.setRomaji("H", "h");
			this.setRomaji("I", "i");
			this.setRomaji("J", "j");
			this.setRomaji("K", "k");
			this.setRomaji("L", "l");
			this.setRomaji("M", "m");
			this.setRomaji("N", "n");
			this.setRomaji("O", "o");
			this.setRomaji("P", "p");
			this.setRomaji("Q", "q");
			this.setRomaji("R", "r");
			this.setRomaji("S", "s");
			this.setRomaji("T", "t");
			this.setRomaji("U", "u");
			this.setRomaji("V", "v");
			this.setRomaji("W", "w");
			this.setRomaji("X", "x");
			this.setRomaji("Y", "y");
			this.setRomaji("Z", "z");
			this.setRomaji("0", "0");
			this.setRomaji("1", "1");
			this.setRomaji("2", "2");
			this.setRomaji("3", "3");
			this.setRomaji("4", "4");
			this.setRomaji("5", "5");
			this.setRomaji("6", "6");
			this.setRomaji("7", "7");
			this.setRomaji("8", "8");
			this.setRomaji("9", "9");
			this.setRomaji(";", ";");
			// 한글패치
			this.setRomaji("ㄱ", "ㄱ");
			this.setRomaji("ㄳ", "ㄱㅅ");
			this.setRomaji("ㄲ", "ㄲ");
			this.setRomaji("ㄴ", "ㄴ");
			this.setRomaji("ㄵ", "ㄴㅈ");
			this.setRomaji("ㄶ", "ㄴㅎ");
			this.setRomaji("ㄷ", "ㄷ");
			this.setRomaji("ㄸ", "ㄸ");
			this.setRomaji("ㄹ", "ㄹ");
			this.setRomaji("ㄺ", "ㄹㄱ");
			this.setRomaji("ㄻ", "ㄹㅁ");
			this.setRomaji("ㄼ", "ㄹㅂ");
			this.setRomaji("ㄽ", "ㄹㅅ");
			this.setRomaji("ㄾ", "ㄹㅌ");
			this.setRomaji("ㄿ", "ㄹㅍ");
			this.setRomaji("ㅀ", "ㄹㅎ");
			this.setRomaji("ㅁ", "ㅁ");
			this.setRomaji("ㅂ", "ㅂ");
			this.setRomaji("ㅄ", "ㅂㅅ");
			this.setRomaji("ㅃ", "ㅃ");
			this.setRomaji("ㅅ", "ㅅ");
			this.setRomaji("ㅆ", "ㅆ");
			this.setRomaji("ㅇ", "ㅇ");
			this.setRomaji("ㅈ", "ㅈ");
			this.setRomaji("ㅊ", "ㅊ");
			this.setRomaji("ㅋ", "ㅋ");
			this.setRomaji("ㅌ", "ㅌ");
			this.setRomaji("ㅍ", "ㅍ");
			this.setRomaji("ㅎ", "ㅎ");
			this.setRomaji("ㅏ", "ㅏ");
			this.setRomaji("ㅐ", "ㅐ");
			this.setRomaji("ㅑ", "ㅑ");
			this.setRomaji("ㅒ", "ㅒ");
			this.setRomaji("ㅓ", "ㅓ");
			this.setRomaji("ㅔ", "ㅔ");
			this.setRomaji("ㅕ", "ㅕ");
			this.setRomaji("ㅖ", "ㅖ");
			this.setRomaji("ㅗ", "ㅗ");
			this.setRomaji("ㅘ", "ㅗㅏ");
			this.setRomaji("ㅙ", "ㅗㅐ");
			this.setRomaji("ㅚ", "ㅗㅣ");
			this.setRomaji("ㅛ", "ㅛ");
			this.setRomaji("ㅜ", "ㅜ");
			this.setRomaji("ㅝ", "ㅜㅓ");
			this.setRomaji("ㅞ", "ㅜㅔ");
			this.setRomaji("ㅟ", "ㅜㅣ");
			this.setRomaji("ㅠ", "ㅠ");
			this.setRomaji("ㅡ", "ㅡ");
			this.setRomaji("ㅢ", "ㅡㅣ");
			this.setRomaji("ㅣ", "ㅣ");
		}

		private void setRomaji(string letter, string spelling)
		{
			if (!this.mRomajiList.ContainsKey(letter))
			{
				this.mRomajiList.Add(letter, new List<string>());
			}
			this.mRomajiList[letter].Add(spelling);
		}

		public List<string> getRomajiList(string letter)
		{
			return this.mRomajiList[letter];
		}

		public string getFirstRomaji(string letter)
		{
			return this.mRomajiList[letter][0];
		}

		public List<string> separateQuestionToWords(string question)
		{
			List<string> list = new List<string>();
			List<char> list2 = new List<char>(new char[] { 'ぁ', 'ぃ', 'ぅ', 'ぇ', 'ぉ', 'ゃ', 'ゅ', 'ょ' });
			int i = 0;
			while (i < question.Length)
			{
				char c = question[i];
				if ((c != 'っ' && c != 'ん') || i >= question.Length - 2 || !list2.Contains(question[i + 2]))
				{
					goto IL_0083;
				}
				string text = question.Substring(i, 3);
				if (!this.mRomajiList.ContainsKey(text))
				{
					goto IL_0083;
				}
				list.Add(text);
				i += 2;
				IL_007D:
				i++;
				continue;
				IL_0083:
				if (i < question.Length - 1 && (c == 'っ' || c == 'ん' || list2.Contains(question[i + 1])))
				{
					string text2 = question.Substring(i, 2);
					if (this.mRomajiList.ContainsKey(text2))
					{
						list.Add(text2);
						i++;
						goto IL_007D;
					}
				}
				list.Add(c.ToString());
				goto IL_007D;
			}
			return list;
		}

		public string constructQuestionSpelling(List<string> separated, int start_index = 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = start_index;
			int count = separated.Count;
			while (i < count)
			{
				stringBuilder.Append(this.getFirstRomaji(separated[i]));
				i++;
			}
			return stringBuilder.ToString();
		}

		public bool isVowel(char c)
		{
			return c == 'あ' || c == 'い' || c == 'う' || c == 'え' || c == 'お';
		}
	}
}
