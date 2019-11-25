using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public float maxSpeed = 10;
    public float arrivingRadious = 0.1f;
    public float timeToarrive = 0.5f;

    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = GetVelocity(target.position);

        transform.position += dir * Time.deltaTime;

    }

    public Vector3 GetVelocity(Vector3 targetPosition)
    {
        var distance = targetPosition - transform.position;

        // variable:: sqrMagnitude, nos devuelve la operación sumatorio de la raiz cuadrada del vector al cuadrado
        // De esta manera conseguimos optimizar quitando la raiz cuadrada y elevanto al cuadrado lo de la derecha

        // Si el módulo engtre el target y la IA es menor al radio de llegada, devolvemos un vecto 0; es decir paramos la velocidad de la IA
        if (distance.sqrMagnitude < arrivingRadious * arrivingRadious) return Vector3.zero;

        // en función de la velocidad a la que queramos llegar al target, la distancia se actualiza
        distance /= timeToarrive;


        // Si la el módulo de la distancia no es 0 (es decir el Player se mueve) ,  normalizamos el vector obtenido y lo multiplicamos por nuestra velocidad marcada (normalizamos para que no pueda pasarse de ese valor)
        if (distance.sqrMagnitude > maxSpeed * maxSpeed) distance = distance.normalized * maxSpeed;

        Debug.Log("Distancia(Vector3): " + distance + "    Distancia(Módulo):" + distance.magnitude);

        return distance;
    }
}
