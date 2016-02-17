﻿using UnityEngine;
using System.Collections;

public class EventC2p4 : MonoBehaviour {
	public GameObject _SoundSource;
	public GameObject _Hint;
	public GameObject _Checkpoint;

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_SoundSource.GetComponent<AudioSource>().Play();
			_Checkpoint.GetComponent<CheckPoint>()._SaveScene="Chapter2-3";
			_Checkpoint.SetActive(true);
			_Hint.GetComponent<UnityEngine.UI.Text>().text="Hint : Light fire in fireplace.";
			Destroy(this.gameObject);
		}
	}//TriggerEnter
}
