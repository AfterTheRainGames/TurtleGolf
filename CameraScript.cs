using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform turtle;
    public Transform puddle1;
    public Transform puddle2;
    public Transform puddle3;
    public Transform puddle4;
    public Rigidbody turtlerb;
    public Turtle turtleScript;
    private Vector3 smoothVelocity;
    private float maxDegreesDelta;

    void Update()
    {
        Vector3 oldPosition = transform.position;
        Quaternion oldRotation = transform.rotation;

        Vector3 offsetP = new Vector3(-5, 10, -5);              //Turtle cam position
        Quaternion offsetR = Quaternion.Euler(45, 45, 0);

        Vector3 offsetP1 = new Vector3(-50, 73, 80);            //Puddle 1 cam position
        Quaternion offsetP1R = Quaternion.Euler(45, 135, 0);

        Vector3 offsetP2 = new Vector3(-20, 73, -50);            //Puddle 1 cam position
        Quaternion offsetP2R = Quaternion.Euler(45, 0, 0);

        Vector3 offsetP3 = new Vector3(-50, 73, 80);            //Puddle 1 cam position
        Quaternion offsetP3R = Quaternion.Euler(45, 135, 0);

        Vector3 offsetP4 = new Vector3(-50, 73, 80);            //Puddle 1 cam position
        Quaternion offsetP4R = Quaternion.Euler(45, 135, 0);

        if (!turtleScript.inWater)
        {
                transform.position = turtle.position + offsetP;
                transform.rotation = offsetR;
                Time.timeScale = 2.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        if(turtleScript.inPuddle1  && turtleScript.inWater)
        {
            transform.position = puddle1.position + offsetP1;
            transform.rotation = offsetP1R;
        }
        if (turtleScript.inPuddle2 && turtleScript.inWater)
        {
            transform.position = puddle2.position + offsetP2;
            transform.rotation = offsetP2R;
        }
        if (turtleScript.inPuddle3 && turtleScript.inWater)
        {
            transform.position = puddle3.position + offsetP3;
            transform.rotation = offsetP3R;
        }
        if (turtleScript.inPuddle4 && turtleScript.inWater)
        {
            transform.position = puddle4.position + offsetP4;
            transform.rotation = offsetP4R;
        }

        Vector3 newPosition = transform.position;
        Quaternion newRotation = transform.rotation;

        float distance = Vector3.Distance(oldPosition, newPosition);

        if (distance >= .01f && turtleScript.inPuddle1 && turtleScript.inWater)
        {
            Vector3 smoothedPosition = Vector3.SmoothDamp(oldPosition, newPosition,ref smoothVelocity, 1f);
            transform.position = smoothedPosition;
            maxDegreesDelta = 90f;
            Quaternion smoothedRotation = Quaternion.RotateTowards(oldRotation, newRotation, maxDegreesDelta * Time.deltaTime);
            transform.rotation = smoothedRotation;
        }
    }
}
