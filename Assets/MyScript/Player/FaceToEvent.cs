using UnityEngine;
using System.Collections;

public class FaceToEvent : MonoBehaviour {
	public GameObject _Event;
	public float turn_speed;
	public static bool _turning;

	void Update(){
		if (_turning == true) {
			rotateTowards (_Event);
		}
		//transform.LookAt (_Event.transform);
	}

	void rotateTowards(GameObject _event) {
		Vector3 relativePos = _event.transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos.normalized);
		rotation.x = 0.0f;
		rotation.z = 0.0f;
		Quaternion current = transform.localRotation;
		transform.localRotation = Quaternion.Slerp(current,rotation,Time.deltaTime*10);
	}//rotateToward

}
