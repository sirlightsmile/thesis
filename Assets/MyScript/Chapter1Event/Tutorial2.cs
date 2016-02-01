using UnityEngine;
using System.Collections;

public class Tutorial2 : MonoBehaviour {
	public GameObject _tutorial2;
	public GameObject _tutorial15;

	void OnTriggerEnter(Collider _col){
		if(_col.tag=="Player"){
			_tutorial15.SetActive(false);
			_tutorial2.SetActive (true);
		}
	}//trigger

	public void CompleteTutorial2(){
			_tutorial2.SetActive (false);
			Destroy(this.gameObject);
	}
}
