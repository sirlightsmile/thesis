using UnityEngine;
using System.Collections;

public class EventC2p4 : MonoBehaviour {
	public GameObject _Checkpoint;
	public GameObject _Hint;

	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			_Checkpoint.GetComponent<CheckPoint>()._SaveScene="Chapter2-3";
			_Checkpoint.SetActive(true);
			_Hint.GetComponent<UnityEngine.UI.Text>().text="Hint : Follow white women.";
			Destroy(this.gameObject);
		}
	}//TriggerEnter
}
