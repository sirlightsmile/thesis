using UnityEngine;
using System.Collections;

public class CancleClue : MonoBehaviour {

	void Update () {
		if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)){
			gameObject.SetActive(false);
		}
	}//update
}
