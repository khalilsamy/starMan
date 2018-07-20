using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_part : MonoBehaviour {
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
        if (other.name == "plateforme")
        {
            rb.isKinematic = true;
        }
    }
}
