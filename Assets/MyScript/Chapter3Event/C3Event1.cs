using UnityEngine;
using System.Collections;

public class C3Event1 : MonoBehaviour {
	public GameObject _fireplace;
	public GameObject _wall;
	public GameObject _smoke;
	public GameObject _candleFire;
	public GameObject _player;
	public GameObject _secondCamera;
	public Transform _CameraPos;
	public GameObject _CheckPoint;
	private bool _isActive = false;
	public GameObject _enemyAI;
	public GameObject _girlAI;

	public void GotHit(){
		if (_isActive == false) {
			_isActive=true;
			StartCoroutine(Chap3Event1());
		}
	}

	IEnumerator Chap3Event1(){
		yield return new WaitForSeconds (1f);
		_fireplace.SetActive (true);
		_wall.SetActive (false);
		_smoke.SetActive (true);
		yield return new WaitForSeconds (3f);
		_secondCamera.transform.position = _CameraPos.position;
		_secondCamera.transform.rotation = _CameraPos.rotation;
		yield return new WaitForSeconds (1f);
		_candleFire.SetActive (true);
		yield return new WaitForSeconds (3f);
		_player.SetActive (true);
		_enemyAI.SetActive(true);
		_girlAI.GetComponent<GirlWalkpath> ().enabled = true;
		_girlAI.GetComponent<AudioSource> ().Play ();
		_secondCamera.SetActive (false);
		_CheckPoint.SetActive (true);
	}
}
