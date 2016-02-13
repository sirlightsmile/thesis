using UnityEngine;
using System.Collections;

public class GirlSense : MonoBehaviour {
	public float fieldOfViewAngle = 130f;
	public GameObject _player;
	public bool girlPlayerInSight;
	private Vector3 previousSighting;
	private Animator _animator;
	private SphereCollider _radientOfsenseG;
	private bool _Killed;
	private bool _PlayerTurn;
	private GameObject _Enemy;

	void Awake(){
		_Killed = false;
		_PlayerTurn = false;
		_Enemy = GameObject.Find ("Enemy");
		_radientOfsenseG = gameObject.GetComponent<SphereCollider> ();
		_player = GameObject.FindWithTag ("Player");
		_animator = gameObject.GetComponent<Animator> ();
	}//Awake

	void OnTriggerStay (Collider other)
	{
		if(_PlayerTurn==true){
			Debug.Log("Turn to enemy");
			var lookPosP = _Enemy.transform.position - other.transform.position;
			lookPosP.y = 0;
			var rotationP = Quaternion.LookRotation(lookPosP);
			other.transform.rotation = Quaternion.Slerp(other.transform.rotation, rotationP, Time.deltaTime * 10f);
		}
		// If the player has entered the trigger sphere...
		if (other.gameObject == _player) {
			Debug.Log ("I SENSE Player");

			girlPlayerInSight = false;
			
			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = _player.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			// If the angle between forward and where the player is, is less than half the angle of view...
			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;
				
				// ... and if a raycast towards the player hits something...
				//if (Physics.Raycast (transform.position + transform.up , direction.normalized, out hit, col.radius)) {
				Vector3 StartDirection = transform.position+ transform.up;
				StartDirection = StartDirection + (transform.up/2);

				if (Physics.Raycast (StartDirection, direction.normalized, out hit, _radientOfsenseG.radius)) {
					// ... and if the raycast hits the player...
					//Debug.DrawRay (transform.position + transform.up ,direction*5,Color.green);
					Debug.DrawRay (StartDirection ,direction.normalized*5,Color.green);
					if (hit.collider.gameObject.tag == "Player") {
						// ... the player is in sight.
						girlPlayerInSight = true;
						Debug.Log ("I FOUND Player");

						var lookPos = other.transform.position - transform.position;
						lookPos.y = 0;
						var rotation = Quaternion.LookRotation(lookPos);
						transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);

						if(_Killed==false){
							_Killed = true;

							StartCoroutine(GirlFoundPlayer());
						}

					
						//transform.LookAt(player.transform);
					}
				}
			}
		}
	}//OnTriggerStay
	
	IEnumerator GirlFoundPlayer(){
		yield return new WaitForSeconds (1f);
		_player.GetComponent<OVRPlayerController>().enabled=false;
		yield return new WaitForSeconds (2f);
		_Enemy.GetComponent<NavMeshAgent>().Warp(_player.transform.position + (transform.forward*3f));
		_PlayerTurn=true;
		_Enemy.transform.LookAt (_player.transform);




	}
}
