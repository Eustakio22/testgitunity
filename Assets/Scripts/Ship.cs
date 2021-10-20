using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform gameCamera;

    public float speed;

    public float depth = 3;

    Vector3 relativePosition;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rp = relativePosition;

        float debugPreviousSpeed = speed;

        if(Switchers.debugMode && Switchers.debugTurboMode)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                debugPreviousSpeed = speed;
                speed = speed * 2;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            rp = rp + Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rp = rp - Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rp = rp + Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rp = rp - Vector3.right * speed * Time.deltaTime;
        }

        rp = new Vector3(rp.x, rp.y, depth);

        relativePosition = rp;

        //transform.position = gameCamera.TransformPoint(relativePosition);
        Vector3 p = gameCamera.TransformPoint(relativePosition);
        rigidBody.MovePosition(p);

        #if _DEBUG_AVAILABLE_
        if (Switchers.debugMode && Switchers.debugTurboMode)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = debugPreviousSpeed;
            }
        }
        #endif
    }
}
