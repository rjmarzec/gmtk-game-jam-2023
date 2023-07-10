using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowsOnLeftClick : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip throwAudioClip;

    public Transform tomatoParent;
    public GameObject tomatoPrefab;

    private Vector3 dragStartPoint;
    private Vector3 dragEndPoint;

    private SpriteRenderer sr;
    public SpriteRenderer rightHandSR;
    public SpriteRenderer slingshot;
    public Sprite slingshotEmpty;
    public Sprite slingshotLoaded;

    public int tomatoesRemaining;
    private bool mouseDown;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        UpdateSprites(false);
        tomatoesRemaining = Stats.tomatoCount;

        mouseDown = false;
    }

    void Update()
    {
        if(tomatoesRemaining > 0 && Stats.gameState == Stats.GameState.Game)
        {
			if (Input.GetMouseButtonDown(0))
			{
				UpdateSprites(true);
				dragStartPoint = GetMouseToWorldPoint();
                mouseDown = true;
			}
			else if (Input.GetMouseButtonUp(0) && mouseDown)
			{
				UpdateSprites(false);

                tomatoesRemaining -= 1;

				GameObject newTomato = Instantiate(tomatoPrefab, tomatoParent);
				Vector3 dragDifference = (dragEndPoint - dragStartPoint).normalized;
				newTomato.transform.position = transform.position;
                newTomato.transform.localScale *= Stats.tomatoSizeScalar;
				newTomato.GetComponent<Rigidbody>().velocity = dragDifference * GetVelocityScalar() * Stats.tomatoSpeed;

                audioSource.PlayOneShot(throwAudioClip);
			}
			else if (Input.GetMouseButton(0) && mouseDown)
			{
				dragEndPoint = GetMouseToWorldPoint();
				transform.localScale = new Vector3(0.5f, GetVelocityScalar(), 1);
				transform.rotation = Quaternion.Euler(DragToDirectionVector());
			}
		}
	}

    private Vector3 GetMouseToWorldPoint()
    {
        Vector3 VScreen = Input.mousePosition;
		VScreen.z = Camera.main.transform.position.z;

		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(VScreen);
        return new Vector3(worldPoint.x, 0, worldPoint.z);
	}

    private float GetVelocityScalar()
    {
		Vector3 dragDifference = dragEndPoint - dragStartPoint;
        return Mathf.Lerp(0.3f, 1.0f, dragDifference.magnitude / 20);
	}

    private Vector3 DragToDirectionVector()
    {
		Vector3 dragDifference = (dragEndPoint - dragStartPoint).normalized;
		return new Vector3(-90, 0, Vector3.Angle(dragDifference, Vector3.left) + 90.0f);
    }

    private void UpdateSprites(bool dragging)
    {
        sr.enabled = dragging;
        rightHandSR.enabled = dragging;
        slingshot.sprite = dragging ? slingshotLoaded : slingshotEmpty;
    }
}
