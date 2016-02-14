using UnityEngine;
using System.Collections;

public class EnemySideAlert : MonoBehaviour {

	private Animator _EnemyAnimator;

	void OnTriggerEnter(Collider _col){
		if (_EnemyAnimator == null) {
			_EnemyAnimator = gameObject.GetComponentInParent<Animator> ();
		}
		if (_col.tag == "Player") {
			//if player in sight .so ATTACK animation
			if (this._EnemyAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Atk") != true
				&& gameObject.GetComponentInParent<EnemySight> ().playerInSight == true) {
				_EnemyAnimator.SetBool ("Attack", true);
			}
			//heart beat sound

		} 
	
	}

	//this class for when too close from enemy so enemy hearing player if not sneaking
	void OnTriggerStay(Collider _col){
		//if player is walking and not sneaking rotate to player and chase.
		if (_col.tag == "Player" && OVRPlayerController._isSneaking==false &&
		    _col.gameObject.GetComponent<OVRPlayerController>()._isWalking==true) {

			if(gameObject.GetComponentInParent<EnemySight>().playerInSight==false){
				gameObject.GetComponentInParent<EnemySight>().playerInSight=true;
				transform.parent.gameObject.transform.LookAt(_col.transform);
			}//if player in sight not true demon should still feel it.//to close

			//if player in sight and animation is not ATTACK so ATTACK
			if (_EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack")!=true 
			    && gameObject.GetComponentInParent<EnemySight>().playerInSight==true)
			{
				_EnemyAnimator.SetBool ("Attack", true);
			}
		}

	}//TriggerStay

	void rotateTowards(GameObject _player) {
		Vector3 relativePos = _player.transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos.normalized);
		rotation.x = 0.0f;
		rotation.z = 0.0f;
		Quaternion current = transform.localRotation;
		transform.localRotation = Quaternion.Slerp(current,rotation,Time.deltaTime*10);
	}//rotateToward
}
