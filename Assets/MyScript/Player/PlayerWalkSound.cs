using UnityEngine;
using System.Collections;

public class PlayerWalkSound : MonoBehaviour {
	//0 sneak 1 walk 2 fastwalk
	public AudioClip[] _WalkSound=new AudioClip[3];
	private AudioSource _playerAS;
	public bool _playerWalk=false;
	// Use this for initialization
	void Start () {
		_playerAS = gameObject.GetComponent<AudioSource> ();
	}
	
	/*void LateUpdate(){
		if (_playerWalk==true && _playerAS.isPlaying==false) {
			_playerAS.Play();
		} else if (_playerWalk==false){
			_playerAS.Stop ();
		}
	}//LateUpdate*/

	public void PlayWalkSound(int _soundType){
		_playerAS.clip = _WalkSound [_soundType];
		if (_playerAS.isPlaying == false && Menu._pause==false) {
			_playerAS.Play ();
		}
	}
}//class
