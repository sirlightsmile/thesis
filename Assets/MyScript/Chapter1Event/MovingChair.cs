using UnityEngine;
using System.Collections;

public class MovingChair : MonoBehaviour {
	public GameObject _Chair;
	public GameObject _Piano;
	public GameObject _Door;
	public GameObject _player;
	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player"){

			_Piano.GetComponent<PianoPlay> ().StopPianoActive ();
			StartCoroutine(Event1Active());
		}
	}//trigger Enter
	// with delay
	IEnumerator Event1Active(){
		yield return new WaitForSeconds (1f);
		_Chair.GetComponent<Animation>().Play();
		_Chair.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds (2f);
		_player.GetComponent<OVRPlayerController> ()._currentDoorActive = _Door;
		_Door.GetComponent<Door> ().DoorInteractive ("Player");
		Destroy(this.gameObject);
		/*
		_Chair.GetComponent<Animation>().Play();
		yield return new WaitForSeconds(0.5f);
		_Piano.GetComponent<PianoPlay> ().StopPianoActive ();
		Destroy(this.gameObject);
		*/
	}//enumerator


}
