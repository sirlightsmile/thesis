using UnityEngine;
using System.Collections;

public class EnemyWalkpath : MonoBehaviour {
	private NavMeshAgent _enemyNav;
	private Animator _EnemyAnimate;
	public GameObject _point;
	public float _SearchingSpeed = 12f;
	public bool _SearchingState;
	//SearchingIdle is for not to run searching state many time
	private bool _SearchingIdle;
	public bool _playerInSight;
	private bool _turnLeft;
	private bool _turnRight;
	private bool _isWalking;

	private GameObject _Player;

	public bool _ALERT;
	// Use this for initialization
	void Start () {
		//when start. is on searching state or not
		//_SearchingState = false;
		_SearchingIdle = true;
		//
		_Player = GameObject.FindWithTag ("Player");
		_enemyNav = GetComponent<NavMeshAgent> ();
		_EnemyAnimate = GetComponent<Animator> ();
		_turnLeft = false;
		_turnRight = false;
	//	_playerInSight = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (_playerInSight==true) {
			if(_SearchingState==true){
				enemyFoundPlayer();
			}
			gameObject.GetComponent<Animator>().SetBool ("seePlayer", true);
			_isWalking=true;
			_enemyNav.speed=3;
			if(_Player==null){
				_Player = GameObject.FindWithTag ("Player");
			}
			_enemyNav.SetDestination (_Player.transform.position);

		}else{
		//player not in sight
			gameObject.GetComponent<Animator>().SetBool("seePlayer",false);
				if(_ALERT!=true){
					_enemyNav.speed=1;
				}else{
					_enemyNav.speed=2;
				}
			if (_SearchingState == false) {
				if(_point!=null){
					_isWalking=true;
					_enemyNav.SetDestination (_point.transform.position);
				}else{
					//No Destination
				}
			} else {
				if (_SearchingIdle == true) {
					_SearchingIdle = false;
					_isWalking=false;
					StartCoroutine (SearchingIdle ());
					print (_SearchingState);
				}
			}
			//turning while searching state
			if (_SearchingState == true && _turnLeft == true) {
				transform.Rotate (-Vector3.up * Time.deltaTime * _SearchingSpeed);
			} else if (_SearchingState == true && _turnRight == true) {
				transform.Rotate (Vector3.up * Time.deltaTime * _SearchingSpeed);
			}
		}

		//just lost player in sight > searching state
		/*
		if (_playerLostSight == true) {
			_playerLostSight=false;
			_playerInSight=false;
			_SearchingState=true;
		}*/

		//Animate for walk
		if (_isWalking == true && _playerInSight == false) {
			_EnemyAnimate.SetBool ("Walk", true);
		} else {
			_EnemyAnimate.SetBool ("Walk", false);
		}
	}//update

	IEnumerator SearchingIdle(){
		yield return new WaitForSeconds(2f);
		Debug.Log("turn right");
		_turnRight = true;
		yield return new WaitForSeconds(2f);
		_turnRight = false;
		_turnLeft = true;
		Debug.Log("turn left");
		yield return new WaitForSeconds(4f);
		_turnLeft = false;
		_turnRight = true;
		yield return new WaitForSeconds(2f);
		_turnRight = false;

		if (_ALERT == true) {
			//change sound
			EnemyClamDown();
		yield return new WaitForSeconds(3f);

		}
		_SearchingState = false;
		_SearchingIdle = true;
		_isWalking=true;


	}//IEnumerator

	//when enemy found player while searching state
	public void enemyFoundPlayer(){
		StopCoroutine(SearchingIdle());
		_SearchingState = false;
		_SearchingIdle = true;
	}//enemyFoundPlayer

	public void AlertState(){
		_ALERT = true;
		gameObject.GetComponent<AudioSource> ().Play ();
	}//AlertState

	void EnemyClamDown(){
		_ALERT = false;
	}//clamdown
}
