using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flight_information : MonoBehaviour {

    public GameObject rocket;
    public GameObject target;
    public Rect UIRect;
   // public ImageConversion ;
    private float gap;
    private float MAX_VALUE_X =  524f;
    private float MIN_VALUE_X = -629f; 

    // Use this for initialization
    void Start () {
		/*
		flight_information is for collect data information
		on rocket progress for stats and debug
		*/
		gap = Mathf.Abs(rocket.transform.position.x - target.transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
        gap = Mathf.Abs(rocket.transform.position.x - target.transform.position.x);
        Debug.Log("[FLIGHT INFORMATION SCRIPT] difference between target and rocket : " + gap);
	}
}
