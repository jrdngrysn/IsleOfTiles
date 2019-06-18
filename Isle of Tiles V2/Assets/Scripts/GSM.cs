using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour {
    public int gridLength;
    public int gridHeight;
    public Vector2Int player1 = new Vector2Int(0,0);
    public int chips1;
    public GameObject tilePrefab;


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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
