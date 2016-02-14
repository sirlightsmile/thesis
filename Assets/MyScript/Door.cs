using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool _Locked = false;
	public bool _isOpen=false;
	public bool _isAutomaticClose=true;
	public bool _PlayerGotKey = false;
	private bool _isAnimate = false;
	private AudioClip _doorOpenSound;
	private AudioClip _doorCloseSound;
	private AudioClip _doorLockedSound;
	private AudioClip _doorUnlockSound;
	private AudioSource DoorAS;

	void Start(){
		DoorAS = GetComponent<AudioSource> ();
		_doorOpenSound = (AudioClip) Resources.Load ("Sound/DoorOpen");
		_doorCloseSound = (AudioClip) Resources.Load ("Sound/DoorClose");
		_doorLockedSound = (AudioClip) Resources.Load ("Sound/DoorLock");
		_doorUnlockSound = (AudioClip) Resources.Load ("Sound/DoorUnlock");

	}//start


	public void DoorInteractive(string _who){
		//if it enemy don't care if door lock or not
		if (_who == "Enemy") {
			if (_isOpen == false && _isAnimate == false) {
				_isAnimate = true;
				OpenDoor ();
			} else if (_isOpen == true && _isAnimate == false) {
				_isAnimate = true;
				CloseDoor ();
			}
		
		} else {
			if (_isOpen == false && _Locked != true && _isAnimate == false) {
				_isAnimate = true;
				OpenDoor ();
			} else if (_isOpen == true && _Locked != true && _isAnimate == false) {
				_isAnimate = true;
				CloseDoor ();
			}
			
			if (_Locked == true && _PlayerGotKey == false) {
				DoorAS.clip = _doorLockedSound;
				DoorAS.Play ();
			} else if (_Locked == true && _PlayerGotKey == true) {
				DoorAS.clip = _doorUnlockSound;
				DoorAS.Play ();
				_Locked = false;
			}
		}
	}//DoorInteractive

	void OpenDoor(){
		if (_Locked != true && _isOpen==false) {
			//sound
			DoorAS.clip=_doorOpenSound;
			DoorAS.Play ();
			//active
			gameObject.GetComponent<BoxCollider>().isTrigger=true;
			_isOpen=true;
			gameObject.GetComponent<Animation>().Play("FPH_Door_Open");
			StartCoroutine(AnimateDoorOpen());
		}
	}//openDoor

	void CloseDoor(){
		//sound
		DoorAS.clip=_doorCloseSound;
		DoorAS.Play ();
		//active
		gameObject.GetComponent<BoxCollider>().isTrigger=true;
		_isOpen = false;
		gameObject.GetComponent<Animation>().Play("FPH_Door_Close");
		StartCoroutine(AnimateDoorClose());

	}//closeDoor

	IEnumerator AnimateDoorOpen(){
		yield return new WaitForSeconds (0.5f);
		_isAnimate = false;
		if (_isAutomaticClose == false) {
			gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		}
	}
	IEnumerator AnimateDoorClose(){
		yield return new WaitForSeconds (0.5f);
		_isAnimate = false;
		gameObject.GetComponent<BoxCollider> ().isTrigger = false;
	}

}
