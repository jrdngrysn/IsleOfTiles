using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour {
    public int gridLength;
    public int gridHeight;
    public Vector2Int player1 = new Vector2Int(0,0);
    public int chips1;
    public GameObject tilePrefab;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
