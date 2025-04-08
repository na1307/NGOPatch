namespace TypingGameJP;

public readonly record struct KeyInfo(char char1, char? char2 = null, char? char3 = null)
{
    public bool IsMatch(char c)
    {
        if (char1 == c) return true;
        if (char2.HasValue && char2.Value == c) return true;
        if (char3.HasValue && char3.Value == c) return true;
        return false;
    }
}
