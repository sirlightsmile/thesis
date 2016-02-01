using UnityEngine;
using System.Collections;

public class ZoneHit : MonoBehaviour {
	public GameObject[] Zone1 = new GameObject[2];
	public GameObject Zone2;
	public GameObject Zone4;
	public GameObject ZoneText;
	public GameObject _GamePlayController;
	void OnTriggerEnter(Collider _col) {
		if (_col.name == "Zone1") {
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone1";
			foreach (GameObject _n in Zone1){
				_n.SetActive(true);
			}
			Zone2.SetActive(false);
		} else if (_col.name == "Zone2toilet") {
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone2";
			foreach (GameObject _n in Zone1){
				_n.SetActive(false);
			}
			if(_GamePlayController==null){
				_GamePlayController=GameObject.Find("GamePlayController");
			}
			_GamePlayController.GetComponent<AudioSource>().volume=0.3f;
			Zone2.SetActive(true);
		} else if (_col.name == "Zone3") {
			foreach (GameObject _n in Zone1){
				_n.SetActive(false);
			}
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone3";
			Zone2.SetActive(false);
		} else if (_col.name == "Zone4") {
			Zone4.SetActive(true);
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone4";
		} else if (_col.name == "Zone5") {
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone5";
			Zone2.SetActive(false);
		}else if (_col.name == "Zone6") {
			Zone4.SetActive(false);
			ZoneText.GetComponent<UnityEngine.UI.Text>().text="Zone6";
		}
	}//CollisionEnter for ZONE

	void OnTriggerExit(Collider _col){
		if (_col.name == "Zone2toilet") {
			_GamePlayController.GetComponent<AudioSource> ().volume = 1.0f;
		}
	}
}
