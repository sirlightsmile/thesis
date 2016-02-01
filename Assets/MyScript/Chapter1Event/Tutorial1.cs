using UnityEngine;
using System.Collections;

public class Tutorial1 : MonoBehaviour {
	public GameObject _tutorial1;
	public GameObject _tutorial15;

	void Start(){
		StartCoroutine (ActiveTutorial1 ());
	}

	IEnumerator ActiveTutorial1(){
		yield return new WaitForSeconds (2f);
		_tutorial1.SetActive (true);
	}

	void OnTriggerEnter(Collider _col){
		if(_col.tag=="Player"){
			_tutorial1.SetActive (false);
			_tutorial15.SetActive(true);
			Destroy(this.gameObject);
		}
	}//trigger
}
