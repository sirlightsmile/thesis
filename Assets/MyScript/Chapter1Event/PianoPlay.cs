using UnityEngine;
using System.Collections;

public class PianoPlay : MonoBehaviour {
	private bool _isPlaying = false;
	//0. loop play 1.End
	public AudioClip[] _pianoSound = new AudioClip[2];
	public BoxCollider _thisBoxEvent;
	private AudioSource _PianoAS;

	void Start(){
		_PianoAS = gameObject.GetComponent<AudioSource> ();
		_PianoAS.clip = _pianoSound [0];
		_PianoAS.loop = true;
		_PianoAS.Play ();
		_isPlaying = true;
	}

/*	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player" && _isPlaying==true){
					_isPlaying=false;
					_PianoAS.Stop ();
					_PianoAS.clip = _pianoSound [1];
					_PianoAS.loop = false;
				StartCoroutine(StopPiano());
				//sent to game control for progess
		}
	}//trigger Enter*/
	
	public void StopPianoActive(){
		if (_isPlaying==true){
			_isPlaying=false;
			_PianoAS.Stop ();
			_PianoAS.clip = _pianoSound [1];
			_PianoAS.loop = false;
			StartCoroutine(StopPiano());
			//sent to game control for progess
		}
	}//trigger Enter

	IEnumerator StopPiano(){
		_PianoAS.Play();
		yield return new WaitForSeconds(0.5f);
		GameObject Ambient = GameObject.Find ("GamePlayController");
		Ambient.GetComponent<AudioSource> ().Play ();
	}
}//class
