using UnityEngine;
using System.Collections;

public class AnimateToHidden : MonoBehaviour {
	
	public float _speed=2f;	
	public bool _movingIn=false;
	public bool _start=false;
	private Vector3 _OriginalPose;
	public GameObject _hiddenCamera;
	void Update(){
		if (_movingIn == true) {
			if(_start==true){
				_start=false;
				_OriginalPose=transform.localPosition;
				StartCoroutine(Stop ());
			}
			Vector3 direction = _hiddenCamera.transform.position - transform.position;
			transform.Translate (direction.normalized *_speed* Time.deltaTime,Space.World);

		}
	}
	IEnumerator Stop(){
		yield return new WaitForSeconds(0.5f);
		_movingIn = false;
	}
	public void ReToOriginalPose(){
		transform.localPosition = _OriginalPose;
	}
}//class
