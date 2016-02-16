using UnityEngine;
using System.Collections;

public class CutScene2Active : MonoBehaviour {
	private bool _isActive=false;
	// Use this for initialization
	void HitByRay () {
		if (_isActive == false) {
			_isActive=true;
			ActiveCutScene2();
		}
		
	}
	
	IEnumerator ActiveCutScene2(){
		yield return new WaitForSeconds (3f);

	}
}
