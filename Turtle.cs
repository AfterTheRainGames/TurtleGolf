using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{

    private Rigidbody rb;
    public Rigidbody rockRB;
    public GameObject rock;
    public GameObject Puddle1;
    public GameObject Puddle2;
    public GameObject Puddle3;
    public GameObject Puddle4;
    private Animator animator;
    public Ripple rippleScript;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    public float rippleForce;
    public GameObject congratsMessage;

    public bool inWater;
    public bool inPuddle1;
    public bool inPuddle2;
    public bool inPuddle3;
    public bool inPuddle4;
    public bool turtleRetry;
    public bool inOcean;

    private AudioSource audioSource;
    public AudioClip splash;

    private float WL; //Water Level

    private float A = 5f; //Inital Amplitude 
    private float D = 0.1f; //Decay
    private float W = 2f; //Angular Frequency
    private float newA;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
        inOcean = false;
        congratsMessage.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puddle1"))
        {
            inWater = true;
            inPuddle1 = true;
            inPuddle2 = false;
            inPuddle2 = false;
            inPuddle4 = false;
            audioSource.PlayOneShot(splash);
        }
        if (other.CompareTag("Puddle2"))
        {
            inWater = true;
            inPuddle2 = true;
            inPuddle1 = false;
            inPuddle3 = false;
            inPuddle4 = false;
        }
        if (other.CompareTag("Puddle3"))
        {
            inWater = true;
            inPuddle3 = true;
            inPuddle1 = false;
            inPuddle2 = false;
            inPuddle4 = false;
        }
        if (other.CompareTag("Puddle4"))
        {
            inWater = true;
            inPuddle4 = true;
            inPuddle1 = false;
            inPuddle2 = false;
            inPuddle3 = false;
        }
        if (other.CompareTag("Ocean"))
        {
            inOcean = true;
            inPuddle1 = false;
            inPuddle2 = false;
            inPuddle3 = false;
            inPuddle4 = false;
            congratsMessage.SetActive(true);
        }
        if (other.CompareTag("Ripple"))
        {
            inWater = false;
            rb.useGravity = true;
            Vector3 rockPosition = rock.transform.position;
            rockPosition.y = 0;
            rippleForce = -rippleScript.SliderY.value * 4;
            Vector3 direction = (rockPosition - transform.position).normalized;
            rb.AddForce(direction* rippleForce, ForceMode.Impulse);
            Debug.Log(rippleForce);

            GameObject[] rippleClones = GameObject.FindGameObjectsWithTag("Ripple");
            
            foreach (GameObject ripple in rippleClones)
            {
                Destroy(ripple);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && !inWater)
        {
            Buoyancy();
            turtleRetry = true;
            rippleScript.rippleSpawned = false;
        }
        else
        {
            turtleRetry = false;
        }
    }

    void FixedUpdate()
    {
        Debug.Log(inWater);
        if(inWater)
        {
            if (inPuddle1)
            {
                WL = Puddle1.transform.position.y;
            }
            if (inPuddle2)
            {
                WL = Puddle2.transform.position.y;
            }
            if (inPuddle3)
            {
                WL = Puddle3.transform.position.y;
            }
            if (inPuddle4)
            {
                WL = Puddle4.transform.position.y;
            }
            Buoyancy();
        }

    }
    void Buoyancy()
    {
        rb.useGravity = false;
        newA = Mathf.Abs(rb.velocity.y) / A;
        float t = Time.fixedTime;

        float newY = (newA) * Mathf.Exp(-D * t) * Mathf.Sin(W * t) + WL;

        Vector3 newPosition = transform.position;
        newPosition.y = newY; 
        transform.position = newPosition;
    }
}
