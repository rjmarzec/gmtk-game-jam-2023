using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesLRWithAD : MonoBehaviour
{
    public float maxX;

	private void Start()
	{
		transform.position = Vector3.up * 2 + Vector3.forward * Stats.distance;
	}

	void Update()
    {
        if(Stats.gameState == Stats.GameState.Game || Stats.gameState == Stats.GameState.PostGame)
        {
			float movementDistance = Stats.playerMovespeed * Time.deltaTime;

			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				if (transform.position.x - movementDistance < -maxX)
				{
					transform.position = new Vector3(-maxX, transform.position.y, transform.position.z);
				}
				else
				{
					transform.position += Vector3.left * movementDistance;
				}
			}

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				if (transform.position.x + movementDistance > maxX)
				{
					transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
				}
				else
				{
					transform.position += Vector3.right * movementDistance;
				}
			}
		}
	}
}
