using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control the movement of the VR camera
// from other scripts, e.g. Waypoints
public class CameraController : MonoBehaviour {

	private Vector3 startPoint;
	private Vector3 endPoint;
	private float startTime;

	// The time it takes to travel to the next point
	public float journeyDuration = 0.5f;

	public static CameraController cameraController;

	void Start () {
		startPoint = endPoint = transform.position;
		cameraController = this;
	}

	void Update () {
		if (startPoint != endPoint) {	
			float fracJourney = (Time.time - startTime) / journeyDuration;
			transform.position = Vector3.Lerp (startPoint, endPoint, fracJourney);
		}
	}

	// move to a given point in a fixed amount of time.
	public void MoveTo (Vector3 dest) {
		startPoint = transform.position;
		endPoint = dest;
		startTime = Time.time;
	}
}