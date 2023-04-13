using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int score { get; private set; }
    public int comboCounter { get; private set; }
    [SerializeField]
    private int scoreBase;

    [SerializeField]
    public float timeLossPerFrame;
    public float timeLimit { get; private set; }

    [SerializeField] private Tilemap danceFloor;
    [SerializeField] Player player;
    [SerializeField] private MenuAnim menuText;

    private Vector3 ogPos;
    private bool gameStart;

    private List<Color> colors = new List<Color>
    {
        Color.red,
        Color.cyan,
        Color.green,
        Color.magenta,
        Color.blue,
        Color.yellow
    };

    public static GameManager Instance { get; private set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        danceFloor.enabled = true;
        Init();
        Vector3Int cellPosition = danceFloor.WorldToCell(player.transform.position);
        player.transform.position = danceFloor.GetCellCenterWorld(cellPosition);
        ogPos = player.transform.position;
    }

    private void Init()
    {
        RandomizeTileColors();
        score = 0;
        comboCounter = 0;
        timeLimit = 1;
        gameStart = false;
        player.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
            return;

        timeLimit -= timeLossPerFrame * Time.deltaTime;
        if (timeLimit <= 0)
        {
            Init();
            player.transform.position = ogPos;
        }
    }

    public void RandomizeTileColors()
    {
        BoundsInt bounds = danceFloor.cellBounds;

        for (int x = bounds.min.x; x < bounds.max.x; x++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int z = bounds.min.z; z < bounds.max.z; z++)
                {
                    Vector3Int pos = new Vector3Int(x, y, z);
                    danceFloor.SetTileFlags(pos, TileFlags.None);
                    danceFloor.SetColor(pos, colors[Mathf.RoundToInt(Random.Range(0, colors.Count))]);
                }
            }

        }

        Vector3Int playerPos = danceFloor.WorldToCell(player.transform.position);
        Color playerColor = danceFloor.GetColor(playerPos);

        int numComplements = Mathf.RoundToInt(Random.Range(0, 2));
        HashSet<Player.MOVE_DIR> randDirs = new HashSet<Player.MOVE_DIR>();
        for(int i = 0; i <= numComplements; i++)
        {
            Player.MOVE_DIR dir;
            do
            {
                dir = (Player.MOVE_DIR)Mathf.RoundToInt(Random.Range(1, 4));
            }
            while (randDirs.Contains(dir));
            randDirs.Add(dir);
        }

        foreach(Player.MOVE_DIR dir in randDirs)
        {
            Vector2 offset = new Vector2(0, 0);
            switch (dir) {
                case Player.MOVE_DIR.LEFT:
                    offset = new Vector2(-1, 0);
                    break;
                case Player.MOVE_DIR.RIGHT:
                    offset = new Vector2(1, 0);
                    break;
                case Player.MOVE_DIR.UP:
                    offset = new Vector2(0, 1);
                    break;
                case Player.MOVE_DIR.DOWN:
                    offset = new Vector2(0, -1);
                    break;
            }

            Vector3Int tilePos = danceFloor.WorldToCell(player.transform.position + (Vector3)offset);
            Color newCol = Color.white - playerColor;
            newCol.a = 1;
            danceFloor.SetColor(tilePos, newCol);
        }
    }

    public void OnPlayerMove()
    {
        RandomizeTileColors();
        gameStart = true;
        menuText.Disappear();
        timeLimit = 1;
        comboCounter++;
        score += scoreBase * comboCounter;
    }
}
