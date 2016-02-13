using UnityEngine;
using System.Collections;

public class SoundFadeInOut : MonoBehaviour {
	public bool _FadeIn;
	public bool _FadeOut;
	private AudioSource _AS;
	private float _currentVolume;
	public AudioClip _AudioFadeIn;
	private bool _done;

	// Use this for initialization
	void Start () {
		_AS = gameObject.GetComponent<AudioSource> ();
		if (_FadeIn == true) {
			_AS.clip=_AudioFadeIn;
			_AS.volume=0.0f;
			_AS.Play();
		}
		_currentVolume = _AS.volume;
		_done = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_FadeIn == true) {
			FadeIn();
		}
		if (_FadeOut == true) {
			FadeOut();
		}

		if (_done == true) {
			gameObject.GetComponent<SoundFadeInOut>().enabled=false;
		}
	}

	void FadeIn(){
		if (_AS.volume < 1f) {
			_currentVolume+=0.2f*Time.deltaTime;
			if(_currentVolume >=1f){
				_currentVolume=1f;
			}
			_AS.volume=_currentVolume;
		}
	}
	void FadeOut(){
		if (_AS.volume > 0f) {
			_currentVolume-=0.2f*Time.deltaTime;
			if(_currentVolume <=0f){
				_currentVolume=0f;
			}
			_AS.volume-=_currentVolume;
			
		}

	}
}
