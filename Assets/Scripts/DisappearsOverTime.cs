using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearsOverTime : MonoBehaviour
{
    public float timeToDisappear;
    private float currentTime;
    private SpriteRenderer sr;

    private void Start()
    {
        currentTime = timeToDisappear;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            Destroy(gameObject);
        }

		float newAlpha = currentTime / timeToDisappear;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
    }
}
