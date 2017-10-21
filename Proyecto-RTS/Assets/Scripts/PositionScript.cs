using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour {

    Position position;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPosition(Position p)
    {
        this.position = p;
    }

    public Position GetPosition()
    {
        return position;
    }

    void OnMouseDown()
    {
        Debug.Log("Posicion: x: " + position.x + " y: " + position.y);
    }
}
