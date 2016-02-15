using UnityEngine;
using System.Collections;

public class HiddenCameraActive : MonoBehaviour {
	public GameObject _player;
	public GameObject _hiddenCamera;
	public bool _hiding;
	public bool _canActive;
	private AudioClip _openSound;
	private AudioClip _closeSound;
	private AudioSource _WardrobeAS;

	void Start(){
		_canActive = true;
		_WardrobeAS = gameObject.GetComponent<AudioSource> ();
		_openSound = (AudioClip) Resources.Load ("Sound/OpenWardrobe");
		_closeSound = (AudioClip) Resources.Load ("Sound/CloseWardrobe");
		//_hiding = false;
	}

	void Update(){
		if (_hiding == true) {
			if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)) {
				if(_canActive==true){
					HideDisable();
				}
			}
		}
	}

	public void HideActive () {
		if (_canActive == true) {
			gameObject.GetComponent<Animator> ().SetTrigger ("ChestOpen");
			StartCoroutine (HidingIn ());
		}
	}//HideActive

	IEnumerator HidingIn(){
		_WardrobeAS.clip = _openSound;
		_WardrobeAS.Play ();
		yield return new WaitForSeconds (1.5f);
		_player.GetComponentInChildren<AnimateToHidden> ()._movingIn = true;
		_player.GetComponentInChildren<AnimateToHidden> ()._start = true;
		_player.GetComponent<OVRPlayerController> ().Jump ();
		yield return new WaitForSeconds (1f);
		_hiddenCamera.SetActive (true);
		_player.GetComponentInChildren<AnimateToHidden> ().ReToOriginalPose ();
		_player.SetActive (false);
		_hiding = true;
		GameObject _UIMessage = GameObject.Find ("ActionMessage");
		_UIMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Out";
		_WardrobeAS.clip = _closeSound;
		_WardrobeAS.Play ();
	}//hiding in

	void HideDisable(){
		gameObject.GetComponent<Animator>().SetTrigger("ChestOpen");
		_hiding = false;
		StartCoroutine (HidingOut());
	}//HideDisable

	IEnumerator HidingOut(){
		_WardrobeAS.clip = _openSound;
		_WardrobeAS.Play ();
		yield return new WaitForSeconds (2f);
		GameObject _UIMessage = GameObject.Find ("ActionMessage");
		_UIMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Hide in closet";
		_hiddenCamera.SetActive (false);
		_player.SetActive (true);
		_WardrobeAS.clip = _closeSound;
		_WardrobeAS.Play ();
	}//hidingout

}//class
