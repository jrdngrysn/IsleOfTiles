using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public List<Tile> Tiles = new List<Tile>(); 

    // Start is called before the first frame update
    void Start() {
        Tiles.Add(new Tile(1, 1, 1, true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
