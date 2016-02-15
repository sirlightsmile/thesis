using UnityEngine;
using System.Collections;

public class GirlWalkpath : MonoBehaviour {
	private NavMeshAgent _girlNav;
	private Animator _GirlAnimate;
	public GameObject _point;
	public bool _SearchingState;
	//SearchingIdle is for not to run searching state many time
	private bool _SearchingIdle;
	public bool _playerInSight;
	//for animation of walk
	private bool _isWalking;	
	private GameObject _Player;	
	// Use this for initialization
	void Start () {
		//when start. is on searching state or not
		//_SearchingState = false;
		_SearchingIdle = true;

		_point = GameObject.Find ("GirlPoint");
		_Player = GameObject.FindWithTag ("Player");
		_girlNav = GetComponent<NavMeshAgent> ();
		_GirlAnimate = GetComponent<Animator> ();
		_playerInSight = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		_playerInSight = gameObject.GetComponent<GirlSense> ().girlPlayerInSight;
		if (_playerInSight==true) {
			if(_SearchingState==true){
				GirlFoundPlayer();
			}
			_isWalking=false;
			_girlNav.Stop();
			if(_Player==null){
				_Player = GameObject.FindWithTag ("Player");
			}
			_GirlAnimate.SetBool ("Walk", false);
			_GirlAnimate.SetBool ("Search", false);
			
		}else{
			//player not in sight
			if (_SearchingState == false) {
				if(_point!=null){
					_isWalking=true;
					_girlNav.SetDestination (_point.transform.position);
				}else{
					Debug.Log("No Destination");
				}
			} else {
				if (_SearchingIdle == true) {
					_SearchingIdle = false;
					_isWalking=false;
					StartCoroutine (GirlSearchingIdle ());
					print ("Girl Searching");
				}
			}
		}
		
		//Animate for walk
		if (_isWalking == true && _playerInSight == false) {
			_GirlAnimate.SetBool ("Walk", true);
		} else {
			_GirlAnimate.SetBool ("Walk", false);
		}
	}//update
	
	IEnumerator GirlSearchingIdle(){
		_GirlAnimate.SetBool ("Walk", false);
		yield return new WaitForSeconds(2f);
		_GirlAnimate.SetBool ("Search", true);
		gameObject.GetComponent<GirlSense> ().fieldOfViewAngle = 150f;
		yield return new WaitForSeconds(5f);
		_GirlAnimate.SetBool ("Search", false);
		gameObject.GetComponent<GirlSense> ().fieldOfViewAngle = 130f;
		yield return new WaitForSeconds(3f);
		_SearchingState = false;
		_SearchingIdle = true;
		_isWalking=true;		
		
	}//IEnumerator

	//when enemy found player while searching state
	public void GirlFoundPlayer(){
		StopCoroutine(GirlSearchingIdle());
		_SearchingState = false;
		_SearchingIdle = true;
	}//enemyFoundPlayer

}
