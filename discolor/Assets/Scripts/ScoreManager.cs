using UnityEngine;
using UnityEngine.Tilemaps;

public class ScoreManager2 : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private GameObject playerController;
    [SerializeField] private TileInfo.color targetColor;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI comboScoreText;
    [SerializeField] private int score;
    [SerializeField] private int comboScore;

    private TileManager tileManager;
    private TileInfo.color lastCorrectTileColor;

    private void Start()
    {
        score = 0;
        comboScore = 0;
        tileManager = FindObjectOfType<TileManager>();
        lastCorrectTileColor = TileInfo.color.red; // initialize to any color
        UpdateScoreText();
    }

    private void Update()
    {
        Vector3Int playerPosition = tileMap.WorldToCell(playerController.transform.position);

        if (tileMap.HasTile(playerPosition))
        {
            Tile tile = tileMap.GetTile<Tile>(playerPosition);
            Vector3Int tilePosition = tileMap.WorldToCell(playerController.transform.position);
            TileInfo.color currentColor = tileManager.GetTileColor(new Vector2Int(tilePosition.x, tilePosition.y));

            if (currentColor == targetColor)
            {
                // Player is on correct tile
                if (lastCorrectTileColor == targetColor)
                {
                    // Player has two consecutive correct answers, increment combo score
                    comboScore++;
                    UpdateComboScoreText();
                }
                else
                {
                    // Player has one correct answer, reset combo score
                    comboScore = 1;
                    UpdateComboScoreText();
                    lastCorrectTileColor = targetColor;
                }

                // Increment score and update text
                score++;
                UpdateScoreText();
            }
            else
            {
                // Player is on wrong tile, reset combo score
                comboScore = 0;
                UpdateComboScoreText();
                lastCorrectTileColor = TileInfo.color.red;
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateComboScoreText()
    {
        comboScoreText.text = "Combo Score: " + comboScore.ToString();
    }
}