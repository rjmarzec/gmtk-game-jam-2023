using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingActor : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audienceCheer;
    public AudioClip audienceBoo;

    public Vector3 currentPosition;
    public Vector3 nextPosition;
    public float minX, maxX, minZ, maxZ;

    public float remainingWaitingTime;
    public float minWaitingTime;
    public float maxWaitingTime;

    public float movementSpeed;
    public float minMovementSpeed;
    public float maxMovementSpeed;

    private bool done;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

		PickNewLocation();
        currentPosition = nextPosition;
        PickNewLocation();
		PickNewWaitingTime();
        PickNewMovementSpeed();

        done = false;
	}

    void Update()
    {
        remainingWaitingTime -= Time.deltaTime;

        if(remainingWaitingTime <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, movementSpeed*Time.deltaTime*Stats.actorSpeedScalar);
            if(transform.position == nextPosition)
            {
                PickNewLocation();
                PickNewWaitingTime();
                PickNewMovementSpeed();
            }
		}

        if(Stats.gameState == Stats.GameState.PostGame && !done)
        {
            done = true;

            audioSource.Pause();

            if(GetComponent<ActorHealth>().currentHealth <= 0)
            {
                audioSource.PlayOneShot(audienceBoo, 1);
            }
            else
            {
                audioSource.PlayOneShot(audienceCheer, 1);
            }
        }
    }

    void PickNewLocation()
    {
        float xPosition = Random.Range(minX, maxX);
        float zPosition = Random.Range(minZ, maxZ);

        nextPosition = new Vector3(xPosition, transform.position.y, zPosition);
    }

    void PickNewWaitingTime()
    {
        remainingWaitingTime = Random.Range(minWaitingTime, maxWaitingTime);
    }

    void PickNewMovementSpeed()
    {
        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
    }
}
