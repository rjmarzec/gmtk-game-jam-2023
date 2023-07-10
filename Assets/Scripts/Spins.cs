using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spins : MonoBehaviour
{
    private float rotationSpeed;
    public float minSpeed;
    public float maxSpeed;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        rotationSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
