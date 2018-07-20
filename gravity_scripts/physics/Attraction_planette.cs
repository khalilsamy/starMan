using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction_planette : MonoBehaviour {

    public GameObject spaceShip;
    public Rigidbody attractedToRigidBody;
    private float limitAttraction;
    public float strengthOfAttraction = 5.0f;
    public float spherRadius;

    private Spaceship spaceShipScipt;
    private float catched;
   

    void Start() {
        spaceShipScipt = spaceShip.GetComponent<Spaceship>();
        spherRadius = GetComponent<SphereCollider>().radius;
        limitAttraction = spherRadius * 5;
        catched = spherRadius * 3;
    }

    void Update()
    {
        float distance = Vector3.Distance(spaceShip.transform.position, transform.position);

        if (distance < limitAttraction)
        {
            Debug.Log("distance < limitAttraction");
            if (distance < catched)
            {
                Debug.Log("distance < catched ");
                spaceShipScipt.attractedPlanet = gameObject;
                spaceShipScipt.attracted = true;
            }
            else
            {
                Vector3 direction = transform.position - spaceShip.transform.position;
                attractedToRigidBody.AddForce(strengthOfAttraction * direction);

            }
        }
      
    }
 }

