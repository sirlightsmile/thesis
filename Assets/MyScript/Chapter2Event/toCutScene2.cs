using UnityEngine;
using System.Collections;

public class toCutScene2 : MonoBehaviour {
	public bool _isActive=false;
	public GameObject _ActionMessage;

	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			if(_isActive==true){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Touch bloodstain.";
				_ActionMessage.SetActive(true);
				StartCutscene2();
			}
		}
	}//TriggerStay
	
	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
				_ActionMessage.SetActive(false);
				_isActive=false;
		}
	}//TriggerExit
	
	void StartCutscene2(){
		if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B)){
			Application.LoadLevel("CutScene2");
		}
	}
}
