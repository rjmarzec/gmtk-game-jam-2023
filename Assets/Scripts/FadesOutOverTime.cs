using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadesOutOverTime : MonoBehaviour
{
    public float fadeTime;
    private float timeRemaining;
    private Image image;

    void Start()
    {
        timeRemaining = fadeTime;
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.color = new Color(0, 0, 0, timeRemaining / fadeTime);

        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
