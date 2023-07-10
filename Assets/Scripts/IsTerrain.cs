using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTerrain : MonoBehaviour
{
	public float currentHealth;

	private SpriteRenderer sr;
	public List<Sprite> sprites;

	private bool timerStarted;
	private float timer;

	private void Start()
	{
		currentHealth = Stats.terrainHealth;
		sr = GetComponent<SpriteRenderer>();

		timer = 2.0f;

		sr.sprite = sprites[Random.Range(0, sprites.Count)];
	}

	private void Update()
	{
		if(timerStarted)
		{
			timer -= Time.deltaTime;

			sr.color = new Color(1, 1, 1, timer / 2.0f);
			transform.rotation = Quaternion.Euler(Mathf.Lerp(90, 0, timer / 2.0f), 0, 0);

			if(timer <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Tomato"))
		{
			currentHealth -= Stats.tomatoDamage * Stats.terrainDamageScalar;
		}

		if(currentHealth <= 0)
		{
			Destroy(GetComponent<BoxCollider>());

			timerStarted = true;
		}
	}

	public float GetHealthPercentage()
	{
		return currentHealth / Stats.terrainHealth;
	}
}
