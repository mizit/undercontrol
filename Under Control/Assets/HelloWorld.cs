using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    protected Vector3 mouse_pos;
	// Use this for initialization
	public void Start ()
    {
        Debug.Log("Hello, world!");
	}
	
	// Update is called once per frame
	public void Update ()
    {
        mouse_pos = Input.mousePosition;
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("MouseX - " + mouse_pos.x + " , MouseY - " + mouse_pos.y + " , MouseZ - " + mouse_pos.z);
        }
        
	}
}
