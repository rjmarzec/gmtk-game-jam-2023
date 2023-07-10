using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAudienceMember : MonoBehaviour
{
    private Vector3 startingPosition;
    private float timeOffset;
    private float speedScalar;

    void Start()
    {
        startingPosition = transform.position;
        timeOffset = Random.Range(0.0f, 1.0f);
        speedScalar = Random.Range(0.5f, 2.0f);
    }

    void Update()
    {
        transform.position = startingPosition + Vector3.up * (1 + Mathf.Sin(Time.time * ((1 + ((float)Stats.stageNumber) / 10) * speedScalar) + timeOffset)) * 0.5f;
    }
}
