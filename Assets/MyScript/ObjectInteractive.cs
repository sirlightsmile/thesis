using UnityEngine;
using System.Collections;

public class ObjectInteractive : MonoBehaviour {

	public GameObject _object;
	public GameObject _clueMessage;
	public bool _firstTimeSaw = true;
	private bool _canActive=false;
	
	
	void Update () {
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B) ){
			
			if(_object.activeSelf==false&& _canActive == true){
				_object.gameObject.SetActive(true);
				if(_firstTimeSaw==true){
					_firstTimeSaw=false;
					gameObject.GetComponent<AudioSource>().Play();
				}
			}else if(_object.activeSelf==true){
				_object.gameObject.SetActive(false);
			}		
		}
	}//update
	
	void OnTriggerEnter (Collider _col){
		if (_col.tag == "Player") {
			_clueMessage.SetActive(true);
			_canActive=true;
		}
	}//Collision
	
	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_clueMessage.SetActive(false);
			_canActive=false;
		}
	}
}
