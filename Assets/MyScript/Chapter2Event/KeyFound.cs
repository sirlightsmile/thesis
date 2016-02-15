using UnityEngine;
using System.Collections;

public class KeyFound : MonoBehaviour {
	public GameObject _Master;
	// Use this for initialization
	void HitByRay(){
		print ("see key");
		_Master.GetComponent<SecondFloorKey> ()._canGet = true;
	}
}
