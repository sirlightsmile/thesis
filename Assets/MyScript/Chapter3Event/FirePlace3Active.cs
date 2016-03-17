using UnityEngine;
using System.Collections;

public class FirePlace3Active : MonoBehaviour {

	public GameObject _ActionMessage;
	public GameObject _PlayerHand;
	public bool _FireLit = false;
	public GameObject _Flame;
	public GameObject _SecondCamera;
	public GameObject _enemyAI;
	public GameObject _girlAI;
	public GameObject _CandleFlame;
	public GameObject _player;
	public GameObject _LastFire;
	public GameObject _DisableWall;
	public GameObject _HiddenWall;
	public GameObject _RedLight;
	public GameObject _NormalLight;
	
	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			_player=_col.gameObject;
			if(_col.GetComponent<OVRPlayerController>()._PlayerGotFire==true && _FireLit==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Press B : Light fire.";
				_ActionMessage.SetActive(true);
				SetFire(_col.gameObject);
			}else if (_col.GetComponent<OVRPlayerController>()._PlayerGotFire==false && _FireLit==false){
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text="Need fuel to light fire.";
				_ActionMessage.SetActive(true);
			}
		}
	}//TriggerStay
	
	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_ActionMessage.SetActive(false);
		}
	}//TriggerExit
	
	void SetFire(GameObject _player){
		if (OVRGamepadController.GPC_GetButtonDown(OVRGamepadController.Button.B)){
			if(_PlayerHand==null){
				_PlayerHand = _player.transform.Find("inHand").gameObject;
			}
			_ActionMessage.SetActive(false);
			_PlayerHand.SetActive(false);
			_FireLit = true;
			_Flame.SetActive(true);
			_player.GetComponent<OVRPlayerController>()._PlayerGotFire=false;
			StartCoroutine(HiddenDoorActive());
		}
	}

	IEnumerator HiddenDoorActive(){
		yield return new WaitForSeconds(1f);
		_SecondCamera.GetComponent<SecondCameraPos> ().enabled = false;
		_SecondCamera.SetActive (true);
		_enemyAI.SetActive(false);
		_girlAI.SetActive(false);
		_player.SetActive (false);
		yield return new WaitForSeconds(1f);
		_CandleFlame.SetActive (true);
		yield return new WaitForSeconds(1.5f);
		_LastFire.SetActive (true);
		yield return new WaitForSeconds(5f);
		_SecondCamera.GetComponentInChildren<OVRScreenFade> ().enabled = true;
		_NormalLight.SetActive (false);
		_RedLight.SetActive (true);
		_DisableWall.SetActive (false);
		_HiddenWall.SetActive (true);
		_LastFire.SetActive (false);
		yield return new WaitForSeconds(3f);
		_SecondCamera.GetComponentInChildren<ScreenFadeOut> ().enabled = true;
		yield return new WaitForSeconds(3f);
		_player.SetActive (true);
	}
}
