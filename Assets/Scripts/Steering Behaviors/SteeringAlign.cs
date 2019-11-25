using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// LO CONSIGO UTILIZANDO LA POSICIÓN DE GIRO. ME FALTA CONSEGUIR QUE EN VEZ DE LA POSICIÓN, OBTENGA LA VELOCIDAD ANGULAR
public class SteeringAlign : MonoBehaviour
{
    public Transform TargetPosition;

    public float maxRotation = 360.0f;
    public float targetRadius = 5;
    public float slowRadius = 50;
    public float timeToTarget = 0.1f;
    public float rotation = 0;

    //private float rotation = 0f;

    // Update is called once per frame
    void Update()
    {
        var npcRotation = GetTargetRotation(rotation);
        transform.Rotate(0,  npcRotation  * maxRotation * Time.deltaTime, 0);

    }
      
    /*
     Desc:: Cálculo del ángulos más corto entre dos vectores
     func '.Sign' :: Devuelve 1 si el float es negativo, -1, si es positivo
     func '.Cross' :: Devuelve un tercer vector de esos dos. Un producto escalar
    */
    public static float SignedAngle(Vector3 v1, Vector3 v2)
    {
        return Vector3.Angle(v1, v2) * Mathf.Sign(Vector3.Cross(v1, v2).y);
    }

    protected float GetTargetRotation(float rotation)
    {
        /*
          GetComponent<>(); obtiene el componente de Unity que queramos usar para modificar via código. Si fuese un componente nuestro, usaríamos esto directamente.
          Como se trata de una referencia a un componente externo (El del Player), lo referenciamos antes de GetComponent, es decir TargetPosition.GetComponent<componente>();
         */
       
        var npc = TargetPosition.GetComponent<Transform>();
        var npc_angularMaxSpeed = TargetPosition.GetComponent<Movimiento>();
        var rb = GetComponent<Transform>();

        rotation = npc.eulerAngles.magnitude;
        Debug.Log("Mi rotación(ángulo):  " + rotation);
        var targetRotation = 0f;
        var rotAbs = Mathf.Abs(rotation); // Recoge el valor absoluto (positivo siempre)

 

        if (rotAbs < targetRadius)
        {
            return 0;
        }

        if (rotAbs > slowRadius)
        {
            targetRotation = maxRotation;
        }
        else
        {
            targetRotation = maxRotation * rotAbs / slowRadius;
        }

        targetRotation *= Mathf.Sign(rotation);


        var ret = targetRotation - npc.eulerAngles.magnitude;
        ret /= timeToTarget;

        if (Mathf.Abs(ret) > npc_angularMaxSpeed.turnSpeed)
        {
            ret = Mathf.Sign(ret) * npc_angularMaxSpeed.turnSpeed;
        }

        Debug.Log("NpcTurnAcceleration: " + ret);

        return ret;
    }

}
