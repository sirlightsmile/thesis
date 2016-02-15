using UnityEngine;
using System.Collections;

public class ToFirstFloor : MonoBehaviour {
	public bool _allow;
	public string _reason;
	public GameObject _ActionMessage;
	void OnTriggerStay(Collider _col){
		if (_col.tag == "Player") {
			if(_allow==true){
				PlayerPrefs.SetString("NextFromLoad","FirstFloor");
				Application.LoadLevel("LoadScene");
			}else{
				if(_ActionMessage==null){
					Debug.Log ("action message missing");
				}
				_ActionMessage.GetComponent<UnityEngine.UI.Text>().text=_reason;
				_ActionMessage.SetActive(true);

			}
		}
	}//TriggerStay

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			_ActionMessage.SetActive(false);
		}
	}//TriggerStay

}
