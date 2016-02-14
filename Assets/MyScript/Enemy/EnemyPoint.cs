using UnityEngine;
using System.Collections;

public class EnemyPoint : MonoBehaviour {

	public GameObject _RouteMaster;
	public GameObject[] _route;
	//target route and current route
	private int _routeNum=0;
	private int _currentRoute=0;
	//moving like patthen or Random
	public bool _RandomRoute;
	//is moving to _route num forward or backward
	private bool _forward;
	public GameObject _Enemy;
	//if col with point enemy will do searching state or not
	public bool _ColSearchingState = true;
	// Use this for initialization
	void Awake () {
		_forward = true;
		//Assign all route to point
		_routeNum = _RouteMaster.transform.childCount;
		_route = new GameObject[_routeNum];
		for (int i=0; i < _routeNum; i++) {
			_route[i]=_RouteMaster.transform.GetChild(i).gameObject;
		}
		_routeNum = 0;
		gameObject.transform.position=_route[0].gameObject.transform.position;
	}

	void OnTriggerEnter(Collider _col){
		if (_col.gameObject.tag == "Enemy" && _Enemy.GetComponent<EnemySight>().playerInSight==false
		    && _Enemy.GetComponent<EnemyWalkpath>()._ALERT==false) {
			if(_ColSearchingState==true){
				_Enemy.GetComponent<EnemyWalkpath>()._SearchingState=true;
			}

			EnemyRouteChange();

		}

		//run toward because hearing player not enemy normal route
		if (_col.gameObject.tag == "Enemy" && _Enemy.GetComponent<EnemySight> ().playerInSight == false
		    && _Enemy.GetComponent<EnemyWalkpath> ()._ALERT == true) {

			_Enemy.GetComponent<EnemyWalkpath>()._SearchingState=true;
			gameObject.transform.position=_route[_routeNum].gameObject.transform.position;
		}
	}//TriggerEnter

	void EnemyRouteChange(){
		if (_RandomRoute == false) {
			if (_routeNum + 1 == _route.Length) {
				_forward = false;
			} else if (_routeNum == 0) {
				_forward = true;
			}
		
			if (_forward == true) {
				_routeNum += 1;
			} else {
				_routeNum -= 1;
			}
		
			gameObject.transform.position = _route [_routeNum].gameObject.transform.position;
		} else {
			while (_routeNum==_currentRoute) {
				_routeNum = Random.Range (0, _route.Length);
			}			
			gameObject.transform.position=_route[_routeNum].gameObject.transform.position;

		}
	}//EnemyRouteChange


}
