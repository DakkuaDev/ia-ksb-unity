using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public float speed = 3.5f; // Velocidad fija
    Vector3 direction = Vector3.forward; // Variable vectorial que avanza una unidad en z
    public Transform targetPosition; // Posición del target


    public float closeDistance = 5.0f;
    float OldVelocity;



    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        // Si la velocidad no está a 0 la vamos actualizando en una variable 
        if (speed != 0)
        {
            OldVelocity = speed;
        }
 

        var Vel = GetVelocity(targetPosition.position); // llamamos a nuestra función de velocidad

        transform.position += Vel * Time.deltaTime; // Actualizamos la posición de la IA en cada tick

        // Comprobamos si está fuera del ratio de huida
        if (targetPosition)
        {
            // Creamos un vector que una el target y la IA
            Vector3 offSet = targetPosition.position - transform.position;

            // sacamos su módulo pasándolo a float
            float sqrLen = offSet.sqrMagnitude;

            //Comprobamos si es mayor que lo que deseamos (multiplicamos dos veces para quitar el cuadrado)
            if(sqrLen > closeDistance * closeDistance)
            {
                speed = 0; // Si lo es, lo seteamos a 0
            }
            else
            {
                speed = OldVelocity; // Si no ponemos, la que tenía
            }
          
        }
    }

    Vector3 GetVelocity(Vector3 targetPosition)
    {
        // Obtenemos la dirección que vamos a seguir calculado un vector del punto target a nosotros
        Vector3 dir = (targetPosition - transform.position).normalized;
        dir.y = 0; // No se mueve en el eje vertical

        return -dir * speed; // devolvemos un FLOAT numérico
    }

    Vector3 GetOrientation(Vector3 targetPosition)
    {
        // devolvemos un VECTOR en la dirección que esta nuestro objetivo
        return -(targetPosition - transform.position).normalized;

    }
}
