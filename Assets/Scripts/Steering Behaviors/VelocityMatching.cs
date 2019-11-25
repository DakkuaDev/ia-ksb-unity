using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatching : MonoBehaviour
{
    public float timeToTarget = 10;
    public float maxAcceleration = 10;

    public Transform targetPosition;


    // Update is called once per frame
    void Update()
    {
        var ret = GetForce(targetPosition.position);

        transform.position += ret;

    }

    public Vector3 GetForce(Vector3 targetVelocity)
    {
        var npc = targetPosition.GetComponent<Movimiento>();

        Vector3 ret = Vector3.zero;
        ret = targetPosition.position - transform.position;
        ret /= timeToTarget;

        if(ret.sqrMagnitude > maxAcceleration * maxAcceleration)
        {
            ret = ret.normalized * maxAcceleration;
        }

        return ret;

    }

    
}
