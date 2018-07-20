using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private GameObject _entity;
    private Touch initTouch;

    // Use this for initialization
    void Start() {

    }


    public GameObject entity 
    {
        get
        {
            return _entity;
        }
        set 
        {
            _entity = entity;
        }
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Touch t = new Touch();
            Debug.Log("input touches active");
            if (t.phase == TouchPhase.Began)
            {
                initTouch = t;
            }
            else if (t.phase == TouchPhase.Moved)
            {
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));
                bool swipLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                if(distance > 50f ){
                    if (swipLeft && xMoved > 0 ) // swiped left
                    {
                        _entity.transform.Translate(-5, 0, 0);
                    }
                    else if(swipLeft && xMoved < 0 ) // swiped right 
                    {
                        _entity.transform.Translate(5, 0, 0);
                    }
                    else if (swipLeft == false && yMoved > 0 ) // swiped up 
                    {
                       _entity.transform.Translate(0, 5, 0);
                    }
                    else if (swipLeft == false && yMoved < 0) // swiped down
                    {
                        _entity.transform.Translate(0, -5, 0);
                    }
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                Debug.Log("new Touch porcess");
            }
        }
    }
}
