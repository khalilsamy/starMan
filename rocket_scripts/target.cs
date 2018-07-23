using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
	/*This is the planet to reach so the target , for the moment just move*/
    public float speed;

	// Use this for initialization
	void Start () {
		speed = Random.RandomRange(20, 100); 
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
