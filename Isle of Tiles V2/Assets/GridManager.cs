using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public const int WIDTH = 3;
    public const int HEIGHT = 3;

    public GameObject tilePrefab;
    public GameObject gridHolder;

    float xOffset = WIDTH / 2f + 4f;
    float yOffset = HEIGHT / 2f - .75f;

    public GameObject[,] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[WIDTH, HEIGHT];
        CreateGrid();

        CheckGrid();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void CreateGrid()
    {
        //create the grid using a double for loop

        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                GameObject newTile = Instantiate(tilePrefab);

                newTile.transform.parent = gridHolder.transform;
                newTile.transform.localPosition = new Vector2(WIDTH - x - xOffset, HEIGHT - y - yOffset);

                tiles[x, y] = newTile;


            }
        }

    }

    void CheckGrid()
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                if (tiles[x + 1, y].GetComponent<TileScript>().color == tiles[x, y].GetComponent<TileScript>().color)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}
