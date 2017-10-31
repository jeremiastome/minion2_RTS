using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    Rigidbody2D unitRB;
    public float velocidad;
    Vector2 target;
    float z;
    bool selected;

    UnitController unitController;

    // Use this for initialization
    void Start() {

        unitController = GameObject.Find("UnitController").GetComponent<UnitController>();

        target = this.transform.position;
        z = this.transform.position.z;
        unitRB = GetComponent<Rigidbody2D>();
        selected = false;
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(this.transform.position, target) > 0.1f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target, velocidad * Time.deltaTime);               
        }
        else
        {
            target = this.transform.position;
        }        
    }

    void OnMouseDown()
    {
        unitController.SelectUnit(this);
    }

    public void Mover(Vector2[] positions)
    {
        foreach (Vector2 p in positions)
        {
            Mover(p);
        }
    }

    public void Mover(Vector2 p)
    {
        target = new Vector3(p.x, p.y, z);
    }
}
