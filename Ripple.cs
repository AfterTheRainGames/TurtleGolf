using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ripple : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject rock;
    public Rigidbody turtleRB;
    public GameObject turtle;
    public GameObject Puddle1;
    public GameObject Puddle2;
    public GameObject Puddle3;
    public GameObject Puddle4;
    public GameObject ripplePrefab;
    public Transform rockSpawn1;
    public Turtle turtleScript;
    private bool rockFalling;
    public bool rockRetry;
    private bool helpStatus;
    public GameObject helpText;

    public GameObject rockX;
    public GameObject rockY;
    public GameObject rockZ;
    public Slider SliderX;
    public Slider SliderY;
    public Slider SliderZ;
    public TextMeshProUGUI XText;
    public TextMeshProUGUI YText;
    public TextMeshProUGUI ZText;
    public Button dropRock;
    public Button retryButton;
    public Button helpButton;

    private bool inWater;
    private float WL2;

    //private bool inPuddle1;
    //private bool inPuddle2;
    //private bool inPuddle3;
    //private bool inPuddle4;
    public bool rippleSpawned = false;

    private float WL; //Water Level


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = rockSpawn1.position;
        rockX.SetActive(false);
        rockY.SetActive(false);
        rockZ.SetActive(false);
        dropRock.interactable = false;
        rb.useGravity = false; 
        retryButton.interactable = false;
        helpStatus = false;
        helpText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puddle1"))
        {
            inWater = true;
            //inPuddle1 = true;
        }
        if (other.CompareTag("Puddle2"))
        {
            inWater = true;
            //inPuddle2 = true;
        }
        if (other.CompareTag("Puddle3"))
        {
            inWater = true;
            //inPuddle3 = true;
        }
        if (other.CompareTag("Puddle4"))
        {
            inWater = true;
            //inPuddle4 = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && !inWater)
        {
            rockRetry = true;
        }
        else
        {
            rockRetry = false;
        }
    }

    void FixedUpdate()
    {
        helpText.SetActive(helpStatus);
        helpButton.onClick.AddListener(Help);

        if (inWater)
        {
            if (turtleScript.inPuddle1)
            {
                WL = Puddle1.transform.position.y;
            }
            if (turtleScript.inPuddle2)
            {
                WL = Puddle2.transform.position.y;
            }
            if (turtleScript.inPuddle3)
            {
                WL = Puddle3.transform.position.y;
            }
            if (turtleScript.inPuddle4)
            {
                WL = Puddle4.transform.position.y;
            }
            if (!rippleSpawned && inWater && !turtleRB.useGravity)
            {
                SpawnRipple();
            }
            if (rippleSpawned)
            {
                GameObject latestRipple = GameObject.FindWithTag("Ripple");

                if (latestRipple != null)
                {
                    Vector3 newScale = latestRipple.transform.localScale;
                    newScale.x *= 1.05f;
                    newScale.z *= 1.05f;
                    latestRipple.transform.localScale = newScale;
                }
            }
            WL2 = WL + 10;
        }
        retryButton.onClick.AddListener(Retry);

        if (rockRetry || turtleScript.turtleRetry)
        {
            Retry();
            rockRetry = false;
            turtleScript.turtleRetry = false;
            SetUp();
        }
        if (turtleScript.inWater && !rockFalling)
        {
            SetUp();
        }
        if (turtleScript.inOcean)
        {
            retryButton.interactable = false;
            dropRock.interactable = false;
        }
    }
    void SpawnRipple()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 0, transform.position.z);
        float newRipplePositionY = WL + 1;
        spawnPosition.y = newRipplePositionY;

        GameObject newRipple = Instantiate(ripplePrefab, spawnPosition, Quaternion.identity);
        newRipple.tag = "Ripple";
        rippleSpawned = true;
    }
    void EnableRockFalling()
    {
        rockFalling = true;
        dropRock.interactable = false;
        rb.useGravity = true;
        rockX.SetActive(false);
        rockY.SetActive(false);
        rockZ.SetActive(false);
    }

    private float previousSliderXValue = 0f;
    private float previousSliderYValue = 0f;
    private float previousSliderZValue = 0f;

    void AddDeltaX(float newValue)
    {
        float deltaValue = newValue - previousSliderXValue;
        Vector3 rockDropSpot = transform.position;
        if (deltaValue < 0)
        {
            rockDropSpot.x -= Mathf.Abs(deltaValue);
        }
        else
        {
            rockDropSpot.x += deltaValue;
        }
        transform.position = rockDropSpot;
        previousSliderXValue = newValue;
    }
    void AddDeltaY(float newValue)
    {
        float deltaValue = newValue - previousSliderYValue;
        Vector3 rockDropSpot = transform.position;
        if (deltaValue < 0)
        {
            rockDropSpot.y -= Mathf.Abs(deltaValue);
        }
        else
        {
            rockDropSpot.y += deltaValue;
        }
        transform.position = rockDropSpot;
        previousSliderYValue = newValue;
    }
    void AddDeltaZ(float newValue)
    {
        float deltaValue = newValue - previousSliderZValue;
        Vector3 rockDropSpot = transform.position;
        if (deltaValue < 0)
        {
            rockDropSpot.z += Mathf.Abs(deltaValue);
        }
        else
        {
            rockDropSpot.z -= deltaValue;
        }
        transform.position = rockDropSpot;
        previousSliderZValue = newValue;
    }
    void SetUp()
    {
            SliderX.onValueChanged.RemoveAllListeners();
            SliderY.onValueChanged.RemoveAllListeners();
            SliderZ.onValueChanged.RemoveAllListeners();

            SliderX.onValueChanged.AddListener(AddDeltaX);
            SliderY.onValueChanged.AddListener(AddDeltaY);
            SliderZ.onValueChanged.AddListener(AddDeltaZ);
            XText.text = "X";
            YText.text = "Y";
            ZText.text = "Z";
            Vector3 rockDropSpot = transform.position;
            dropRock.interactable = true;
            retryButton.interactable = true;
            rockX.SetActive(true);
            rockY.SetActive(true);
            rockZ.SetActive(true);
            dropRock.onClick.AddListener(EnableRockFalling);
            rb.useGravity = false;
    }
    void Retry()
    {
        if(turtleScript.inPuddle1)
        {
            turtle.transform.position = new Vector3(turtleScript.spawnPosition.x, WL, turtleScript.spawnPosition.z);
            transform.position = rockSpawn1.position;
        }
        if(turtleScript.inPuddle2)
        {
            turtle.transform.position = new Vector3(Puddle2.transform.position.x + 3, WL, turtleScript.Puddle2.transform.position.z);
            transform.position = new Vector3(Puddle2.transform.position.x - 50, WL2, turtleScript.Puddle2.transform.position.z + 50);
        }
        if(turtleScript.inPuddle3)
        {
            turtle.transform.position = new Vector3(Puddle3.transform.position.x + 10, WL, Puddle3.transform.position.z);
            transform.position = new Vector3(Puddle3.transform.position.x + - 50, WL2, turtleScript.Puddle3.transform.position.z + 50);
        }
        if(turtleScript.inPuddle4)
        {
            turtle.transform.position = new Vector3(Puddle4.transform.position.x + 3, WL, Puddle4.transform.position.z);
            transform.position = new Vector3(Puddle4.transform.position.x - 50, WL2, turtleScript.Puddle4.transform.position.z + 50);
        }
            SliderX.value = 0;
            SliderY.value = 0;
            SliderZ.value = 0;
            //inPuddle1 = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            turtleRB.velocity = Vector3.zero;
            turtleRB.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            turtle.transform.rotation = Quaternion.Euler(0, 45, 0);
            inWater = false;
            rippleSpawned = false;
        GameObject[] rippleClones = GameObject.FindGameObjectsWithTag("Ripple");

        foreach (GameObject ripple in rippleClones)
        {
            Destroy(ripple);
        }
    }
    void Help()
    {
        helpStatus = !helpStatus;
    }
}
