using UnityEngine;
using System.Collections;

public class NPCWalk : MonoBehaviour {
	private bool _walk = true;
	public GameObject _particle;
	public GameObject _hint1;

	void Start(){
		gameObject.GetComponent<Animator>().SetBool("Walk",true);
	}
	void Update(){
		if (_walk == true) {
			transform.Translate (Vector3.forward*Time.deltaTime);
		}

	}
	void OnTriggerEnter (Collider _col){
		if (_col.name == "Lamp01") {
			gameObject.GetComponent<Animator>().SetBool("Walk",false);
			_walk=false;
			StartCoroutine(Disappear());
		}
	}//trigger

	IEnumerator Disappear(){
		yield return new WaitForSeconds (4f);
		Instantiate (_particle, gameObject.transform.position, gameObject.transform.rotation);
		_hint1.SetActive (true);
		Destroy(this.gameObject);
	}
}
