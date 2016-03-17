using UnityEngine;
using System.Collections;

public class SecondCameraPos : MonoBehaviour {
	public GameObject _PlayerCamera;
	public GameObject _Player;
	public bool _move=true;
	public float _speed = 5f;
	// Use this for initialization
	void OnEnable () {
		gameObject.transform.position = _PlayerCamera.transform.position;
		gameObject.transform.rotation = _PlayerCamera.transform.rotation;
		_Player.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (_move == true) {
			transform.Translate (Vector3.forward * Time.deltaTime * _speed);
		}
	}

	void OnTriggerEnter(Collider _col){
		if (_col.name == "Event1") {
			_move=false;
			_col.GetComponent<C3Event1>().GotHit();
		}
	}
}
