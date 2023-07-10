using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementStageOnStart : MonoBehaviour
{
	void Start()
    {
        Stats.IncrementStage();
    }
}
