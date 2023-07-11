using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip upgradeSuccessfulClip;
	public AudioClip upgradeFailedClip;

    public UpgradeManager.UpgradeType upgradeType;

	public enum UpgradeType { ExtraTime, PlayerSpeed, PropDamage, TomatoCount, TomatoDamage, TomatoSize, TomatoSpeed };

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void Upgrade()
    {
        if(Stats.rottenTomatoCount >= 3)
        {
			audioSource.PlayOneShot(upgradeSuccessfulClip);
            Stats.rottenTomatoCount -= 3;

			if (UpgradeManager.UpgradeType.ExtraTime == upgradeType)
			{
                Stats.gameTime += 15.0f;
			}
			else if (UpgradeManager.UpgradeType.PlayerSpeed == upgradeType)
			{
				Stats.playerMovespeed += 3.0f;
			}
			else if (UpgradeManager.UpgradeType.PropDamage == upgradeType)
			{
				Stats.terrainDamageScalar += 0.5f;
			}
			else if (UpgradeManager.UpgradeType.TomatoCount == upgradeType)
			{
				Stats.tomatoCount += 10;
			}
			else if (UpgradeManager.UpgradeType.TomatoDamage == upgradeType)
			{
				Stats.tomatoDamage += 1.0f;
			}
			else if (UpgradeManager.UpgradeType.TomatoSize == upgradeType)
			{
				Stats.tomatoSizeScalar += 0.5f;
			}
			else if (UpgradeManager.UpgradeType.TomatoSpeed == upgradeType)
			{
				Stats.tomatoSpeed *= 1.5f;
			}
		}
        else
        {
			audioSource.PlayOneShot(upgradeFailedClip);
        }
    }
}
