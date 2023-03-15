using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ScoreUi : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.namePlayer.text = scores[i].namePlayer;
            row.score.text = scores[i].score.ToString();
        }
    }
}