using UnityEngine;
using System.Collections;

public class Fireplace1Active : MonoBehaviour {
	public GameObject _ActionMessage;
	public GameObject _PlayerHand;
	public bool _FireLit = false;
	public GameObject _Flame;
	public GameObject _Renai;
	public GameObject _BloodClue;
	public GameObject _Hint;
	public GameObject _EventLook;

	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			if(_col.GetComponent<OVRPlayerController>()._PlayerGotFire==true && _FireLit==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Light fire.";
				_ActionMessage.SetActive(true);
				SetFire(_col.gameObject);
			}
		}
	}//TriggerStay

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_ActionMessage.SetActive(false);
		}
	}//TriggerExit
	
	void SetFire(GameObject _player){
		if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B)){
			if(_PlayerHand==null){
				_PlayerHand = _player.transform.Find("inHand").gameObject;
			}
			_ActionMessage.SetActive(false);
			_PlayerHand.SetActive(false);
			_FireLit = true;
			_Flame.SetActive(true);
			_player.GetComponent<OVRPlayerController>()._PlayerGotFire=false;
			StartCoroutine(RenaiBlood());
		}
	}

	IEnumerator RenaiBlood(){
		yield return new WaitForSeconds (2f);
		_Renai.GetComponent<AudioSource> ().Play ();
		_Renai.GetComponent<NPCWalktoTarget>().enabled=true;
		if (_EventLook == null) {
			_EventLook=GameObject.Find("EventLook");
		}
		yield return new WaitForSeconds (2f);
		_EventLook.transform.position = _Renai.transform.position;
		FaceToEvent._turning = true;
		yield return new WaitForSeconds (1f);
		FaceToEvent._turning = false;
		_Hint.GetComponent<UnityEngine.UI.Text> ().text = "Hint : Searching for clue in bedroom.";
		_BloodClue.SetActive (true);

	}
}
