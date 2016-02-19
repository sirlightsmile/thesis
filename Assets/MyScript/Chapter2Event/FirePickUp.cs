using UnityEngine;
using System.Collections;

public class FirePickUp : MonoBehaviour {
	public GameObject _ActionMessage;
	public GameObject _PlayerHand;
	// Use this for initialization
	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			if(_col.GetComponent<OVRPlayerController>()._PlayerGotFire==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Pick up";
				_ActionMessage.SetActive(true);
				GetFire(_col.gameObject);
			}
		}
	}//TriggerStay

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
				_ActionMessage.SetActive(false);
		}
	}//TriggerExit

	void GetFire(GameObject _player){
		if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B)){
			if(_PlayerHand==null){
				_PlayerHand = _player.transform.Find("inHand").gameObject;
			}
			_ActionMessage.SetActive(false);
			_PlayerHand.SetActive(true);
			_player.GetComponent<OVRPlayerController>()._PlayerGotFire=true;
			Destroy(this.gameObject);			
		}
	}
}//Class
