using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	
	// script of capsule
	private capsuleScript capsuleScript;
    // Vector 3 to store value of capsule position.
	private Vector3 capsulePostion;
    
	// Unity GameObject capsule
	public GameObject capsule;
   
    // Use this for initialization
    void Start () {
        capsuleScript = capsule.GetComponent<capsuleScript>();
    }
	
	// Update is called once per frame
	void Update () {
	    /* if capsule object started to fly, camera folowing it.
		/!\ Here is for a test, it should be better to parent object /!\
		*/
		if (capsuleScript.detached)
        {
                capsulePostion = capsule.transform.position;
                // preserve a gap distance between a camera and object, if we parent the two object
				// it will be better, to get a freedom move range for camera.
				transform.position = new Vector3(capsulePostion.x, capsulePostion.y, -60.1f);
                transform.LookAt(capsule.transform);
          

        }
    }
}
