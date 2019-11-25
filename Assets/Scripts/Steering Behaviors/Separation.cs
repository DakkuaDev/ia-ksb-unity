using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{
    public Transform[] targetsPosition; // Target de los que se deberá separar
    public float threshold = 2f; // Distancia de seguridad
    public float decayCoef = 0.01f; // rebote hacia atrás (no se puede notar)
    public float maxAcceleration = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var vel = GetAcceleration();

        transform.position += vel;
    }

    public Vector3 GetAcceleration()
    {
        var ret = Vector3.zero;

        var thresholdSquared = threshold * threshold; 
        foreach(var t in targetsPosition)
        {
            var direction = t.position - transform.position;
            direction.y = 0;

            var distance = direction.sqrMagnitude;

            if(distance < thresholdSquared){
                var strength = -Mathf.Min(decayCoef * distance, maxAcceleration);
                ret += strength * direction.normalized;
            }
        }

        return ret;
    }
}
