using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	static public bool keyCollected = false;

	public GameObject keyPoofPrefab;

	void Update() {
		transform.Rotate (Vector3.forward * Time.deltaTime * 100f);
	}

	public void OnKeyClicked()
	{
		GameObject poof = Instantiate(keyPoofPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
		Key.keyCollected = true;
		poof.GetComponent<AudioSource>().Play();
		Destroy(gameObject);
    }

}
