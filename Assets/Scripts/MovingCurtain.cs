using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCurtain : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public GameController gc;

    void Update()
    {
		if (Stats.gameState == Stats.GameState.PreGame)
		{
			float factor = gc.remainingPregameTime / gc.pregameStageTime;
            transform.position = Vector3.Lerp(endingPosition, startingPosition, factor);
		}
		else if (Stats.gameState == Stats.GameState.Game)
		{
            transform.position = endingPosition;

		}
		else if (Stats.gameState == Stats.GameState.PostGame)
		{
			float factor = gc.remainingPostgameTime / gc.postgameStageTime;
			transform.position = Vector3.Lerp(startingPosition, endingPosition, factor);
		}
	}
}
