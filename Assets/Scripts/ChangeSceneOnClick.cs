using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public AudioClip buttonPressClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeScene()
    {
        audioSource.PlayOneShot(buttonPressClip);
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu()
    {
		audioSource.PlayOneShot(buttonPressClip);
		SceneManager.LoadScene("MainMenuScene");
	}
}
