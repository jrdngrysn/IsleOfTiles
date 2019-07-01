using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    //public List<int> Tiles;
    public Queue<Tile> tilesTemp = new Queue<Tile>();
    public Tile[,] tiles = new Tile[2, 2];
    public GameObject[,] tilesPrefab = new GameObject[2, 2];

    // Start is called before the first frame update
    void Start() {
        tilesTemp.Enqueue(new Tile(0, 0, 0, false));
        tilesTemp.Enqueue(new Tile(0, 1, 1, false));
        tilesTemp.Enqueue(new Tile(1, 0, 2, false));
        tilesTemp.Enqueue(new Tile(1, 1, 3, false));

        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                Tile tempTile = tilesTemp.Dequeue();
                tiles[x, y] = tempTile;
                GameObject newSprite = Instantiate(God.GSM.tilePrefab);
                tilesPrefab[x, y] = newSprite;
                newSprite.name = ("Tile: " + x + "-" + y);
                newSprite.transform.localPosition = new Vector3(x, y, 0);





          
            }
        }

        Stack<int> colors = new Stack<int>();
        colors.Push(0);
        colors.Push(1);
        colors.Push(2);
        colors.Push(3);
        God.GSM.ShuffleStackInt(colors);

        God.GSM.blue = colors.Pop();
        God.GSM.red = colors.Pop();
        God.GSM.yellow = colors.Pop();
        God.GSM.green = colors.Pop();


        //int blue = Random.Range(0, 3);
        //int red = Random.Range(0, 3);
        //while (red == blue)
        //    red = Random.Range(0, 3);
        //int yellow = Random.Range(0, 3);
        //while (yellow == red || yellow == blue)
        //    yellow = Random.Range(0, 3);
        //int green = Random.Range(0, 3);
        //while (green == yellow || green == red || green == blue)
        //green = Random.Range(0, 3);

        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {


                if (tiles[x, y].color == God.GSM.blue)
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.blue;
                else if (tiles[x, y].color == God.GSM.red)
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                else if (tiles[x, y].color == God.GSM.yellow)
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                else if (tiles[x, y].color == God.GSM.green)
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.green;




                //switch (tiles[x, y].color)
                //{
                //    case (0):
                //        break;
                //    case (1):
                //        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                //        break;
                //    case (2):
                //        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                //        break;
                //    case (3):
                //        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                //        break;
                //}
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && God.GSM.player1.x < 1)
            God.GSM.player1.x++;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && God.GSM.player1.x > 0)
            God.GSM.player1.x--;
        else if (Input.GetKeyDown(KeyCode.UpArrow) && God.GSM.player1.y < 1)
            God.GSM.player1.y++;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && God.GSM.player1.y > 0)
            God.GSM.player1.y--;

        for (int x = 0; x < 2; x++) 
        {
            for (int y = 0; y < 2; y++)
            {
                if(x == God.GSM.player1.x && y == God.GSM.player1.y)
                {
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    if (tiles[x, y].color == God.GSM.blue)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.blue;
                    else if (tiles[x, y].color == God.GSM.red)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                    else if (tiles[x, y].color == God.GSM.yellow)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                    else if (tiles[x, y].color == God.GSM.green)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                }

            }
        }
    }
}
