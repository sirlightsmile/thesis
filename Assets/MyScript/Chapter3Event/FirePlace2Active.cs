using UnityEngine;
using System.Collections;

public class FirePlace2Active : MonoBehaviour {

	public GameObject _ActionMessage;
	public GameObject _PlayerHand;
	public bool _FireLit = false;
	public GameObject _Flame;
	public GameObject _EventLook;
	public GameObject _SecondCamera;
	public GameObject _enemyAI;
	public GameObject _girlAI;
	
	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			if(_col.GetComponent<OVRPlayerController>()._PlayerGotFire==true && _FireLit==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Light fire.";
				_ActionMessage.SetActive(true);
				SetFire(_col.gameObject);
			}else if (_col.GetComponent<OVRPlayerController>()._PlayerGotFire==false && _FireLit==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Need fuel to light fire.";
				_ActionMessage.SetActive(true);
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
			_enemyAI.SetActive(false);
			StartCoroutine(HiddenFireplaceActive());
		}
	}

	IEnumerator HiddenFireplaceActive(){
		yield return new WaitForSeconds(3f);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = false;
		_SecondCamera.SetActive (true);

	}
}
