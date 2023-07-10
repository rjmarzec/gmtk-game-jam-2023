using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
	public AudioClip buttonPressClip;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void Quit()
    {
		audioSource.PlayOneShot(buttonPressClip);
        Application.Quit(); 
    }
}
