using UnityEngine;
using System.Collections;

public class ChangeAmbientLight : MonoBehaviour {
	public bool _isLightVersion = false;
	public GameObject _text;
	// Use this for initialization
	void Start () {
       //PlayerPrefs.GetString ("LightVersion")
		if ( _isLightVersion == true) {
			PlayerPrefs.SetString ("LightVersion","Yes");
			_text.SetActive(true);
		} else {
			PlayerPrefs.SetString ("LightVersion","No");
			_text.SetActive(false);
			RenderSettings.ambientLight = Color.black;
		}
	}
	
	void Update(){
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.Back)) {
			if (_isLightVersion == false) {
				PlayerPrefs.SetString ("LightVersion","Yes");
				_isLightVersion = true;
				_text.SetActive(true);
			} else {
				PlayerPrefs.SetString ("LightVersion","No");
				_isLightVersion = false;
				_text.SetActive(false);
			}
		}
	}//LateUpdate
}
