using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	public GameObject coinPoofPrefab;

	void Update() {
		transform.Rotate (Vector3.right * Time.deltaTime * 100f);
	}

    public void OnCoinClicked() {
		GameObject poof = Instantiate (coinPoofPrefab, transform.position, Quaternion.Euler(-90,0,0));
		poof.GetComponent<AudioSource>().Play();
		Destroy(gameObject);
    }
}
