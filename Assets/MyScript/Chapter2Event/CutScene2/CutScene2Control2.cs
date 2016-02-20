using UnityEngine;
using System.Collections;

public class CutScene2Control2 : MonoBehaviour {
	public GameObject _RenaiCamera;
	public GameObject _Girl;
	public GameObject _Demon;
	public GameObject _EventLook;
	public GameObject _Ambient;
	public bool _forward = true;
	public AudioClip _FaceTo;
	public AudioClip _NotAfraid;
	public AudioClip _Scream;
	// Use this for initialization
	void Start () {
		StartCoroutine (CutScene2Final ());
	}
	
	// Update is called once per frame
	void Update () {
		if (_forward == true) {
			_RenaiCamera.transform.Translate(Vector3.forward*Time.deltaTime*0.5f);
		}
	}

	IEnumerator CutScene2Final(){
		yield return new WaitForSeconds(5f);
		_Girl.SetActive (true);
		yield return new WaitForSeconds(1f);
		_forward = false;
		FaceToEvent._turning = true;
		gameObject.GetComponent<AudioSource> ().Stop ();
		gameObject.GetComponent<AudioSource> ().loop = false;
		gameObject.GetComponent<AudioSource> ().clip = _FaceTo;
		gameObject.GetComponent<AudioSource> ().Play ();
		//ambientChange
		_Ambient.GetComponent<SoundFadeInOut> ().enabled = true;
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = false;
		_EventLook.transform.position = _Demon.transform.position;
		yield return new WaitForSeconds(1f);
		_Girl.GetComponent<AudioSource> ().clip = _NotAfraid;
		_Girl.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(4.5f);
		FaceToEvent._turning = true;
		_Demon.SetActive (true);
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = true;

		_RenaiCamera.GetComponentInChildren<OVRScreenFade> ().enabled = false;
		_RenaiCamera.GetComponentInChildren<OVRScreenFade> ().fadeTime = 20f;
		_RenaiCamera.GetComponentInChildren<OVRScreenFade> ().enabled = true;
		yield return new WaitForSeconds(0.5f);
		FaceToEvent._turning = false;
		gameObject.GetComponent<AudioSource> ().Stop ();
		gameObject.GetComponent<AudioSource> ().clip = _Scream;
		gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(2f);
		PlayerPrefs.SetString ("NextFromLoad", "Chapter2-4");
		Application.LoadLevel ("LoadingScene");
	}//cutscene
}
