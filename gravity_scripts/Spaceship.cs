using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    private bool rotating;

    public float gap; // 
    public float speed; // 
    
    // Planet which can be Attract this spaceShip
    public GameObject attractedPlanet;
    
    // booolean value to know if this spaceship is attracted
    public bool attracted;

    // Vector3 of next position
    public Vector3 desiredPosition; 

    // Use this for initialization
    void Start () {
        //any attraction effective at start
        attracted = false; 
        // Go straigt in one direction for this exemple
        // rotationMask_f = Vector3.back;
        // try to set a gap to increase or decrease position of 
        // spaceship on orbit
        gap = 0; 
    }
	
	// Update is called once per frame
	void Update () {

        if (attracted)
        {
            float distance = Vector3.Distance(attractedPlanet.transform.position,
                                              transform.position);
       
            // orient spaceship move to the planet 
            transform.LookAt(attractedPlanet.transform, Vector3.back);
            Vector3 gravitation = new Vector3(1,0,gap);
            transform.Translate(gravitation * Time.deltaTime);
        
        }

        else
        {

            // Move control normal
            //transform.position += Vector3.right * speed * Time.deltaTime;
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        
    }

}
