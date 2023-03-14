using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;

    [SerializeField] private Dictionary<Tile, TileInfo.color> tileColors = new Dictionary<Tile, TileInfo.color>();
    [SerializeField] private Tile[] tilesObjects;
    private Dictionary<Vector2Int, TileInfo> tiles = new Dictionary<Vector2Int, TileInfo>();

    void Start ()
    {
        tileColors.Add(tilesObjects[0], TileInfo.color.red);
        tileColors.Add(tilesObjects[1], TileInfo.color.orange);
        //add the rest
        //for each tile on tilemap
        //   use tileColors to find what color it should be
        //   Create tileInfo object with correct color
        //   assign position as key and tileinfo as value in the "tiles" dictionary
    }

    public TileInfo GetTile(Vector2Int location)
    {
        return tiles[location];
    }

    public void SetTile(TileInfo.color c, Vector2Int position)
    {
        // Set new tileinfo value in "tiles"
        // apply correct sprite to tileMap
    }


 }
