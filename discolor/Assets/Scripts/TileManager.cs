using System;
using System.Collections;
using System.Collections.Generic;
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
        tileColors.Add(tilesObjects[2], TileInfo.color.yellow);
        tileColors.Add(tilesObjects[4], TileInfo.color.green);
        tileColors.Add(tilesObjects[5], TileInfo.color.cyan);
        tileColors.Add(tilesObjects[6], TileInfo.color.blue);
        tileColors.Add(tilesObjects[7], TileInfo.color.purple);
        tileColors.Add(tilesObjects[8], TileInfo.color.pink);

        // Loop through each tile on the tilemap
        foreach (Vector3Int pos in tileMap.cellBounds.allPositionsWithin)
        {
            // Get the tile at the current position
            Tile tile = tileMap.GetTile<Tile>(pos);

            // If the tile is not null (meaning there is a tile at this position)
            if (tile != null)
            {
                // Get the color for this tile from the tileColors dictionary
                TileInfo.color color = tileColors[tile];

                // Create a new TileInfo object with the correct color
                TileInfo tileInfo = new TileInfo(color);

                // Assign the tile position as the key in the tiles dictionary, with the TileInfo object as the value
                tiles.Add(new Vector2Int(pos.x, pos.y), tileInfo);
            }
        }

    }
       
    public TileInfo GetTile(Vector2Int location)
    {
        return tiles[location];
    }

    public void SetTile(TileInfo.color c, Vector2Int position)
    {
        // Get the TileInfo object at the specified position
        if (tiles.TryGetValue(position, out TileInfo tileInfo))
        {
            // Check if the specified color is valid for the tile's current color
            if (tileInfo.isValidColor(c))
            {
                // Update the color of the TileInfo object
                tileInfo.currentColor = c;

                // Update the color of the corresponding tile in the Tilemap
                tileMap.SetTile(new Vector3Int(position.x, position.y, 0), tilesObjects[(int)c]);

                // Update the TileInfo object in the dictionary
                tiles[position] = tileInfo;
            }
            else
            {
                Debug.Log("Invalid color for this tile");
            }
        }
        else
        {
            Debug.Log("No tile at specified position");
        }
    }


    public TileInfo.color GetTileColor(Vector2Int location)
    {
        if (tiles.TryGetValue(location, out TileInfo tileInfo))
        {
            return tileInfo.currentColor;
        }
        else
        {
            Debug.LogError("No tile at specified position");
            return TileInfo.color.red; // or any default color
        }
    }


}
