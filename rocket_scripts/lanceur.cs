using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceur : MonoBehaviour {

    public GameObject vectorRepresent;
    public GameObject capsule;

    
    // Constante permettannt de regler les controle 
    private const int MULTIPLICATEUR_INVERSE = -10;
    private const int MULTIPLICATEUR = 10;
    private const float MAX_THRUST = 60;
    int upperMult;
    float thrustVector; //change vector to powerSet 

    private float accelerate;

    private Vector3 rotation;
    private Vector3 position;

    private capsuleScript capsuleScript;
    private bool launch, control, capsuleLaunched,crash;
    private bool rotating = true;
    private Rigidbody capsuleRigidBody;

    // Use this for initialization
    void Start () {
        /*
		LAUNCHER SCRIPT:
		It's control rocket, 
		it will determinate if rocket going to crash or not
		*/
		
		thrustVector = 0;
        launch = false;
        control = true;
        capsuleLaunched = false;
        accelerate = 0;
        capsuleScript = capsule.GetComponent<capsuleScript>();
        capsuleRigidBody = capsule.GetComponent<Rigidbody>();
        crash = false;
    }

    

    void DrawForce(Vector3 fromPosition)
    {
        Vector3 scale = new Vector3(0, fromPosition.y, 0);
        // beter thing to do here
        // set the spring velocity
        thrustVector =  fromPosition.y * 0.25f ;
    }

    void DrawDirection(Vector3 fromPosition)
    {
        
        // Vector3 fromPosition: vector3 with delta from click to drag
        // This proc draw the orientation way of projectile
        
        Vector3 to  = new Vector3(0, 0, fromPosition.x * MULTIPLICATEUR_INVERSE);

        // if value is close to 0 we stop the rotation
        // else we draw it
        if (Vector3.Distance(vectorRepresent.transform.eulerAngles, to) > 0.01f)
        {
            vectorRepresent.transform.eulerAngles = Vector3.Lerp(
                transform.rotation.eulerAngles, to, Time.deltaTime);
        }
        else
        {
            vectorRepresent.transform.eulerAngles = to;
        }
    }

    private void OnMouseDown()
    {
        if (control) position = Input.mousePosition;   
    }
    
    private void OnMouseUp()
    {
        capsuleRigidBody.useGravity = true;
        capsule.transform.eulerAngles = vectorRepresent.transform.eulerAngles;
        if (thrustVector > MAX_THRUST) { thrustVector = MAX_THRUST;}
        launch = true;
        control = false;
    }
    
    private void Takeoff()
    {
    if (thrustVector > accelerate)
    {
       if (thrustVector > MAX_THRUST) thrustVector = MAX_THRUST;
       while (accelerate < thrustVector)
        {
            accelerate += 0.01f;
            capsule.transform.Translate(Vector3.up * accelerate * Time.deltaTime);
            if (accelerate > thrustVector)
                {
                    capsule.transform.Translate(Vector3.up * accelerate * Time.deltaTime);
                    break;
                }
        }
    }
   
    
}

    private void OnMouseDrag()
    {
        if (control)
        {
            DrawDirection(position - Input.mousePosition);
            DrawForce(position - Input.mousePosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Here is a test
		to determinate if  rocket going to crash or not */
		if (!(capsuleLaunched)) {
            if (launch) {
                if (accelerate < thrustVector)
                {
                   accelerate += 1;
                    capsule.transform.Translate(Vector3.up * accelerate * Time.deltaTime);
                    // if capsule reach flight unit 9 and vertical velocitu is less than 9 
					if (capsule.transform.position.y > 9 && capsuleRigidBody.velocity.y < -9)
                    {
                        // capsule maintain acceleration and it's launched
						Debug.Log("###################[ DETACHED CAPSULE FROM LANCEUR ] ########################");
                        capsuleScript.accelerate = accelerate;
                        capsuleLaunched = true;
                    }
                                     
                    if (accelerate > thrustVector)
                    {
                        // if acceleration isn't enought we cut up force and let 
						// the rocket smash on the ground
						Debug.Log("accelerate > thrustVector");
                        capsule.transform.Translate(Vector3.up * 0);
                        if (!crash)
                        {
                            capsuleScript.crashBehavior(true);
                            crash = true;
                 
                        }
                   }
                }
            }
        }
    }
}
