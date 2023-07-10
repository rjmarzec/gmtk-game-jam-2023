using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorHealth : MonoBehaviour
{
    public float currentHealth;

    private SpriteRenderer sr;

    private void Start()
    {
        currentHealth = Stats.actorHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.color = new Color(1, GetHealthPercentage(), GetHealthPercentage());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Tomato"))
        {
            float previousHealthPercentage = GetHealthPercentage();

            currentHealth -= Stats.tomatoDamage;

            if(previousHealthPercentage > 0.0f && GetHealthPercentage() <= 0.0f)
            {
                Stats.rottenTomatoCount += 3;
            }
            if(previousHealthPercentage > -0.2f && GetHealthPercentage() <= -0.2f)
            {
                Stats.rottenTomatoCount += 1;
            }
        }
    }

    public float GetHealthPercentage()
    {
        return currentHealth / Stats.actorHealth;
    }
}
