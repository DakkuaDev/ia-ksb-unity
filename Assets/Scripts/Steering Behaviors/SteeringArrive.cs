using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringArrive : MonoBehaviour
{
    public float acceleration = 10;
    public float maxSpeed = 10;
    public float targetRadius = 0.5f; // radio de parón
    public float slowRadius = 2; // radio de frenada
    public float timeToTarget = 0.1f;

    Vector3 direction = Vector3.forward;
    public Transform targetPosition;
    Movimiento target = new Movimiento(); // Para obtener la velocidad del Player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var force = GetForce(targetPosition.position);

        transform.position += force * Time.deltaTime;
    }

    Vector3 GetForce(Vector3 targetPosition)
    {
        float targetSpeed = target.moveSpeed; // De aqui llamamos a la variable del Player

        Vector3 dir = targetPosition - transform.position;

        // Si la distancia entre Player e IA es menor que el radio del target impuesto...
        if (dir.sqrMagnitude < targetRadius * targetRadius)
        {
            return Vector3.zero; // Se para la IA
        }

        // Si la distancia entre Player e IA es mayor que el SlowRadious (el radio de frenada)
        if(dir.sqrMagnitude > slowRadius * slowRadius)
        {
            targetSpeed = maxSpeed; // La velocidad del Player será la máxima quepodrá tener la IA
        }
        else
        {
            targetSpeed = maxSpeed * dir.magnitude / slowRadius;
        }

        return dir.normalized * targetSpeed;
    }
}
