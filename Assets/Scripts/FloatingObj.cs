using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObj : MonoBehaviour
{
    [Range(0, 5)]
    public float verticalSpeed;
    [Range(0, 2)]
    public float amplitude;
    [Range(0, 20)]
    public float rotationSpeed;
    private Vector3 originalPos;
    private Vector3 tempPosition;

    void Start()
    {
        
        originalPos = transform.position;
        tempPosition = originalPos;
    }

    void FixedUpdate()
    {
        tempPosition = originalPos;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }
}
