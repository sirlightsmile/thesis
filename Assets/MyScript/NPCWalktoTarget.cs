using UnityEngine;
using System.Collections;

public class NPCWalktoTarget : MonoBehaviour {
	private bool _walk = true;
	public GameObject _particle;
	public GameObject _hint;
	public GameObject _target;

	void Start(){
		gameObject.GetComponent<Animator>().SetBool("Walk",true);
		_particle = (GameObject)Resources.Load ("Particle/DustPoof/Disappear");
	}
	void Update(){
		if (_walk == true && _target!=null) {
			rotateTowards(_target);
			transform.Translate (Vector3.forward*Time.deltaTime);
		}

	}
	void OnTriggerEnter (Collider _col){
		if (_col.gameObject==_target) {
			gameObject.GetComponent<Animator>().SetBool("Walk",false);
			_walk=false;
			StartCoroutine(Disappear());
		}
	}//trigger

	void rotateTowards(GameObject _target) {
		Vector3 relativePos = _target.transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos.normalized);
		rotation.x = 0.0f;
		rotation.z = 0.0f;
		Quaternion current = transform.localRotation;
		transform.localRotation = Quaternion.Slerp(current,rotation,Time.deltaTime*10);
	}//rotateToward

	IEnumerator Disappear(){
		yield return new WaitForSeconds (4f);
		Instantiate (_particle, gameObject.transform.position, gameObject.transform.rotation);
		if (_hint != null) {
			_hint.SetActive (true);
		}
		Destroy(this.gameObject);
	}
}
