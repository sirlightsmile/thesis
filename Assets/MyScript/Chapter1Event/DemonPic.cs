using UnityEngine;
using System.Collections;

public class DemonPic : MonoBehaviour {

	public GameObject _picture;
	public GameObject _clueMessage;
	public bool _firstTimeSaw = true;
	public GameObject _tutorial2;
	private bool _canActive=false;


	void Update () {
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B) ){

			if(_picture.activeSelf==false&& _canActive == true){
				_picture.gameObject.SetActive(true);
				if(_firstTimeSaw==true){
					_firstTimeSaw=false;
					gameObject.GetComponent<AudioSource>().Play();
					_tutorial2.GetComponent<Tutorial2>().CompleteTutorial2();
				}
			}else if(_picture.activeSelf==true){
				_picture.gameObject.SetActive(false);
			}
					
		}
	}

	void OnTriggerEnter (Collider _col){
		if (_col.tag == "Player") {
			_clueMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Pick up";
			_clueMessage.SetActive(true);
			_canActive=true;
		}
	}//Collision

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_clueMessage.SetActive(false);
			_picture.gameObject.SetActive(false);
			_canActive=false;
		}
	}
}
