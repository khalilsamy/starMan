using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject capsule;
    private capsuleScript capsuleScript;
    private Vector3 capsulePostion;
    private float a;
    // Use this for initialization
    void Start () {
        Vector3 initPosition = new Vector3(-2539f, 4549f, 523.53f);
        capsuleScript = capsule.GetComponent<capsuleScript>();
        a = 0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if (capsuleScript.detached)
        {
           /* if (capsule.transform.position.y < 500f)
            {*/
                capsulePostion = capsule.transform.position;
                transform.position = new Vector3(capsulePostion.x, capsulePostion.y, -60.1f);
                transform.LookAt(capsule.transform);
            /*}
            else
            {
                if (a < -34f) a--;
                transform.position = new Vector3(capsulePostion.x, capsulePostion.y + 5, a);
            }*/

        }
        //else
        //{
        // transform.LookAt(capsule.transform);
        //}
    }
}
