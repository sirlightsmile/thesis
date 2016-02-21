using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CheckPoint : MonoBehaviour {
	public string _SaveScene;
	// Use this for initialization
	void OnEnable() {
		StartCoroutine (CheckPointActive ());
	}
	
	// Update is called once per frame
	IEnumerator CheckPointActive(){
		PlayerPrefs.SetString ("NextFromLoad", _SaveScene);
		gameObject.GetComponent<Text>().text="Checkpoint.";
		yield return new WaitForSeconds (1f);
		gameObject.GetComponent<Text>().text="Checkpoint..";
		yield return new WaitForSeconds (1f);
		gameObject.GetComponent<Text>().text="Checkpoint...";
		yield return new WaitForSeconds (1f);
		gameObject.GetComponent<Text>().text="Checkpoint.";
		yield return new WaitForSeconds (1f);
		gameObject.GetComponent<Text>().text="Checkpoint..";
		yield return new WaitForSeconds (1f);
		gameObject.GetComponent<Text>().text="Checkpoint...";
		yield return new WaitForSeconds (1f);
		Debug.Log ("Now save scene is " + _SaveScene);
		this.gameObject.SetActive (false);
	}
}
