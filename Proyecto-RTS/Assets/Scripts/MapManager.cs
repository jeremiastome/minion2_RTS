using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    // Use this for initialization

    List<PositionScript> positions;

	void Start () {
        positions = new List<PositionScript>();
        GameObject grilla = GameObject.Find("Map").transform.Find("collision").gameObject;
        Transform[] celdas = grilla.transform.GetComponentsInChildren<Transform>();

        foreach (Transform c in celdas)
        {
            c.gameObject.AddComponent<PositionScript>();
            PositionScript positionScript = c.gameObject.GetComponent<PositionScript>();
            positionScript.SetPosition(new Position(c.position.x, c.position.y));
            positions.Add(positionScript);
        }

        Debug.Log("Cant posiciones: " + positions.Count);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
