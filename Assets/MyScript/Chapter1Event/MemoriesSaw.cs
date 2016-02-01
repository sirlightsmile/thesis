using UnityEngine;
using System.Collections;

public class MemoriesSaw : MonoBehaviour {
	public GameObject _tutorial5;
	//Ambeint
	public GameObject _soundSource1;
	//JS
	public GameObject _soundSource2;
	void HitByRay(){
		_soundSource2.SetActive (true);
		StartCoroutine (MemoriesSoundStart ());
	}
	IEnumerator MemoriesSoundStart(){
		yield return new WaitForSeconds (2f);
		_soundSource1.SetActive (true);
		_tutorial5.SetActive (true);
	}
}
