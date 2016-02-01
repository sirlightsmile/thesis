using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public static float _GameTime;
	public static bool _pause;
	public GameObject _pauseUI;
	public static bool _GameOver;
	// Use this for initialization
	void Awake () {
		_GameTime = 0;
		_GameOver = false;
		Time.timeScale = 1.0f;
		_pause = false;
	}

	void Update () {
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Start)) {
			//StartMenu
			print ("Menu");
			if(_pause==false){
				_pause=true;
			}else{
				_pause=false;
			}
			PauseActive(_pause);
		}	

		if (_GameOver == true) {
			GameOver ();
		} 

		_GameTime += Time.deltaTime;
	}//Update

	public void PauseActive(bool _p){
		if (_p == true) {
			_pauseUI.SetActive(true);
			Time.timeScale=0.0f;
		} else {
			_pauseUI.SetActive(false);
			Time.timeScale=1.0f;
		}
	}
	public void GameOver(){
		Debug.Log ("GameOver hey!");
		//GameOverScene active
		//wait 3 sec
		//retry & exit button active
		Application.LoadLevel ("GameOver");
	}

	public void CheckPoint(string sceneName){
		//save current progess to prefab
		PlayerPrefs.SetString ("NextFromLoad", sceneName);
	}//CheckPoint
}
