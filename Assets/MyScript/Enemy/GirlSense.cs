using UnityEngine;
using System.Collections;

public class GirlSense : MonoBehaviour {
	public float fieldOfViewAngle = 130f;
	public GameObject _player;
	public bool girlPlayerInSight;
	private Vector3 previousSighting;
	private SphereCollider _radientOfsenseG;
	private bool _Killed;
	private bool _PlayerTurn;
	public GameObject _Enemy;
	public GameObject _EnemyUI;
	public bool _EnemyBySide = false;
	private Vector3 PlayerBack;

	void Awake(){
		_Killed = false;
		_PlayerTurn = false;
		if (_Enemy == null) {
			_Enemy = GameObject.Find ("Enemy");
		}
		_radientOfsenseG = gameObject.GetComponent<SphereCollider> ();
		_player = GameObject.FindWithTag ("Player");
	}//Awake

	void OnTriggerStay (Collider other)
	{
		//enemy near girl
		if (other.tag == "Enemy") {
			_EnemyBySide=true;
		}

		// If the player has entered the trigger sphere...
		if (other.gameObject == _player) {

			//turn
			if (_PlayerTurn == true) {
				if (_EnemyBySide == true) {
					Debug.Log ("Turn to enemy");
					var lookPosP = _Enemy.transform.position - other.transform.position;
					lookPosP.y = 0;
					var rotationP = Quaternion.LookRotation (lookPosP);
					other.transform.rotation = Quaternion.Slerp (other.transform.rotation, rotationP, Time.deltaTime * 10f);
				} else {
					Debug.Log ("Turn to Back");
					
					var lookPosP = PlayerBack;
					lookPosP.y = 0;
					var rotationP = Quaternion.LookRotation (lookPosP);
					other.transform.rotation = Quaternion.Slerp (other.transform.rotation, rotationP, Time.deltaTime * 10f);
				}
			}

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

	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == _player)
			// ... the player is not in sight.
			girlPlayerInSight = false;
		gameObject.GetComponent<GirlWalkpath>()._playerInSight=girlPlayerInSight;
		Debug.Log ("I don't sense Player");
		//enemy near girl
		if (other.tag == "Enemy") {
			_EnemyBySide=false;
		}
	}//trigger

	IEnumerator GirlFoundPlayer(){
		gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (0.5f);
		_player.GetComponent<OVRPlayerController>().enabled=false;
		if (_EnemyBySide == true) {
			if (_Enemy.GetComponent<EnemySight> ().playerInSight == false) {
				_Enemy.GetComponent<EnemySight> ().GirlSentence = true;
				_Enemy.GetComponent<EnemySight> ().playerInSight =true;
				_Enemy.GetComponent<EnemyWalkpath>()._playerInSight=true;
			}
		} else {
			_Enemy.SetActive (false);

		}
		yield return new WaitForSeconds (2f);
		PlayerBack = -_player.transform.forward;
		_PlayerTurn=true;
		yield return new WaitForSeconds (0.5f);
		if (_EnemyBySide == false) {
			_EnemyUI.SetActive (true);
		}
		yield return new WaitForSeconds (1f);
		Menu._GameOver = true;



	}
}
