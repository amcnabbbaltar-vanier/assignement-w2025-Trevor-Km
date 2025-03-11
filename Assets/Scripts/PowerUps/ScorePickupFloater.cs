using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupFloater : MonoBehaviour
{
   public float floatSpeed = 1f;
    public float floatHeight = 1f;

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
        float rotationSpeed = 50f;
        Quaternion rotationY = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);
        transform.rotation *= rotationY;
        transform.rotation *= rotationX;
        }
}
