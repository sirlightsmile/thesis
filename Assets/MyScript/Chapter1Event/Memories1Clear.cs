using UnityEngine;
using System.Collections;

public class Memories1Clear : MonoBehaviour {

	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			Debug.Log("Clear");
			PlayerPrefs.SetString("NextFromLoad","Chapter 1-Part2.5");
			Application.LoadLevel("Chapter 1-Part2.5");
		}
	}
}
