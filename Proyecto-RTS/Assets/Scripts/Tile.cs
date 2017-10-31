using UnityEngine;
using UnityEditor;

public class Tile{

    Vector2 position;
    public Vector2 positionAux;
    public float x;
    public float y;
    public bool walkable = true;

    public Tile(Vector2 p, Vector2 aux) {
        position = p;
        positionAux = aux;
        x = positionAux.x;
        y = positionAux.y;
    }
}