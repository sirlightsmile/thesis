using UnityEngine;
using System.Collections;

public class C3Event0 : MonoBehaviour {
	public GameObject _enemy;
	void OnEnable () {
		StartCoroutine (Event0C3 ());
	}

	IEnumerator Event0C3(){
		yield return new WaitForSeconds (5f);
		_enemy.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<AudioSource> ().Play ();
		FaceToEvent._turning = true;
		yield return new WaitForSeconds (1f);
		FaceToEvent._turning = false;
	}
}
