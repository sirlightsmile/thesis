using UnityEngine;
using System.Collections;

public class CutScene1Control : MonoBehaviour {
	public GameObject _box;
	public GameObject _Enemy;
	public AudioClip _BreakSound;
	public GameObject _Door;
	public GameObject _SceneCamera;
	public GameObject _hiddenChest;
	// Use this for initialization
	void Start () {
		StartCoroutine(PlayCutScene1());
	}
	
	IEnumerator PlayCutScene1(){
		yield return new WaitForSeconds(2.5f);
		_Enemy.GetComponent<Animator> ().SetBool ("seePlayer", true);
		yield return new WaitForSeconds(2.0f);
		_Enemy.GetComponent<Animator> ().SetBool ("seePlayer", false);
		yield return new WaitForSeconds(2.0f);
		_Enemy.GetComponent<Animator> ().SetBool ("seePlayer", true);
		yield return new WaitForSeconds(0.5f);
		_Enemy.GetComponent<Animator> ().SetBool ("seePlayer", false);
		_box.GetComponent<AudioSource> ().clip = _BreakSound;
		_box.GetComponent<AudioSource> ().loop = false;
		_box.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.5f);
		_Enemy.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.5f);
		_SceneCamera.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds(3.5f);
		_hiddenChest.GetComponent<Animator> ().SetBool ("SuddenClose",true);
		yield return new WaitForSeconds(0.7f);
		_hiddenChest.GetComponent<AudioSource> ().Play ();
		_Enemy.GetComponent<EnemyWalkpath> ().enabled = true;
		_Enemy.GetComponent<NavMeshAgent> ().enabled = true;
		_SceneCamera.GetComponent<Animator> ().enabled = false;
		_SceneCamera.transform.position = new Vector3 (35.59f, 2.68f, -14.72f);
		yield return new WaitForSeconds(3f);
		_Enemy.GetComponent<Animator> ().SetBool ("Walk", false);
		_Enemy.GetComponent<EnemyWalkpath> ().enabled = false;
		_Enemy.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(5f);
		_Enemy.GetComponent<EnemyWalkpath> ().enabled = true;
		yield return new WaitForSeconds(6f);
		_Door.GetComponent<Door> ().DoorInteractive ();
		yield return new WaitForSeconds(3f);
		_Door.GetComponent<Door> ().DoorInteractive ();
		_Enemy.GetComponent<EnemyWalkpath> ().enabled = false;;
		yield return new WaitForSeconds(3f);
		//Loading Scene
		PlayerPrefs.SetString ("NextFromLoad", "Chapter 1-Part2");
		Application.LoadLevel ("LoadingScene");

	}

}
