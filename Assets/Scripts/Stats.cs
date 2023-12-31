using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public static int stageNumber;
	public static int highScore;
	public enum GameState { MainMenu, PreGame, Game, PostGame, Upgrades, GameOver }
	public static GameState gameState;

	public static float gameTime;
	public static float distance;

	public static float actorHealth;
	public static float actorSpeedScalar;
	public static float playerMovespeed;

	public static float tomatoSpeed;
	public static float tomatoDamage;
	public static float tomatoSizeScalar;
	public static int tomatoCount;

	public static float distanceFromStage;
	public static float terrainHealth;
	public static float terrainCount;
	public static float terrainDamageScalar;

	public static int rottenTomatoCount;

	private void Start()
	{
		stageNumber = 1;
		gameState = GameState.MainMenu;

		gameTime = 30;
		distance = -30;

		actorHealth = 100;
		actorSpeedScalar = 2.0f;
		playerMovespeed = 1.0f;

		tomatoSpeed = 100;
		tomatoDamage = 10;
		tomatoSizeScalar = 1;
		tomatoCount = 20;

		terrainHealth = 5;
		terrainCount = 1;
		terrainDamageScalar = 1;

		rottenTomatoCount = 0;
	}

	public static void IncrementStage()
	{
		if(stageNumber > highScore)
		{
			highScore = stageNumber;
		}

		stageNumber += 1;
		gameTime += 1;
		distance -= 2;
		tomatoCount += 1;
		tomatoSpeed += 2;

		actorHealth += 5;
		actorHealth *= 1.03f;
		actorSpeedScalar *= 1.05f;

		terrainHealth += 1;
		terrainHealth *= 1.01f;
		if (stageNumber % 3 == 0)
		{
			terrainCount += 1;
		}
	}
}
