using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour {
    public int gridLength;
    public int gridHeight;
    public Vector2Int player1 = new Vector2Int(0,0);
    public int chips1;
    public GameObject tilePrefab;

    void Awake() {
        God.GSM = this;
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
