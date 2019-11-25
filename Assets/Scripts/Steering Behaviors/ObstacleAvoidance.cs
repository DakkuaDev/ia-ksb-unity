using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Pursue
{
    private float curSpeed;

   // public float speed = 20.0f;
    //public float mass = 5.0f;
   // public float force = 50.0f;
    public float minimumDistToAvoid = 0.5f;
 

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {

        if (GetRayCast())
        {

            Vector3 dir = targetPosition.position - transform.position;
            dir.Normalize();

            transform.position += avoidObstacles(dir);
        }
    }

    bool GetRayCast()
    {

        LayerMask obstacleMask = LayerMask.GetMask("Obstacle");

        // Miro si el rayo proyectado, está triggereando una layer de obstaculo "obstacleMask"
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, minimumDistToAvoid, obstacleMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * minimumDistToAvoid, Color.red);
            Debug.Log("Did Hit");

            
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * minimumDistToAvoid, Color.white);
            Debug.Log("Did not Hit");

            return false;
        }
    }

    public Vector3 avoidObstacles(Vector3 dir)
    {
            Vector3 hitNormal = hit.normal; // obtengo la normal del rayo de colisión para calcular la nueva velocidad
            hitNormal.y = 0.0f;

            //Obtengo el nuevo vector de dirección

            dir = transform.forward + hitNormal * MaxForce;
            return dir;

    }
}
