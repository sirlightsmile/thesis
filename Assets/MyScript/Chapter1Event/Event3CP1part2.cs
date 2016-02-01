using UnityEngine;
using System.Collections;

public class Event3CP1part2 : MonoBehaviour {
	public GameObject _clueActive;
	public GameObject _eventLook;
	public GameObject _boxSlamming;
	public GameObject _Closet;
	

	void HitByRay(){
		if (_eventLook == null) {
			_eventLook = GameObject.Find ("EventLook");
			_Closet.GetComponent<thenCutScene1>().enabled=true;
			gameObject.GetComponent<AudioSource>().Play();
			_eventLook.transform.position = new Vector3 (29.57f, 2.02f, -13.24f);
			StartCoroutine (Event3 ());
		}
	}

	IEnumerator Event3(){
		yield return new WaitForSeconds (1f);
		//sound
		_boxSlamming.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1f);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds (1f);
		_clueActive.SetActive (true);
		yield return new WaitForSeconds (3f);
		FaceToEvent._turning = false;
		//_eventLook.transform.position = new Vector3 (34.7f,0.9449999f,-12.06f);
		//yield return new WaitForSeconds (1f);
		//FaceToEvent._turning = false;
	}
}
