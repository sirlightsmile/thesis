﻿using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fieldOfViewAngle = 130f;
	//normal 110
	public bool playerInSight;
	public bool GirlSentence;
	private SphereCollider _radientOfsense;
	public GameObject player;
	private Vector3 previousSighting;
	private Animator _animator;

	void Awake(){
		_radientOfsense = gameObject.GetComponent<SphereCollider> ();
		player = GameObject.FindWithTag ("Player");
		_animator = gameObject.GetComponent<Animator> ();
		GirlSentence = false;
		//personaLastSighting =
	}//Awake

	void Update(){
		if (player.activeInHierarchy == false) {
			//player hidden in time
			playerInSight=false;
		}
	}//update

	void OnTriggerStay (Collider other)
	{

		// If the player has entered the trigger sphere...
		if (other.gameObject == player && GirlSentence == false) {
			// By default the player is not in sight.
			Debug.Log("Player in");
			playerInSight = false;
			
			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			// If the angle between forward and where the player is, is less than half the angle of view...
			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;
				
				// ... and if a raycast towards the player hits something...
				//if (Physics.Raycast (transform.position + transform.up , direction.normalized, out hit, col.radius)) {
				Vector3 StartDirection = transform.position + transform.up;
				StartDirection = StartDirection + (transform.up/2);
				if (Physics.Raycast (StartDirection, direction.normalized, out hit, _radientOfsense.radius)) {
					// ... and if the raycast hits the player...
					//Debug.DrawRay (transform.position + transform.up ,direction*5,Color.green);
					Debug.DrawRay (StartDirection ,direction.normalized*5,Color.green);
					Debug.DrawLine(StartDirection ,hit.point,Color.red);

					if (hit.collider.gameObject.tag == "Player") {
						// ... the player is in sight.
							playerInSight = true;
							gameObject.GetComponent<EnemyWalkpath>()._playerInSight=playerInSight;
							Debug.Log ("I saw Player");
							if(gameObject.GetComponent<AudioSource>().isPlaying!=true){
							gameObject.GetComponent<AudioSource>().Play();
							}
							//transform.LookAt(player.transform);
					}
				}
			}
		}
	}//OnTriggerStay
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == player && GirlSentence == false)
			// ... the player is not in sight.
			playerInSight = false;
			gameObject.GetComponent<EnemyWalkpath>()._playerInSight=playerInSight;
			Debug.Log ("I don't see Player");
	}//trigger

}
