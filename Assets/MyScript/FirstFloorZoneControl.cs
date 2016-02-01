using UnityEngine;
using System.Collections;

public class FirstFloorZoneControl : MonoBehaviour {

	public int _CurrentZone;
	// Use this for initialization
	void Start () {
		_CurrentZone = 0;
	}
	
	public void ZoneUpdate(int _z){
		_CurrentZone = _z;
	}//ZoneUpdate
}
