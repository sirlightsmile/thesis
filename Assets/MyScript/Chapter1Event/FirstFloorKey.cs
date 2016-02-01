using UnityEngine;
using System.Collections;

public class FirstFloorKey : MonoBehaviour {
	private bool _canGet = false;
	public GameObject _key;
	public GameObject _DinerDoor;
	public GameObject _CenterDoor;
	public GameObject _KeyUI;
	public GameObject _KeyUItext;
	public GameObject _ActionClueUI;

	
	// Update is called once per frame
	void FixedUpdate(){
		if (_canGet == true && _key.activeSelf!=false) {
			GetFirstFloorKey();
		}
	}
	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player" && _key.activeSelf!=false) {
			_canGet=true;
			_ActionClueUI.SetActive(true);
		}
	}//triggerEnter

	void OnTriggerExit(Collider _col){
		_canGet = false;
		_ActionClueUI.SetActive(false);
	}//triggerExit

	void GetFirstFloorKey(){
		if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B)){
			_ActionClueUI.SetActive(false);
			_key.SetActive(false);
			_KeyUI.SetActive(true);
			_KeyUItext.SetActive(true);
			_DinerDoor.GetComponent<Door>()._PlayerGotKey=true;
			_CenterDoor.GetComponent<Door>()._PlayerGotKey=true;
			Destroy(_KeyUI,3f);
			Destroy(_KeyUItext,3f);
			_canGet=false;
		}
	}
}
