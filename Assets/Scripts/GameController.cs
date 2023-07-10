using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public float pregameStageTime = 3.0f;
	public float remainingPregameTime;

	public float gameStageTime;
    public float remainingGameTime;

	public float postgameStageTime = 5.0f;
	public float remainingPostgameTime;

	public ActorHealth ah;
	public ThrowsOnLeftClick tolc;

	void Start()
    {
		Stats.gameState = Stats.GameState.PreGame;

		remainingPregameTime = pregameStageTime;
		remainingGameTime = gameStageTime;
		remainingPostgameTime = postgameStageTime;
    }

    void Update()
    {
        if(Stats.gameState == Stats.GameState.PreGame)
        {
			float previousPregameTime = remainingGameTime;
			remainingPregameTime -= Time.deltaTime;

			if(remainingPregameTime <= 0)
			{
				Stats.gameState = Stats.GameState.Game;
			}
		}
		else if (Stats.gameState == Stats.GameState.Game)
		{
			remainingGameTime -= Time.deltaTime;
			if (ah.GetHealthPercentage() <= 0)
			{
				remainingGameTime -= Time.deltaTime * 1.0f;
			}
			if (tolc.tomatoesRemaining <= 0)
			{
				remainingGameTime -= Time.deltaTime * 9.0f;
			}

			if (remainingGameTime <= 0 || ah.GetHealthPercentage() <= -0.2f)
			{
				Stats.gameState = Stats.GameState.PostGame;
			}
		}
		else if (Stats.gameState == Stats.GameState.PostGame)
		{
			remainingPostgameTime -= Time.deltaTime;

			if(remainingPostgameTime <= 0)
			{
				if (ah.GetHealthPercentage() <= 0)
				{
					Stats.gameState = Stats.GameState.Upgrades;
					SceneManager.LoadScene("UpgradeScene");
				}
				else
				{
					Stats.gameState = Stats.GameState.GameOver;
					SceneManager.LoadScene("GameOverScene");
				}
			}
		}
	}

    public float GetRemainingGameTimePercentage()
    {
        return remainingGameTime / gameStageTime;
    }
}
