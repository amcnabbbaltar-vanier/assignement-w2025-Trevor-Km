using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerFloater : MonoBehaviour
{


    public float floatSpeed = 8f; // Speed at which the power up floats at
    public float floatHeight = 0.5f; // Height at which the power up floats at


     private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z); 
    }
}
