using System;

[Serializable]
public class Score
{
    public string namePlayer;
    public float score;

    public Score(string namePlayer, float score)
    {
        this.namePlayer = namePlayer;
        this.score = score;
    }
}