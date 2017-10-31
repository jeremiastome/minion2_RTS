using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    PathFinder pathFinder;
    public List<Unit> units;
    MapManager mm;

    // Use this for initialization
    void Start () {
        units = new List<Unit>();
        mm = GameObject.Find("MapManager").GetComponent<MapManager>();
        pathFinder = new PathFinder(mm);

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectUnit(Unit u)
    {
        if (units.Contains(u))
        {
            units.Remove(u);
        }
        else
        {
            units.Add(u);
        }            
    }

    public void MoveUnits(Vector2 p)
    {
        List<Vector2> path2 = new List<Vector2>();
        List<Vector2> path = pathFinder.encontrarCamino(new Vector2(95, 32), new Vector2(1119, 576));
        foreach(Vector2 pos in path)
        {
            Tile t = mm.getTileAux(pos);
            Vector2 posAux = t.positionAux;
            path2.Add(posAux);
        }

        foreach (Vector2 pAux in path2)
        {
            Debug.Log(pAux);
        }
        /*foreach(Unit u in units)
        {
            u.Mover(p);
        }*/
    }

    public void test1()
    {
        List<Vector2> path = pathFinder.encontrarCamino(new Vector2(95, 32), new Vector2(1119, 576));
        Debug.Log(path.Count);

        foreach(Vector2 p in path)
        {
            Debug.Log("x: "+p.x+" y: "+p.y);
        }
    }
}
