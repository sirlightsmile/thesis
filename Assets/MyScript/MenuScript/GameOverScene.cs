using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour {
	public GameObject[] _menuUI = new GameObject[2];
	public int _menuSelect;
	public Sprite _highlight ;
	public Sprite _normal ;
	// Use this for initialization
	void Start () {
		_menuSelect = 0;
		_menuUI[0].GetComponent<Image> ().sprite=_highlight;
	}

	// Update is called once per frame
	void Update () {
			if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Up)) {
				if (_menuSelect > 0) {
					_menuSelect -= 1;
				}
			
			} else if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Down)) {
				if (_menuSelect < 1) {
					_menuSelect += 1;
				}
			} 
			MainMenuSelect ();
			//ok button
			if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)) {
				switch (_menuSelect) {
				case 0:
					Debug.Log ("Replay");
					Application.LoadLevel(PlayerPrefs.GetString("NextFromLoad"));
					break;
				case 1:
					Application.LoadLevel("MainMenu");
					break;
				}
			}
	}//update


	void MainMenuSelect(){
		switch(_menuSelect){
		case 0 : _menuUI[0].GetComponent<Image> ().sprite=_highlight;
			_menuUI[1].GetComponent<Image> ().sprite=_normal;
			break;
		case 1 : _menuUI[0].GetComponent<Image> ().sprite=_normal;
			_menuUI[1].GetComponent<Image> ().sprite=_highlight;
			break;
		}
	}//main menu active
}
