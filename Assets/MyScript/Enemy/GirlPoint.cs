using UnityEngine;
using System.Collections;

public class GirlPoint : MonoBehaviour {

	public GameObject _RouteMaster;
	public GameObject[] _route;
	//current route
	private int _routeNum=0;
	private int _currentRoute=0;
	//is moving to _route num forward or backward
	private bool _forward;
	public GameObject _Girl;
	//if col with point enemy will do searching state or not
	public bool _ColSearchingState = true;
	// Use this for initialization
	void Awake () {
		_Girl = GameObject.Find ("TwinRacheal");
		//Assign all route to point
		_routeNum = _RouteMaster.transform.childCount;
		_route = new GameObject[_routeNum];
		for (int i=0; i < _routeNum; i++) {
			_route[i]=_RouteMaster.transform.GetChild(i).gameObject;
		}
		_routeNum = 0;

		gameObject.transform.position = _route [0].gameObject.transform.position;
	}
	
	void OnTriggerEnter(Collider _col){
		if(_col.tag=="Girl"){
			if(_ColSearchingState==true && _col.gameObject.GetComponentInParent<GirlSense>().girlPlayerInSight==false){
				_Girl.GetComponentInParent<GirlWalkpath>()._SearchingState=true;
			}
			_currentRoute = _routeNum;
			//random route for girl
			while (_routeNum==_currentRoute) {
			_routeNum = Random.Range (0, _route.Length);
			}
			gameObject.transform.position=_route[_routeNum].gameObject.transform.position;
		}
	}//TriggerEnter

}
