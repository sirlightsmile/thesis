using UnityEngine;
using System.Collections;

public class Event3CP1 : MonoBehaviour {
	public GameObject _door;
	public GameObject _event32;
	public GameObject _hint;
	public GameObject _tutorial3;
	
	//if door still open will close door and get _event3-2 Active on Scene
	//and finally destroy self
	void OnTriggerEnter(Collider _col){
		if(_col.tag=="Player"){
			//close door if it still open
			if(_door.GetComponent<Door>()._isOpen==true){
				_door.GetComponent<Door>().DoorInteractive("Player");
			}
			_door.GetComponent<Door>()._Locked=true;
			_door.GetComponent<Door>()._PlayerGotKey=false;
			_event32.SetActive(true);
			_hint.GetComponent<UnityEngine.UI.Text>().text="Find a place to hide.";
			_tutorial3.SetActive(false);
			Destroy(this.gameObject);
		}

	}//triggerEnter
}
