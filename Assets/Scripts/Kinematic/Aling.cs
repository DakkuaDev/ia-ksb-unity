using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aling : MonoBehaviour
{
    public Transform TargetPosition;

    // Update is called once per frame
    void Update()
    {
        // var npcRotation = GetTargetRotation(rotation);
        // transform.Rotate(0,  npcRotation  * maxRotation * Time.deltaTime, 0);

        var rot = Quaternion.FromToRotation(transform.forward, TargetPosition.forward);

        transform.rotation = rot * transform.rotation;

        Debug.Log(transform.rotation);
    }

}
