using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    //public List<int> Tiles;
    public Queue<Tile> tilesTemp = new Queue<Tile>();
    public Tile[,] tiles = new Tile[God.DIMENSIONS.x, God.DIMENSIONS.y];
    public GameObject[,] tilesPrefab = new GameObject[God.DIMENSIONS.x, God.DIMENSIONS.y];

    // Start is called before the first frame update
    void Start() {
        tilesTemp = God.GSM.GetPresetTiles();

        //tilesTemp.Enqueue(new Tile(0, 0, 0, false));
        //tilesTemp.Enqueue(new Tile(0, 1, 1, false));
        //tilesTemp.Enqueue(new Tile(1, 0, 2, false));
        //tilesTemp.Enqueue(new Tile(1, 1, 3, false));

        GameObject GridHolder = new GameObject();
        GridHolder.name = "Grid";
        GridHolder.transform.localPosition = new Vector3(-2f, -2.5f, 0f);

        for (int x = 0; x < God.DIMENSIONS.x; x++)
        {
            for (int y = 0; y < God.DIMENSIONS.y; y++)
            {
                Tile tempTile = tilesTemp.Dequeue();
                tiles[x, y] = tempTile;
                GameObject newSprite = Instantiate(God.GSM.tilePrefab);
                tilesPrefab[x, y] = newSprite;
                tilesPrefab[x, y].transform.parent = GridHolder.transform;
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

        for (int x = 0; x < God.DIMENSIONS.x; x++)
        {
            for (int y = 0; y < God.DIMENSIONS.y; y++)
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
        if (Input.GetKeyDown(KeyCode.RightArrow) && God.GSM.player1.x < (God.DIMENSIONS.x - 1))
            God.GSM.player1.x++;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && God.GSM.player1.x > 0)
            God.GSM.player1.x--;
        else if (Input.GetKeyDown(KeyCode.UpArrow) && God.GSM.player1.y < (God.DIMENSIONS.y - 1))
            God.GSM.player1.y++;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && God.GSM.player1.y > 0)
            God.GSM.player1.y--;

        for (int x = 0; x < God.DIMENSIONS.x; x++) 
        {
            for (int y = 0; y < God.DIMENSIONS.y; y++)
            {
                if(x == God.GSM.player1.x && y == God.GSM.player1.y)
                {
                    tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                    if (tiles[x, y].color == God.GSM.blue)
                        tiles[x, y].isFlipped = true;
                }
                else
                {
                    if (tiles[x, y].color == God.GSM.blue && !tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.blue;
                    else if (tiles[x, y].color == God.GSM.red && !tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.red;
                    else if (tiles[x, y].color == God.GSM.yellow && !tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                    else if (tiles[x, y].color == God.GSM.green && !tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.green;
                    else if (tiles[x, y].color == God.GSM.blue && tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.cyan;
                    else if (tiles[x, y].color == God.GSM.red && tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.magenta;
                    else if (tiles[x, y].color == God.GSM.yellow && tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.gray;
                    else if (tiles[x, y].color == God.GSM.green && tiles[x, y].isFlipped)
                        tilesPrefab[x, y].GetComponent<SpriteRenderer>().color = Color.white;
                }

            }
        }
    }
}
