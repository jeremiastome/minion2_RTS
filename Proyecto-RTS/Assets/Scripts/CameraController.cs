using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Rigidbody2D cameraRB;
    public float vel;

    // Use this for initialization
    void Start () {
        cameraRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        cameraRB.velocity = new Vector2(moveHorizontal * vel, moveVertical * vel);
    }
}
