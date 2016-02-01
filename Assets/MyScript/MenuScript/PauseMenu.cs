using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public GameObject[] _menuUI = new GameObject[3];
	public int _menuSelect;
	private GameObject _gameContoller;
	public Sprite _highlight ;
	public Sprite _normal ;
	// Use this for initialization
	void Start () {
		_gameContoller = GameObject.Find ("GamePlayController");
		_menuSelect = 0;
		//_normal = _menuUI [0].GetComponent<UnityEngine.UI.Button> ().spriteState.disabledSprite;
		//_highlight = _menuUI[0].GetComponent<UnityEngine.UI.Button> ().spriteState.highlightedSprite;
		_menuUI[0].GetComponent<Image> ().sprite=_highlight;
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Up)) {
			if(_menuSelect>0){
				_menuSelect-=1;
			}

		} else if(OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Down)){
			if(_menuSelect<2){
				_menuSelect+=1;
			}
		} 
		PauseMenuActive ();
		//ok button
		if(OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)){
			switch(_menuSelect){
				case 0 : _gameContoller.GetComponent<Menu>().PauseActive(false);
						Menu._pause=false; break;

				case 1 :Time.timeScale=1.0f; 
						Application.LoadLevel("LoadingScene");
						Debug.Log("Restart");break;

				case 2 : Time.timeScale=1.0f;
						Application.LoadLevel("MainMenu");break;
			}
		}
	}//update
	void PauseMenuActive(){
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
	}
}
