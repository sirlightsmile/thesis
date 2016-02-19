using UnityEngine;
using System.Collections;

public class TurnOffThink : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (ThinkOFF ());
	}
	
	IEnumerator ThinkOFF(){
		yield return new WaitForSeconds (5f);
		gameObject.SetActive (false);
	}
}
