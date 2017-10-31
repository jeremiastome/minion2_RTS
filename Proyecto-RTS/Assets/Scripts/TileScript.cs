using System.Collections;
using System.Collections.Generic;
using Tiled2Unity;
using UnityEngine;

public class TileScript : MonoBehaviour {

    Vector2 position;
    public Vector2 positionAux;

    UnitController unitController;
    public float x;
    public float y;
    public bool walkable = true;

    // Use this for initialization
    void Start () {
        unitController = GameObject.Find("UnitController").GetComponent<UnitController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPosition()
    {
        position = new Vector2(this.transform.position.x, this.transform.position.y);

        PolygonObject po = GetComponent<PolygonObject>();
        int xAux = (int)po.TmxPosition.x;
        int yAux = (int)po.TmxPosition.y;

        positionAux = new Vector2(xAux, yAux);
        x = positionAux.x;
        y = positionAux.y;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    void OnMouseDown()
    {
        Debug.Log("X: " + position.x + " Y: " + position.y);
        unitController.MoveUnits(position);
    }
}
