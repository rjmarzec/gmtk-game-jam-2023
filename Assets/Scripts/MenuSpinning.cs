using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpinning : MonoBehaviour
{
	private RectTransform rt;

	private float xSpin, ySpin, zSpin;

    void Start()
    {
        rt = GetComponent<RectTransform>();

        xSpin = Random.Range(90.0f, 360f);
		ySpin = Random.Range(90.0f, 360f);
		zSpin = Random.Range(90.0f, 360f);
	}

    void Update()
    {
        rt.Rotate(xSpin * Time.deltaTime, ySpin * Time.deltaTime, zSpin * Time.deltaTime);

        xSpin += Random.Range(-10.0f, 10.0f) * Time.deltaTime;
		ySpin += Random.Range(-10.0f, 10.0f) * Time.deltaTime;
		zSpin += Random.Range(-10.0f, 10.0f) * Time.deltaTime;
	}
}
