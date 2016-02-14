using UnityEngine;
using System.Collections;

public class ToFirstFloor : MonoBehaviour {

	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			PlayerPrefs.SetString("NextFromLoad","FirstFloor");
			Application.LoadLevel("LoadScene");
		}
	}//TriggerEnter

}
