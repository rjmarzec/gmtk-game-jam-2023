using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsTerrain : MonoBehaviour
{
    public float minX, maxX, y, minZ, maxZ;
    public GameObject terrainPrefab;
    public Transform terrainParent;

    void Start()
    {
        for(int i = 0; i < Stats.terrainCount; i++)
        {
            GameObject newTerrain = Instantiate(terrainPrefab, terrainParent);
            newTerrain.transform.position = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
        }
    }
}
