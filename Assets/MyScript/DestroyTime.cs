using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {
	public float _timer=3;
	// Use this for initialization
	void Start () {
		transform.Translate (Vector3.up);
		Destroy (this.gameObject, _timer);
	}

}
