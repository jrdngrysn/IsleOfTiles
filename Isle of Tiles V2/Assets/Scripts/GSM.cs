using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour {
    public int gridLength;
    public int gridHeight;
    public Vector2Int player1 = new Vector2Int(0,0);
    public int chips1;
    public GameObject tilePrefab;

    //public Queue<Tile> tilesTemp = new Queue<Tile>();

    public int blue = 0;
    public int yellow = 1;
    public int green = 2;
    public int red = 3;

    public int yellowCount;
    public int blueCount;
    public int greenCount;
    public int redCount;

    void Awake() {
        God.GSM = this;
        yellowCount = (gridLength * gridHeight) / 4;
        blueCount = (gridLength * gridHeight) / 4;
        greenCount = (gridLength * gridHeight) / 4;
        redCount = (gridLength * gridHeight) / 4;


    }

    public Stack<Tile> ShuffleStack(Stack<Tile> T)
    {
        List<Tile> t = new List<Tile>();
        t.AddRange(T);
        T.Clear();
        while (t.Count > 0)
        {
            Tile c = t[Random.Range(0, t.Count)];
            t.Remove(c);
            T.Push(c);
        }
        return T;
    }

    public Stack<int> ShuffleStackInt(Stack<int> T)
    {
        List<int> t = new List<int>();
        t.AddRange(T);
        T.Clear();
        while (t.Count > 0)
        {
            int c = t[Random.Range(0, t.Count)];
            t.Remove(c);
            T.Push(c);
        }
        return T;
    }

    public Queue<Tile> GetPresetTiles()
    {
        Queue<Tile> tilesTemp = new Queue<Tile>();
        int rand = Random.Range(0, 1);
        switch (rand)
        {
            case (0):
                tilesTemp.Enqueue(new Tile(0, 0, 0, false));
                tilesTemp.Enqueue(new Tile(0, 1, 3, false));
                tilesTemp.Enqueue(new Tile(0, 2, 2, false));
                tilesTemp.Enqueue(new Tile(0, 3, 0, false));
                tilesTemp.Enqueue(new Tile(0, 4, 3, false));
                tilesTemp.Enqueue(new Tile(0, 5, 1, false));

                tilesTemp.Enqueue(new Tile(1, 0, 1, false));
                tilesTemp.Enqueue(new Tile(1, 1, 0, false));
                tilesTemp.Enqueue(new Tile(1, 2, 1, false));
                tilesTemp.Enqueue(new Tile(1, 3, 2, false));
                tilesTemp.Enqueue(new Tile(1, 4, 0, false));
                tilesTemp.Enqueue(new Tile(1, 5, 2, false));

                tilesTemp.Enqueue(new Tile(2, 0, 2, false));
                tilesTemp.Enqueue(new Tile(2, 1, 3, false));
                tilesTemp.Enqueue(new Tile(2, 2, 2, false));
                tilesTemp.Enqueue(new Tile(2, 3, 1, false));
                tilesTemp.Enqueue(new Tile(2, 4, 3, false));
                tilesTemp.Enqueue(new Tile(2, 5, 1, false));

                tilesTemp.Enqueue(new Tile(3, 0, 1, false));
                tilesTemp.Enqueue(new Tile(3, 1, 0, false));
                tilesTemp.Enqueue(new Tile(3, 2, 1, false));
                tilesTemp.Enqueue(new Tile(3, 3, 0, false));
                tilesTemp.Enqueue(new Tile(3, 4, 2, false));
                tilesTemp.Enqueue(new Tile(3, 5, 3, false));

                tilesTemp.Enqueue(new Tile(4, 0, 0, false));
                tilesTemp.Enqueue(new Tile(4, 1, 2, false));
                tilesTemp.Enqueue(new Tile(4, 2, 0, false));
                tilesTemp.Enqueue(new Tile(4, 3, 2, false));
                tilesTemp.Enqueue(new Tile(4, 4, 1, false));
                tilesTemp.Enqueue(new Tile(4, 5, 0, false));

                tilesTemp.Enqueue(new Tile(5, 0, 1, false));
                tilesTemp.Enqueue(new Tile(5, 1, 3, false));
                tilesTemp.Enqueue(new Tile(5, 2, 1, false));
                tilesTemp.Enqueue(new Tile(5, 3, 3, false));
                tilesTemp.Enqueue(new Tile(5, 4, 2, false));
                tilesTemp.Enqueue(new Tile(5, 5, 1, false));
                break;
        }
        return tilesTemp;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
