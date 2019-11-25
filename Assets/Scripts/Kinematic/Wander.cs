using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float speed = 2f;
    public float maxRotation = 45;


    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // .value -> Devuelve un valor entre 0 y 1
        float binomialRandom = (Random.value - Random.value);

        // bonomialRandom * maxRotation -> Al ser un 0,x multiplicado por el valor de rotación; obtendremos un valor comprendido entre 0 y el máximo ángulo impuesto
        transform.Rotate(0, binomialRandom * maxRotation * Time.deltaTime, 0);
        // Argum:: (Rotacion en x, Rotacion en y, Rotacion en Z) * myDirection


        var Vel = GetVelocity(targetPosition.position);
        transform.position += Vel * Time.deltaTime;

        Debug.Log("Velocidad: " + Vel);

    }

    Vector3 GetVelocity(Vector3 targetPosition)
    {
        var dir = transform.forward * speed;
        dir.y = 0;
        return dir;
        
    }

}
