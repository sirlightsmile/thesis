using UnityEngine;
using System.Collections;

public class Memories1Control : MonoBehaviour {
	public GameObject _enemy;
	public GameObject _player;
	//public GameObject _camera;
	public GameObject _Door;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("NextFromLoad", "RenaiMemories1");
		StartCoroutine (Memories1Active ());
	}
	/*old
	IEnumerator Memories1Active(){
		yield return new WaitForSeconds (5f);
		_enemy.SetActive (true);
		_Door.GetComponent<Door> ().DoorInteractive ();
		_camera.SetActive (true);
		_player.SetActive (false);
		yield return new WaitForSeconds (5f);
		_player.SetActive (true);
		_player.GetComponentInChildren<OVRScreenFade> ().enabled = false;
		_camera.SetActive (false);
		yield return new WaitForSeconds (1f);
		_tutorial5.SetActive (true);
	}
	*/
	IEnumerator Memories1Active(){
		yield return new WaitForSeconds (5f);
		_enemy.SetActive (true);
		_Door.GetComponent<Door> ().DoorInteractive ();
	}
}
