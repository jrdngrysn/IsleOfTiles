using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour {
    public Tile[,] tiles = new Tile[8, 8];
    public GameObject[,] tilesPrefab = new GameObject[8, 8];

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < God.GSM.gridLength; x++)
        {
            for (int y = 0; y < God.GSM.gridHeight; y++)
            {
                tiles[x, y] = new Tile(x, y, Random.Range(0, 4), false);
                if (x == 0 && y > 0)
                {
                    while (tiles[x, y].color == tiles[x, y - 1].color)
                    {
                        tiles[x, y].color = Random.Range(0, 4);
                        Debug.Log("MATCHING COLOR AT - " + x + " : " + y);
                    }
                }

                else if (x > 0 && y == 0)
                {
                    while (tiles[x, y].color == tiles[x - 1, y].color)
                    {
                        tiles[x, y].color = Random.Range(0, 4);
                        Debug.Log("MATCHING COLOR AT - " + x + " : " + y);
                    }
                }


                else if (x > 0 && y > 0)
                {
                    while (tiles[x, y].color == tiles[x - 1, y].color ||
                    tiles[x, y].color == tiles[x, y - 1].color)
                    {
                        tiles[x, y].color = Random.Range(0, 4);
                        Debug.Log("MATCHING COLOR AT - " + x + " : " + y);
                    }
                }

                //if (x > 0)
                //{
                //    while (tiles[x, y].color == tiles[x - 1, y].color)
                //    {
                //        tiles[x, y].color = Random.Range(0, 4);
                //        Debug.Log("MATCHING COLOR AT - " + x + " : " + y);
                //    }
                //}
                //if (y > 0)
                //{
                //    while (tiles[x, y].color == tiles[x, y - 1].color)
                //    {
                //        tiles[x, y].color = Random.Range(0, 4);
                //        Debug.Log("MATCHING COLOR AT - " + x + " : " + y);
                //    }
                //}



                //if (x > 0)
                //{
                //    while (tiles[x, y].color == tiles[x - 1, y].color)
                //    {
                //        Debug.Log("Change color");
                //        tiles[x, y].color = Random.Range(0, 4);
                //    }
                //}
                //if (y > 0)
                //{
                //    while (tiles[x, y].color == tiles[x, y - 1].color)
                //    {
                //        Debug.Log("Change color");
                //        tiles[x, y].color = Random.Range(0, 4);
                //    }
                //}

                //if (x > 0 && y > 0)
                //{
                //    while (tiles[x, y].color == tiles[x-1, y].color || tiles[x, y].color == tiles[x, y-1].color)
                //    {
                //        Debug.Log("Change color");
                //        tiles[x, y].color = Random.Range(0, 4);
                //    }
                //}
                //else if (x > 0 || y == 0)
                //{
                //    while (tiles[x, y].color == tiles[x - 1, y].color)
                //    {
                //        Debug.Log("Change color");
                //        tiles[x, y].color = Random.Range(0, 4);
                //    }
                //}
                //else if (y > 0 || x == 0)
                //{
                //    while (tiles[x, y].color == tiles[x, y-1].color)
                //    {
                //        Debug.Log("Change color");
                //        tiles[x, y].color = Random.Range(0, 4);
                //    }
                //}

                GameObject newTile = Instantiate(God.GSM.tilePrefab);
                tilesPrefab[x, y] = newTile;
                newTile.name = ("Tile: " + x + "-" + y);
                newTile.transform.localPosition = new Vector3(x, y, 0);
                switch (tiles[x, y].color)
                {
                    case (0):
                        newTile.GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;
                    case (1):
                        newTile.GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case (2):
                        newTile.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case (3):
                        newTile.GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }
                //tiles.Add(new Tile(x, y, Random.Range(0,5), false));
            }
        }


        for (int x = 1; x < God.GSM.gridLength - 1; x++)
        {
            for (int y = 1; y < God.GSM.gridHeight - 1; y++)
            {
                int check = 1;
                while (check > 0) {
                    if ((tiles[x, y].color == tiles[x - 1, y - 1].color && tiles[x, y].color == tiles[x + 1, y + 1].color) ||
                    (tiles[x, y].color == tiles[x + 1, y - 1].color && tiles[x, y].color == tiles[x - 1, y + 1].color) ||
                    (tiles[x, y].color == tiles[x - 1, y].color) || (tiles[x, y].color == tiles[x + 1, y].color) ||
                    (tiles[x, y].color == tiles[x, y - 1].color) || (tiles[x, y].color == tiles[x, y + 1].color))
                    {
                        Debug.Log("Hold on to your processing speed");
                        tiles[x, y].color = Random.Range(0, 4);
                        check--;
                    }
                }
                switch (tiles[x, y].color)
                {
                    case (0):
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;
                    case (1):
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case (2):
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case (3):
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) && God.GSM.player1.x < (God.GSM.gridLength - 1)) {
            God.GSM.player1.x++;
            God.GSM.chips1--;
            tilesPrefab[God.GSM.player1.x, God.GSM.player1.y].GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log(tiles[God.GSM.player1.x, God.GSM.player1.y].x);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && God.GSM.player1.x > 0)
        {
            God.GSM.player1.x--;
            God.GSM.chips1--;
            tilesPrefab[God.GSM.player1.x, God.GSM.player1.y].GetComponent<SpriteRenderer>().color = Color.black;

            Debug.Log(tiles[God.GSM.player1.x, God.GSM.player1.y].x);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && God.GSM.player1.y < (God.GSM.gridHeight - 1))
        {
            God.GSM.player1.y++;
            God.GSM.chips1--;
            tilesPrefab[God.GSM.player1.x, God.GSM.player1.y].GetComponent<SpriteRenderer>().color = Color.black;

            Debug.Log(tiles[God.GSM.player1.x, God.GSM.player1.y].y);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && God.GSM.player1.y > 0)
        {
            God.GSM.player1.y--;
            God.GSM.chips1--;
            tilesPrefab[God.GSM.player1.x, God.GSM.player1.y].GetComponent<SpriteRenderer>().color = Color.black;

            Debug.Log(tiles[God.GSM.player1.x, God.GSM.player1.y].y);
        }

    }
}
