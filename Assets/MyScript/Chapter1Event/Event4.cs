using UnityEngine;
using System.Collections;

public class Event4 : MonoBehaviour {
	public GameObject _Chest;
	public GameObject _Renai;
	//public GameObject _Player;
	public float _Speed=5;
	public bool _event4Start=false;

	void Start(){
		//start Chapter 1-2
		//_Player.SetActive (false);
		_Chest.GetComponent<HiddenCameraActive> ()._hiding = true;
	}

	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			_Renai.SetActive(true);
			_Renai.GetComponent<Animator>().SetBool("Walk",true);
			StartCoroutine(StartEvent4());
		}
	}//trigger
	IEnumerator StartEvent4(){
		yield return new WaitForSeconds (3f);
		_event4Start = true;
		yield return new WaitForSeconds (0.5f);
		PlayerPrefs.SetString ("NextFromLoad", "RenaiMemories1");
		Application.LoadLevel ("RenaiMemories1");
	}
	void Update(){
		if (_event4Start == true) {
			_Renai.transform.Translate (Vector3.forward * Time.deltaTime * _Speed);
		}
	}
}
