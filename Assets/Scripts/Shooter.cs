using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 2000f;
	public float moveSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		transform.Translate (new Vector3 (h, v, 0f) * Time.deltaTime * moveSpeed);

		if (Input.GetButtonUp ("Fire1")) {
			Rigidbody shot = Instantiate (projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce (shotPos.forward * shotForce);
			Destroy(shot.gameObject,2f);
		}
	}
}
