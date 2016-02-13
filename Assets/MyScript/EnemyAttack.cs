using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	private bool _gameOver = false;
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			if(gameObject.GetComponentInParent<EnemySight> ().playerInSight == false){
				gameObject.GetComponentInParent<EnemySight>().playerInSight=true;
				transform.parent.gameObject.transform.LookAt(other.transform);
				Animator _EnemyAnimator;
				_EnemyAnimator = gameObject.GetComponentInParent<Animator> ();
				if (_EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack")!=true){
					_EnemyAnimator.SetBool ("Attack", true);
				}
			}

			Debug.Log ("Player Dead");
			gameObject.GetComponentInParent<NavMeshAgent>().Stop();
			other.GetComponent<OVRPlayerController>().enabled=false;
			StartCoroutine(PlayerDead());
		}
	}

	IEnumerator PlayerDead(){
		yield return new WaitForSeconds (1f);
		Menu._GameOver = true;
	}
}
