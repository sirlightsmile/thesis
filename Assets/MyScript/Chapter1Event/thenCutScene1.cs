using UnityEngine;
using System.Collections;

public class thenCutScene1 : MonoBehaviour {
	private float _timer=0;
	public GameObject _checkpoint;
	void Update () {
		if (gameObject.GetComponent<HiddenCameraActive> ()._hiding == true) {
			gameObject.GetComponent<HiddenCameraActive>()._canActive=false;
			switch ((int)_timer){
			case 1 : _checkpoint.GetComponent<UnityEngine.UI.Text>().text="Checkpoint."; break;
			case 2 :_checkpoint.GetComponent<UnityEngine.UI.Text>().text="Checkpoint.."; break;
			case 3 :_checkpoint.GetComponent<UnityEngine.UI.Text>().text="Checkpoint..."; break;
			case 4 :_checkpoint.GetComponent<UnityEngine.UI.Text>().text="Checkpoint.."; break;
			case 5 :_checkpoint.GetComponent<UnityEngine.UI.Text>().text="Checkpoint..."; break;
			}
			_timer+=Time.deltaTime;
			_checkpoint.SetActive(true);
			Debug.Log ("To cutscene");
			if(_timer>5f){
				PlayerPrefs.SetString("NextFromLoad","CutScene1");
				Application.LoadLevel("LoadingScene");
			}
		}
	}
}
