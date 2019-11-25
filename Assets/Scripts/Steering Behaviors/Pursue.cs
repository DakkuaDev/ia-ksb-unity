using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : SeekSB
{

    public Transform targetPosition;

    float maxPredictionTime = 10;
    float speed = 3.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        var target = targetPosition.GetComponent<Movimiento>();

        var vel = GetForce(targetPosition.position, Vector3.forward * target.moveSpeed);
        transform.position += vel;

        transform.LookAt(targetPosition); // Girar hacia el Player

    }

    public Vector3 GetForce(Vector3 targetPosition, Vector3 targetVelocity)
    {
        Vector3 dir = targetPosition - transform.position;
        float predictionTime = 0;

        Vector3 vel = (targetPosition - transform.position).normalized * speed;

        if (vel.magnitude <= Vector3.Distance(vel,dir) / maxPredictionTime)
        {
            predictionTime = maxPredictionTime;
        }
        else
        {
            predictionTime = dir.magnitude / vel.magnitude;
        }

        return GetVelocity(targetPosition + targetVelocity * predictionTime); // lo subscribo a la función de GetVelocity() del SeekSB

    }

    

  
}
