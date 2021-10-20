using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if _DEBUG_AVAILABLE_
    using UnityEditor;
#endif

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float speed = 2;

    public float followSpeed = 0.2f;
    public float followDistance = 3;
    public float distance = 3;

    Vector3 playerOffset;
    Vector3 playerOffsetNormalized;
    Vector3 playerOffsetProjected;

    void Start()
    {
        
    }

#if _DEBUG_AVAILABLE_
    private void OnDrawGizmos()
    {
        if (Switchers.debugMode && Switchers.debugShowID)
        {
            Handles.Label(transform.position + new Vector3(0, 0.2f, 0), gameObject.name);
        }

        if (Switchers.debugMode && Switchers.debugShowEnemyFollow)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(transform.position, transform.position + playerOffset);

            if(distance < followDistance)
            {
                Gizmos.DrawLine(transform.position, transform.position + playerOffset);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + playerOffsetProjected);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, transform.position + playerOffsetNormalized);

                Handles.Label(transform.position + new Vector3(0, 0.2f, 0), "Distance: " + distance);
            }

            Gizmos.DrawWireSphere(transform.position, followDistance);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + playerOffsetProjected);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + playerOffsetNormalized);

            Handles.Label(transform.position + new Vector3(0, 0.2f, 0), "Distance: " + distance);
        }

    }
#endif

    void Update()
    {
        transform.position += -Vector3.right * speed * Time.deltaTime;
        if (gameObject.name == "Enemy7")
        {
            transform.position += Vector3.right * speed * Time.deltaTime;


        }

        playerOffset = player.position - transform.position;

        distance = playerOffset.magnitude;

        if(distance < followDistance)
        {
            playerOffsetProjected = new Vector3(0, playerOffset.y, 0);
            playerOffsetNormalized = playerOffset.normalized;

            transform.position += playerOffset * followSpeed * Time.deltaTime;
        }
    }
}
