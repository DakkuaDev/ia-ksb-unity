using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * moveSpeed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * -moveSpeed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up, -turnSpeed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
        }
            

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up, turnSpeed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }

    }
}
