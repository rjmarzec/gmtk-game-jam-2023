using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesToActorNextPosition : MonoBehaviour
{
    public MovingActor movingActor;

    [Range(0.0f, 1.0f)]
    public float movementSpeed;

    private float startingY;

    private void Start()
    {
        startingY = transform.position.y;
    }

    void Update()
    {
        if(movingActor.remainingWaitingTime <= movingActor.minWaitingTime + 1)
		{
			transform.position += (movingActor.nextPosition - transform.position) * movementSpeed * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
		}
	}
}
