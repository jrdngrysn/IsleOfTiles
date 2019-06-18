using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    public int X;
    public int Y;
    public int Color;
    public bool Active;

    public Tile(int x, int y, int color, bool active) {
        X = x;
        Y = y;
        Color = color;
        Active = active;
    }

    public int getLocationX() {
        return this.X;
    }

    public int getLocationY() {
        return this.Y;
    }

    public int getColor() {
        return this.Color;
    }

    public bool getActive() {
        return this.Active;
    }
}
