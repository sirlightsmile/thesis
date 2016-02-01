using UnityEngine;
using System.Collections;

public class Event2Active : MonoBehaviour {
	public GameObject _event2;
	public GameObject _hint;
	public GameObject _tutorial3;
	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			_tutorial3.SetActive(true);
			_event2.SetActive(true);
			_hint.GetComponent<UnityEngine.UI.Text>().text="Hint : Get a key and go to Dinner room.";
			Destroy (this.gameObject);
		}
	}
}
