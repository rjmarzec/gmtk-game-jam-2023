using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadesInOut : MonoBehaviour
{
	public GameController gc;
	private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (Stats.gameState == Stats.GameState.PreGame)
        {
            float factor = gc.remainingPregameTime * gc.remainingPregameTime / gc.pregameStageTime;
			image.color = new Color(0, 0, 0, factor);
        }
        else if (Stats.gameState == Stats.GameState.Game)
        {
            image.color = Color.clear;

		}
        else if (Stats.gameState == Stats.GameState.PostGame)
        {
            float factor = gc.remainingPostgameTime / gc.postgameStageTime;
			image.color = new Color(0, 0, 0, 1 - (factor * factor));
		}
    }
}
