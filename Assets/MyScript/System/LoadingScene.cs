using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour {
	public string _SceneName;
	public GameObject _Text;
	
	// Update is called once per frame
	void Start(){
		_SceneName = PlayerPrefs.GetString ("NextFromLoad");
		StartCoroutine (LoadActive());
	}

	void LoadScene(){
		Application.LoadLevel (_SceneName);
	}

	IEnumerator LoadActive(){
		yield return new WaitForSeconds (1f);
		_Text.GetComponent<UnityEngine.UI.Text> ().text = "loading.";
		yield return new WaitForSeconds (1f);
		_Text.GetComponent<UnityEngine.UI.Text> ().text = "loading..";
		yield return new WaitForSeconds (1f);
		_Text.GetComponent<UnityEngine.UI.Text> ().text = "loading...";
		yield return new WaitForSeconds (1.5f);
		LoadScene ();

	}
}
