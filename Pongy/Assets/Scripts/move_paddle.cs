using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_paddle : MonoBehaviour {

    public float speed = 30;
    public string axis = "Vertical";

    void FixedUpdate()
    {

        float vertPress = Input.GetAxisRaw(axis);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress) * speed;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
