using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatesUIToMatchTime : MonoBehaviour
{
    private RectTransform rt;
    private Image image;
    public GameController gc;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
	}

    void Update()
    {
		rt.anchorMax = new Vector2(gc.GetRemainingGameTimePercentage(), 1);
    }
}
