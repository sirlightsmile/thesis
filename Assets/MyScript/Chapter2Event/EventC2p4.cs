using UnityEngine;
using System.Collections;

public class EventC2p4 : MonoBehaviour {
	public GameObject _SoundSource;
	public GameObject _Hint;
	public GameObject _Checkpoint;

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_SoundSource.GetComponent<AudioSource>().Play();
			_Checkpoint.GetComponent<CheckPoint>()._SaveScene="Chapter2-3checkpoint";
			_Checkpoint.SetActive(true);
			_Hint.GetComponent<UnityEngine.UI.Text>().text="Hint : Searching for clue.";
			Destroy(this.gameObject);
		}
	}//TriggerEnter
}
