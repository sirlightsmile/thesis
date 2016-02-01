using UnityEngine;
using System.Collections;

public class GirlStand : MonoBehaviour {
	private bool _eventActive = false;
	public GameObject _doorLock;
	public GameObject _girl;
	public GameObject _eventLook;
	void HitByRay(){
		if (_eventActive == false) {
			_eventActive=true;
			_eventLook=GameObject.Find ("EventLook");
			_eventLook.transform.position = new Vector3 (32.76f,2.02f,-4.29f);
			_girl.GetComponent<LookAtPlayer>().enabled=true;
			_doorLock.GetComponent<Door>()._Locked=true;
			StartCoroutine (Event2CP1girlrun ());
		}
	}
	
	IEnumerator Event2CP1girlrun (){
		FaceToEvent._turning = true;
		gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (2f);
		FaceToEvent._turning = false;
		Destroy (this.gameObject,2);
	}

}
