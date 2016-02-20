using UnityEngine;
using System.Collections;

public class CutScene2Control : MonoBehaviour {
	public GameObject _Camera1;
	public GameObject _Camera2;
	public GameObject _cameraPos;
	public GameObject Flame;
	public GameObject Flame2;
	public GameObject _Candle;
	public GameObject _CandleFlame;
	public GameObject _CandleFlame2;

	void Start () {
		StartCoroutine (CutScene2Event1 ());
	}
	IEnumerator CutScene2Event1(){
		yield return new WaitForSeconds(3f);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds(2f);
		FaceToEvent._turning = false;
		yield return new WaitForSeconds(1f);
		_Candle.transform.parent = _Camera1.transform;
		_Candle.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		Flame.SetActive (true);
		yield return new WaitForSeconds(3f);
		_Camera2.SetActive (true);
		_Camera1.SetActive (false);
		yield return new WaitForSeconds(1.5f);
		_CandleFlame.SetActive (true);
		yield return new WaitForSeconds(1.5f);
		_Camera1.transform.position = _cameraPos.transform.position;
		_Camera1.transform.rotation = _cameraPos.transform.rotation;
		_Camera1.SetActive (true);
		_Camera2.SetActive (false);
		_Candle.SetActive(true);
		yield return new WaitForSeconds(3f);
		_Candle.SetActive(false);
		Flame2.SetActive(true);
		yield return new WaitForSeconds(3f);
		_Camera2.SetActive (true);
		_Camera1.SetActive (false);
		yield return new WaitForSeconds(1.5f);
		_CandleFlame2.SetActive (true);
		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel ("CutScene2-2");

	}//event
}
