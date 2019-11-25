using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSB : MonoBehaviour
{
    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;

    private Vector3 velocity;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = GetVelocity(target.position);
        transform.position += speed * Time.deltaTime;
        transform.forward = velocity.normalized;

    }

    public virtual Vector3 GetVelocity(Vector3 targetPos)
    {
        // Calculo el vector que va del npc al Player, lo llamaremos "desired velocity"
        var desiredVelocity = target.transform.position - transform.position; 

        // Normalizamos el vector, manteniendo de esta manera la dirección y haciendo que valga 1, y lo multiplicamos por la velocidad que va a llevar
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        // Calculamos el steering: la diferencia entre el vector velocidad(hacia delante) y el vector desired(el que mira al Player)
        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        // Actualizamos el vector velocidad con la nueva posición hacia donde mira el npc
        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);

        return velocity;

    }

    public virtual Vector3 GetRotation(Vector3 targetPos)
    {
        return Vector3.zero;
    }
}
