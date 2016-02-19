﻿using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {
	public LayerMask _targetLayerMask;
	public GameObject _ClueMessage;
	public static bool _clueHit;

	void Start(){
		_clueHit = false;
	}
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position,fwd, out hit ,1, _targetLayerMask)) {
			Debug.DrawRay (transform.position, fwd, Color.red);
			if(hit.collider.tag=="Clue"){
				if (OVRGamepadController.GPC_GetButtonDown (OVRGamepadController.Button.B)) {
					if(hit.collider.gameObject.GetComponent<ClueActive>()!=null){
					hit.collider.gameObject.GetComponent<ClueActive>().EventStart();
					}
				}
			}
		}
		//otherHit
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			if(hit.collider.tag=="Clue"){
				Debug.DrawRay (transform.position, fwd, Color.red);
				hit.transform.SendMessage ("HitByRay");
			}
			if(hit.collider.tag=="ClueMessage" && _ClueMessage!=null){
				Debug.DrawRay (transform.position, fwd, Color.red);
				hit.transform.SendMessage ("HitByRay");
				if(_ClueMessage.activeSelf==false){
					_ClueMessage.SetActive(true);
				}
			}else{
				if(_ClueMessage.activeSelf==true){
					_ClueMessage.SetActive(false);
				}
			}
		}
	}//update
}
