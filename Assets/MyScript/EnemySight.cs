using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fieldOfViewAngle = 130f;
	//normal 110
	public bool playerInSight;
	//public Vector3 personalLastSighting;

	//hear
	//private NavMeshAgent nav;
	
	private SphereCollider _radientOfsense;
	public GameObject player;
	private Vector3 previousSighting;
	private Animator _animator;
	public GameObject _EnemyPoint;

	void Awake(){
		_radientOfsense = gameObject.GetComponent<SphereCollider> ();
		player = GameObject.FindWithTag ("Player");
		_animator = gameObject.GetComponent<Animator> ();
		//personaLastSighting =
	}//Awake

	void Update(){
		if (playerInSight == true) {
			_animator.SetBool ("seePlayer", true);
			GetComponent<EnemyWalkpath>()._playerInSight=playerInSight;
		} else {
			_animator.SetBool("seePlayer",false);
			GetComponent<EnemyWalkpath>()._playerInSight=playerInSight;

			//While Enemy just saw player and lost Enemy will be in alert state
			//that is _Player Lost Sight State Until he cool down he walk faster.
			//GetComponent<EnemyWalkpath>()._playerLostSight=true;
		}

		if (player.activeInHierarchy == false) {
			//player hidden in time
			playerInSight=false;
		}
	}//update

	void OnTriggerStay (Collider other)
	{

		// If the player has entered the trigger sphere...
		if (other.gameObject == player) {
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
					if (hit.collider.gameObject.tag == "Player") {
						// ... the player is in sight.
							playerInSight = true;
							Debug.Log ("I saw Player");
							//transform.LookAt(player.transform);
					}else{
						//playerInSight = false;
					}
				}
			}


			//Hearing
			if(other.GetComponent<OVRPlayerController>()._FastWalk==true && playerInSight==false){
				//ALERTTTT
				if(gameObject.GetComponent<EnemyWalkpath>()._SearchingState==true){
					gameObject.GetComponent<EnemyWalkpath>().enemyFoundPlayer();
				}
				if(_EnemyPoint==null){
				_EnemyPoint = GameObject.Find ("EnemyPoint");
				}
				_EnemyPoint.transform.position=new Vector3(other.transform.position.x,1.2f,other.transform.position.z);

				if(gameObject.GetComponent<EnemyWalkpath>()._ALERT!=true){
					gameObject.GetComponent<EnemyWalkpath>().AlertState();
				}

			}
		}
	}//OnTriggerStay
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == player)
			// ... the player is not in sight.
			playerInSight = false;
			Debug.Log ("I don't see Player");
	}//trigger

}
