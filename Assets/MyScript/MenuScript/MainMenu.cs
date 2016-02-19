using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public GameObject[] _menuUI = new GameObject[3];
	public GameObject _GameName;
	public bool _continueButtonActive;
	public int _menuSelect;
	public Sprite _highlight ;
	public Sprite _normal ;
	public bool _menuReady;
	public bool _ChapterSelect;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("NextFromLoad") != null && PlayerPrefs.GetString ("NextFromLoad") != "Chapter 1-Part1") {
			_continueButtonActive = true;
		} else {
			_continueButtonActive = false;
		}
		if (_continueButtonActive == false) {
			_menuUI [1].GetComponentInChildren<Text> ().color = Color.grey;
		} else {
			_menuUI [1].GetComponentInChildren<Text> ().color = Color.white;
		}
		_menuReady = false;
		foreach (GameObject _m in _menuUI) {
			_m.SetActive (false);
		}
		_menuSelect = 0;
		_menuUI[0].GetComponent<Image> ().sprite=_highlight;
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (_GameName.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gamename") == false && _menuReady == false) {
			_menuReady=true;
			foreach (GameObject _m in _menuUI) {
				_m.SetActive (true);
			}
		}

		if (_menuReady == true) {
			if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Up)) {
				if (_menuSelect > 0) {
					_menuSelect -= 1;
					if(_continueButtonActive==false && _ChapterSelect==false){
						_menuSelect=0;
					}
				}
			
			} else if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Down)) {
				if (_menuSelect < 2) {
					_menuSelect += 1;
					if(_continueButtonActive==false && _ChapterSelect==false){
						_menuSelect=2;
					}
				}
			} 
			MainMenuSelect ();
			//ok button
			if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)) {
				switch (_menuSelect) {
				case 0:
					Debug.Log ("New Game");
					if(_ChapterSelect==true){
						PlayerPrefs.SetString("NextFromLoad","Chapter 1-Part1");
						Application.LoadLevel("LoadingScene");
					}else{
						_ChapterSelect=true;
						_menuSelect=0;
						_menuUI[0].GetComponentInChildren<Text>().text="Chapter 1";
						_menuUI[1].GetComponentInChildren<Text>().text="Chapter 2";
						_menuUI [1].GetComponentInChildren<Text> ().color = Color.white;
						_menuUI[2].GetComponentInChildren<Text>().text="Chapter 3";
					}
					break;
				case 1:
					if(_ChapterSelect==true){
						PlayerPrefs.SetString("NextFromLoad","Chapter2-1");
						Application.LoadLevel("LoadingScene");
					}else{
						Application.LoadLevel("LoadingScene");
						Debug.Log ("Continue");
					}
					break;
				case 2:
					if(_ChapterSelect==true){
						Debug.Log("Chapter3");
						//PlayerPrefs.SetString("NextFromLoad","Chapter3-1");
						//Application.LoadLevel("LoadingScene");
					}else{
						Debug.Log ("Exit Game");
						Application.Quit();
					}
					break;
				}
			}else if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.A)){
				if(_ChapterSelect==true){
					_ChapterSelect=false;
					_menuUI[0].GetComponentInChildren<Text>().text="New Game";
					_menuUI[1].GetComponentInChildren<Text>().text="Continue";
					_menuUI [1].GetComponentInChildren<Text> ().color = Color.white;
					_menuUI[2].GetComponentInChildren<Text>().text="Exit Game";
					if (_continueButtonActive == false) {
						_menuUI [1].GetComponentInChildren<Text> ().color = Color.grey;
					} else {
						_menuUI [1].GetComponentInChildren<Text> ().color = Color.white;
					}
				}

			}
		}
	}//update


	void MainMenuSelect(){
		switch(_menuSelect){
		case 0 : _menuUI[0].GetComponent<Image> ().sprite=_highlight;
			_menuUI[1].GetComponent<Image> ().sprite=_normal;
			_menuUI[2].GetComponent<Image> ().sprite=_normal;
			break;
		case 1 : _menuUI[0].GetComponent<Image> ().sprite=_normal;
			_menuUI[1].GetComponent<Image> ().sprite=_highlight;
			_menuUI[2].GetComponent<Image> ().sprite=_normal;
			break;
		case 2 : _menuUI[0].GetComponent<Image> ().sprite=_normal;
			_menuUI[1].GetComponent<Image> ().sprite=_normal;
			_menuUI[2].GetComponent<Image> ().sprite=_highlight;
			break;
		}
	}//main menu active
}
