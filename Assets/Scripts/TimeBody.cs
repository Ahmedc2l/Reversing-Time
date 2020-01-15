using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	bool isRewinding = false;

	public float recordTime = 5f;

	List<PointInTime> pointsInTime;

	Rigidbody rb;

	void Start () {
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
	}

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			transform.position = pointsInTime[0].position;
			transform.rotation = pointsInTime[0].rotation;
			pointsInTime.RemoveAt(0);
		} 
		else
		{
			StopRewind();
		}

	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			// Remove from the bottom
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		// Add to the Top
		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind ()
	{
		isRewinding = true;
		//Stop unity from applying physics
		rb.isKinematic = true;
	}

	public void StopRewind ()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}
}