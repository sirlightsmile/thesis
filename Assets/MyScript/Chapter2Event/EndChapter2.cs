using UnityEngine;
using System.Collections;

public class EndChapter2 : MonoBehaviour {
	public GameObject _ClearText;
	void Start () {
		StartCoroutine (EndChap2Active ());
	}
	
	IEnumerator EndChap2Active(){
		yield return new WaitForSeconds(4f);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds (1f);
		FaceToEvent._turning = false;
		yield return new WaitForSeconds(3f);
		_ClearText.SetActive (true);
	}
}
