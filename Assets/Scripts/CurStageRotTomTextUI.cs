using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurStageRotTomTextUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tmp.text = "CURRENT STAGE: " + Stats.stageNumber + "\nROTTEN TOMATOES: " + Stats.rottenTomatoCount;         
    }
}
