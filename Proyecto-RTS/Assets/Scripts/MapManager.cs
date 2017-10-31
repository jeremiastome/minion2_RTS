using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    // Use this for initialization

    List<Tile> positions;

	void Start () {
        positions = new List<Tile>();
        GameObject grilla = GameObject.Find("Map").transform.Find("collision").gameObject;
        Transform[] celdas = grilla.transform.GetComponentsInChildren<Transform>();

        for (int i = 1; i < celdas.Length; i++)
        {
            celdas[i].gameObject.AddComponent<TileScript>();
            TileScript positionScript = celdas[i].gameObject.GetComponent<TileScript>();
            positionScript.SetPosition();
            Tile t = new Tile(positionScript.GetPosition(), positionScript.positionAux);
            positions.Add(t);
        }

        Debug.Log("Cant posiciones: " + positions.Count);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Tile getTile(int x, int y) {
        return positions.Find(p => p.x == x && p.y == y && p.walkable);
    }

    public Tile getTileAux(Vector2 pos)
    {
        return positions.Find(p => p.Equals(pos));
    }

    public bool existTile(int x, int y) {
        return positions.Exists(p => p.x == x && p.y == y && p.walkable);
    }
}
