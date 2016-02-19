using UnityEngine;
using System.Collections;

public class PlayerThink : MonoBehaviour {
	public GameObject _ClueMessage;
	public string _Message;
	
	void HitByRay(){
			_ClueMessage.GetComponent<UnityEngine.UI.Text>().text=_Message;
	}//HitByRay

}
