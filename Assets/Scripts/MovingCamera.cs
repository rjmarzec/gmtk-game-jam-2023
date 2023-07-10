using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	public Vector3 startingPosition;
	private Vector3 endingPosition;
	public GameController gc;

	private void Start()
	{
		endingPosition = new Vector3(startingPosition.x, startingPosition.y, Stats.distance - 17.0f);
	}

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
