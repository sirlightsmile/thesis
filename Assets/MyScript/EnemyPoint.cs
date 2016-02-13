using UnityEngine;
using System.Collections;

public class EnemyPoint : MonoBehaviour {
	public GameObject[] _route=new GameObject[2];
	//current route
	private int _routeNum=0;
	private int _routeMax=0;
	//is moving to _route num forward or backward
	private bool _forward;
	public GameObject _Enemy;
	//if col with point enemy will do searching state or not
	public bool _ColSearchingState = true;
	// Use this for initialization
	void Awake () {
		_forward = true;
		//count route
		foreach (GameObject _n in _route) {
			_routeMax+=1;
		}
		gameObject.transform.position=_route[0].gameObject.transform.position;
	}

	void OnTriggerEnter(Collider _col){
		if (_col.gameObject.tag == "Enemy" && _Enemy.GetComponent<EnemySight>().playerInSight==false
		    && _Enemy.GetComponent<EnemyWalkpath>()._ALERT==false) {
			if(_ColSearchingState==true){
				_Enemy.GetComponent<EnemyWalkpath>()._SearchingState=true;
			}
			if(_routeNum+1 == _routeMax){
				_forward=false;
			}else if (_routeNum==0){
				_forward=true;
			}

			if(_forward==true){
				_routeNum+=1;
			}else{
				_routeNum-=1;
			}
			gameObject.transform.position=_route[_routeNum].gameObject.transform.position;

		}

		//run toward because hearing player not enemy normal route
		if (_col.gameObject.tag == "Enemy" && _Enemy.GetComponent<EnemySight> ().playerInSight == false
		    && _Enemy.GetComponent<EnemyWalkpath> ()._ALERT == true) {

			_Enemy.GetComponent<EnemyWalkpath>()._SearchingState=true;
			gameObject.transform.position=_route[_routeNum].gameObject.transform.position;
		}
	}//TriggerEnter


}
