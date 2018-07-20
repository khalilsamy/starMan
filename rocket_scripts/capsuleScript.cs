using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class capsuleScript : MonoBehaviour {

   public GameObject camera;
   public float _accelerate;

    private bool _collide;
    private bool _detached;
    private Rigidbody rigidBody;
    private move moveScript;
    private Vector3 _velocity;

    private Transform [] rocketComponent;

    
    // Use this for initialization
    void Start () {
        moveScript = new move();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        _detached = false;
        _accelerate =0f;
        rocketComponent = GetComponentsInChildren<Transform>();
        this._collide = false;
    }
	
	
    // Update is called once per frame
	void Update () {
        if (_accelerate != 0)
        {

            transform.Translate(Vector3.up * Time.deltaTime * _accelerate);
            Debug.Log(gameObject.name);
            moveScript.entity=gameObject;
            rigidBody.useGravity = false;
            _detached = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
        if (other.name != "rocket_part")
        {
            this._collide = true;
            Debug.Log("crash collide = true");
        }
    }

    public void crashBehavior(bool useGravity)
    {
        /*
            -- Crash behavior --
            following case contest rocket crash is different
         */
        foreach (Transform child in transform) {
            Rigidbody childRigidbody = child.GetComponent<Rigidbody>();
            Debug.Log("child: " + child);
            if (useGravity) childRigidbody.useGravity = true;
            childRigidbody.isKinematic = false;
        }
    }

    public bool collide
    {
        get
        {
            return this._collide;
        }
    }

    public bool detached
    {
        get
        {
            return _detached;
        }
    }

    public float accelerate
    {
        get
        {
            return _accelerate;
        }
        set
        {
            _accelerate = value;
        }
    }
}
