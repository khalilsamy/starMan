using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float speed;
    public GameObject attractedPlanet;

    public bool attracted;

    public Vector3 desiredPosition;

    private Vector3 rotationMask_f;
    public float gap;

    // Use this for initialization
    void Start () {
        attracted = false;
        rotationMask_f = Vector3.back; //new Vector3(1, 1, 0); 
        gap = 2f;
    }
	
	// Update is called once per frame
	void Update () {
      
        if (attracted)
        {
            float distance = Vector3.Distance(attractedPlanet.transform.position,
                                              transform.position);
           /* if (distance < gap)
            {*/
                desiredPosition = (transform.position - attractedPlanet.transform.position).normalized * gap + attractedPlanet.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * speed);
                Vector3 tangentVector = Quaternion.Euler(0, 90, 0) * (transform.position - attractedPlanet.transform.position);
                transform.rotation = Quaternion.LookRotation(tangentVector);
            /*rotationMask_f = new Vector3(0, transform.position.y * 0.025f, 
                                                transform.position.z * 0.025f);*/
            /*}
            else
            {
               rotationMask_f = Vector3.back;
            }
            transform.RotateAround(attractedPlanet.transform.position, rotationMask_f,
               100.0f * Time.deltaTime);*/
        }
        else
        {
          
                // Move control normal
                transform.position += Vector3.right * speed * Time.deltaTime;
            
        }
    }
    
}
