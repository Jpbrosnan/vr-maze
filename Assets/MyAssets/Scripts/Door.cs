using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	private bool _opened = false;
	private Color _mainColor;
	private Renderer _renderer;
	// max distance allowed to interact with door
	private float _maxDistance = 20f;

	public GameObject player;
	public AudioSource lockedAudioSource;
	public AudioSource openedAudioSource;

	void Start() {
		_renderer = GetComponent<Renderer>();
		_mainColor = _renderer.material.color;
	}

    void Update() {
		if (_opened && transform.position.y < 22f)
			transform.Translate (0, 2.5f * Time.deltaTime, 0, Space.World);
    }

	public void OnDoorClicked()
	{
		float dist = Vector3.Distance (player.transform.position, transform.position);

		if (dist < _maxDistance)
			Unlock ();
	}

    public void Unlock()
    {
		if (Key.keyCollected) {
			openedAudioSource.Play ();
			_opened = true;
		} else {
			lockedAudioSource.Play ();
		}
    }

	// display different highlight color if the door is locked
	public void OnMouseEnter()
	{
		float dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist < _maxDistance) {
			_renderer.material.color = Key.keyCollected ? Color.green : Color.red;
		}
	}

	public void OnMouseExit()
	{
		_renderer.material.color = _mainColor;
	}
}
