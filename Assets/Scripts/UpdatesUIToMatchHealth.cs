using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatesUIToMatchHealth : MonoBehaviour
{
    private RectTransform rt;
    private Image image;
    public ActorHealth ah;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        if(ah.GetHealthPercentage() > 0)
        {
			rt.anchorMax = new Vector2(ah.GetHealthPercentage(), 1);
		}
        else
        {
            image.color = Color.cyan;
			rt.anchorMax = new Vector2(-ah.GetHealthPercentage()*5, 1);
		}
    }
}
