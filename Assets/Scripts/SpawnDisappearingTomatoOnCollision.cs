using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDisappearingTomatoOnCollision : MonoBehaviour
{
    public GameObject disappearingTomatoPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newTomato = Instantiate(disappearingTomatoPrefab);
        newTomato.transform.position = collision.GetContact(0).point + Vector3.back * 0.25f;
        newTomato.transform.rotation = transform.rotation;
        newTomato.transform.localScale = transform.localScale;

        if(collision.gameObject.name == "Actor")
        {
            newTomato.transform.parent = collision.transform;
            newTomato.transform.position += Vector3.back * 0.25f;
        }
        else
		{
			newTomato.transform.parent = transform.parent;
		}

        Destroy(gameObject);
    }
}
