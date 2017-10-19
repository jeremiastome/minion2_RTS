using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    Rigidbody2D unitRB;
    public float velocidad;
    Vector2 target;
    bool selected;

    // Use this for initialization
    void Start () {
        target = transform.position;
        unitRB = GetComponent<Rigidbody2D>();
        selected = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

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
        selected = !selected;      
    }
}
