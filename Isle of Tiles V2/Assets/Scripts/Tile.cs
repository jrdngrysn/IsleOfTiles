using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    public int x;
    public int y;
    public int color;
    public bool isFlipped;
    public Tile (int x, int y, int color, bool isFlipped) {
        this.x = x;
        this.y = y;
        this.color = color;
        this.isFlipped = isFlipped;
    }
}
