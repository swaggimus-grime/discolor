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
                    danceFloor.SetColor(pos, colors[Random.Range(0, colors.Count)]);
                }
            }

        }
    }

    public void OnPlayerMove()
    {
        RandomizeTileColors();
        gameStart = true;
        timeLimit = 1;
        comboCounter++;
        score += scoreBase * comboCounter;
    }
}
