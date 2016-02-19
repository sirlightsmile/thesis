using UnityEngine;
using System.Collections;

public class EventC2p3 : MonoBehaviour {
	public GameObject _Renai;
	public GameObject _AIracheal;
	public GameObject _EventLook;
	private bool _PlayerActiveEvent=false;
	public GameObject _TargetDoor;
	public GameObject _GirlDoor;
	private bool _PlayerActiveDoor=false;
	public GameObject _Hint;
	public GameObject _Checkpoint;

	void FixedUpdate(){
		if (_TargetDoor.GetComponent<AudioSource> ().isPlaying == true 
		    &&_PlayerActiveDoor==false && _PlayerActiveEvent==true) {
			_PlayerActiveDoor=true;
			StartCoroutine(C2p3ActivePart2());
		}
	}

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player" && _PlayerActiveEvent==false) {
			_PlayerActiveEvent=true;
			StartCoroutine(C2p3Active());
		}
	}//TriggerExit

	IEnumerator C2p3Active(){
		_EventLook.transform.position = _Renai.transform.position;
		_Renai.SetActive (true);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = false;
	}

	IEnumerator C2p3ActivePart2(){
		_Hint.GetComponent<UnityEngine.UI.Text>().text="Hint : Find Key and follow white women.";
		yield return new WaitForSeconds(3f);
		_AIracheal.SetActive (true);
		_EventLook.transform.position = _AIracheal.transform.position;
		FaceToEvent._turning = true;
		gameObject.GetComponent<AudioSource> ().Play ();
		_GirlDoor.GetComponent<Door>()._Locked = false;
		yield return new WaitForSeconds(0.5f);
		_AIracheal.GetComponent<AudioSource> ().Play ();
		FaceToEvent._turning = false;
		yield return new WaitForSeconds(7.5f);
		_Checkpoint.GetComponent<CheckPoint>()._SaveScene="Chapter2-2";
		_Checkpoint.SetActive(true);
		Destroy (this.gameObject);

	}
}
