using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsAudience : MonoBehaviour
{
	public float minX, maxX, y, minZ;
	private float maxZ;
	public GameObject audiencePrefab;
	public Transform audienceParent;

	void Start()
	{
		maxZ = Stats.distance + 2.0f;

		for (int i = 0; i < Stats.stageNumber*5 + 3; i++)
		{
			GameObject newTerrain = Instantiate(audiencePrefab, audienceParent);
			newTerrain.transform.position = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
		}
	}
}
