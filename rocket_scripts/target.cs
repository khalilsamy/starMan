using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

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
