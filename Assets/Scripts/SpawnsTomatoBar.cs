using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnsTomatoBar : MonoBehaviour
{
    private List<GameObject> tomatoes;
    public GameObject tomatoUIPrefab;
    private int maxTomatoes;

    public ThrowsOnLeftClick tolc;

    void Start()
    {
        maxTomatoes = Stats.tomatoCount;

        tomatoes = new List<GameObject>();
        for(int i = 0; i < maxTomatoes; i++)
        {
            GameObject newTomato = Instantiate(tomatoUIPrefab, transform);

            float ratio = Mathf.Lerp(0, 0.85f, ((float)i) / maxTomatoes);

            newTomato.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, ratio);
			newTomato.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, ratio + 0.15f);

			tomatoes.Add(newTomato);
        }
    }

    void Update()
    {
        if(tolc.tomatoesRemaining < tomatoes.Count)
        {
            GameObject tomatoToRemove = tomatoes[tomatoes.Count - 1];
            tomatoes.Remove(tomatoToRemove);
            Destroy(tomatoToRemove);
        }
    }
}
