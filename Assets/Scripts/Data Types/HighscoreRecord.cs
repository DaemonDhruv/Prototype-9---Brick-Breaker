using System;

[Serializable]
public class HighscoreRecord
{
    public string playerName;
    public int score;

    public HighscoreRecord(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}
