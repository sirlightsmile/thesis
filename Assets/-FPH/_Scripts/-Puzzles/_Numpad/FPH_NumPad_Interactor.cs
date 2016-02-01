using UnityEngine;
using System.Collections;

public class FPH_NumPad_Interactor : MonoBehaviour {
	
	public GameObject numpadCamera;
	public GameObject ingameCamera;
	
	public string codeToCheck;

	// If the code we entered on the numpad is right we can send a message to an object or save a value
	public string[] onOkArray = new string[] {"SendMessage", "SetVar"};
	public int onOk;
	public bool reEnableOnOk; // Do you want to reenable the collider when you exit the numpad screen?

	public GameObject sendMessageTo; // Object you want to send the message to
	public string messageToSend; // The message we want to send
	
	public string[] keyTypeArray = new string[] {"Float", "Int", "String", "Bool"};
	public int keyType;

	// In case you want to save a value you can choose from four different value
	public string neededKey;
	public float valueToSet_Float;
	public int valueToSet_Int;
	public string valueToSet_String;
	public bool valueToSet_Bool;

	private Collider thisColl;


	// Use this for initialization
	void Start(){
		thisColl = gameObject.GetComponent<Collider>();
	
		if(onOk == 1){ // SetVar
			// We check if the value has been setted before, in this case we toggle the collider
			if(keyType == 0){ // Float
				float floatToCheck = PlayerPrefs.GetFloat(neededKey);
				if(floatToCheck == valueToSet_Float){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 1){ // Int
				int intToCheck = PlayerPrefs.GetInt(neededKey);
				if(intToCheck == valueToSet_Int){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 2){ // String
				string stringToCheck = PlayerPrefs.GetString(neededKey);
				if(stringToCheck == valueToSet_String){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 3){ // Bool
				bool boolToCheck = FPH_ControlManager.LoadBool(neededKey);
				if(boolToCheck == valueToSet_Bool){
					thisColl.enabled = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	public void Interact(){
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		thisColl.enabled = false;
		ingameCamera.SetActive(false);
		numpadCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = false;
	}

	// If the code is right we send the message/setvalue and then deactivate the numpadCamera
	public void DoneCode(){
		if(onOk == 0){ // SendMessage
			if(sendMessageTo != null){
				sendMessageTo.SendMessage(messageToSend);
			}
			if(sendMessageTo == null){
				Debug.LogWarning("No receiver for message - FPH_NumPad_Interactor " + this.gameObject.name);
			}

			if(reEnableOnOk){
				thisColl.enabled = true;
			}
			ingameCamera.SetActive(true);
			numpadCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
		else if(onOk == 1){ // SetVar
			if(keyType == 0){ // Float
				PlayerPrefs.SetFloat(neededKey, valueToSet_Float);
			}
			else if(keyType == 1){ // Int
				PlayerPrefs.SetInt(neededKey, valueToSet_Int);
			}
			else if(keyType == 2){ // String
				PlayerPrefs.SetString(neededKey, valueToSet_String);
			}
			else if(keyType == 3){ // Bool
				FPH_ControlManager.SaveBool(neededKey, valueToSet_Bool);
			}

			if(reEnableOnOk){
				thisColl.enabled = true;
			}
			ingameCamera.SetActive(true);
			numpadCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
	}

	public void ExitNumpad(){
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		thisColl.enabled = true;
		ingameCamera.SetActive(true);
		numpadCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}
}