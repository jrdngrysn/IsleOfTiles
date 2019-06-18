using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    public Tile[,] tiles = new Tile[8, 8];
    public GameObject[,] sprites = new GameObject[8, 8];
    Tile currentTile;

    // Start is called before the first frame update
    void Start() {
        createBlankGrid();
        generateColors();
        //displayColors();
        Debug.Log("HAHA");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void createBlankGrid()
    {
        for (int x = 0; x < God.GSM.gridLength; x++)
        {
            for (int y = 0; y < God.GSM.gridHeight; y++)
            {
                tiles[x, y] = new Tile(x, y, -1, false);
                GameObject newSprite = Instantiate(God.GSM.tilePrefab);
                sprites[x, y] = newSprite;
                newSprite.name = ("Tile: " + x + "-" + y);
                newSprite.transform.localPosition = new Vector3(x, y, 0);
            }
        }
    }

    void generateColors()
    {
        for (int i = 0; i < (God.GSM.gridHeight * God.GSM.gridLength); i++)
        {
            bool tileDuplication = true;
            bool sameColor = true;
            while (tileDuplication)
            {
                currentTile = tiles[Random.Range(0, 8), Random.Range(0, 8)];
                if (currentTile.color == -1)
                {
                    tileDuplication = false;
                }
            }
            while (sameColor)
            {
                currentTile.color = Random.Range(0, 4);
                if ((currentTile.x == 0 || currentTile.color != tiles[currentTile.x - 1, currentTile.y].color) &&
                (currentTile.x == 7 || currentTile.color != tiles[currentTile.x + 1, currentTile.y].color) &&
                (currentTile.y == 0 || currentTile.color != tiles[currentTile.x, currentTile.y - 1].color) &&
                (currentTile.y == 7 || currentTile.color != tiles[currentTile.x, currentTile.y + 1].color))
                {
                    sameColor = false;
                }
            }
        }
    }

    void displayColors()
    {
        for (int x = 0; x < God.GSM.gridLength; x++)
        {
            for (int y = 0; y < God.GSM.gridHeight; y++)
            {
                switch (tiles[x, y].color)
                {
                    case (0):
                        sprites[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;
                    case (1):
                        sprites[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case (2):
                        sprites[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case (3):
                        sprites[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }
            }
        }
    }
}
