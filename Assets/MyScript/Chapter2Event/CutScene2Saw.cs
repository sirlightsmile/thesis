using UnityEngine;
using System.Collections;

public class CutScene2Saw : MonoBehaviour {
	public GameObject _Master;
	// Use this for initialization
	void HitByRay () {
		if (_Master.GetComponent<toCutScene2>()._isActive == false) {
			_Master.GetComponent<toCutScene2>()._isActive = true;
		}
		
	}
}
