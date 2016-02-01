using UnityEngine;
using System.Collections;

public class Event4complete : MonoBehaviour {
	public GameObject _particle;
	public bool _start=false;
	public GameObject _clearText;

	void HitByRay(){
		if (_start == false) {
			_start=true;
			_clearText.SetActive(true);
			_particle = (GameObject)Resources.Load ("Particle/DustPoof/Disappear");
			StartCoroutine (Disappear ());
		}
	}

	IEnumerator Disappear(){
		yield return new WaitForSeconds (3f);
		Instantiate (_particle, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(this.gameObject);
	}
}
