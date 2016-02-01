using UnityEngine;
using System.Collections;

public class FPH_PlayerRay : MonoBehaviour{

	
	public string[] playerTypeArray = new string[] {"First Person", "Third Person"};
	public int playerType;

	public bool showInteractionIcon = true;

	public float rayDistance = 20.0f;

	public Texture2D pointerText;
	public Texture2D ponter_Inventory;
	public Texture2D ponter_Inventory_Observe;
	public Texture2D pointer_Observe;
	public Texture2D pointer_Interact;
	public Texture2D pointer_Interact_Observe;
	public Texture2D pointer_ChangeLevel;
	public Texture2D pointer_ChangeLevel_Observe;
	public Texture2D pointer_Dialog;
	public Texture2D pointer_ShowText;
	public Texture2D ponter_Door;
	public Texture2D ponter_Door_Observe;
	public Texture2D ponter_DoorDrag;
	public Texture2D ponter_DoorDrag_Observe;
	
	public string english_inventoryObjMessage = "Press K to put in inventory";
	public string english_inventoryObjMessage_Observe = "Press K to put in inventory or L to Observe";
	public string english_observeObjMessage = "Press L to Observe";
	public string english_interactObjMessage = "Press J to Interact";
	public string english_interactObjMessage_Observe = "Press J to Interact or L to Observe";
	public string english_changeLvlObjMessage = "Press J to change level";
	public string english_changeLvlObjMessage_Observe = "Press J to change level or L to Observe";
	public string english_dialogObjMessage = "Press L to talk";
	public string english_showTextMessage = "Press L to read";
	public string english_batteryObjMessage = "Press K to take battery";
	public string english_batteryObjMessage_Observe = "Press K to take battery or L to Observe";
	public string english_doorObjMessage = "Press J to open/close door";
	public string english_doorObjMessage_Observe = "Press J to open/close the door or L to Observe";
	public string english_dragDoorObjMessage_Observe = "Use mouse to open the door or L to Observe";
	
	public string italian_inventoryObjMessage;
	public string italian_inventoryObjMessage_Observe;
	public string italian_observeObjMessage;
	public string italian_interactObjMessage;
	public string italian_interactObjMessage_Observe;
	public string italian_changeLvlObjMessage;
	public string italian_changeLvlObjMessage_Observe;
	public string italian_dialogObjMessage;
	public string italian_showTextMessage;
	public string italian_batteryObjMessage;
	public string italian_batteryObjMessage_Observe;
	public string italian_doorObjMessage;
	public string italian_doorObjMessage_Observe;
	public string italian_dragDoorObjMessage_Observe;
	
	public string german_inventoryObjMessage;
	public string german_inventoryObjMessage_Observe;
	public string german_observeObjMessage;
	public string german_interactObjMessage;
	public string german_interactObjMessage_Observe;
	public string german_changeLvlObjMessage;
	public string german_changeLvlObjMessage_Observe;
	public string german_dialogObjMessage;
	public string german_showTextMessage;
	public string german_batteryObjMessage;
	public string german_batteryObjMessage_Observe;
	public string german_doorObjMessage;
	public string german_doorObjMessage_Observe;
	public string german_dragDoorObjMessage_Observe;
	
	public string spanish_inventoryObjMessage;
	public string spanish_inventoryObjMessage_Observe;
	public string spanish_observeObjMessage;
	public string spanish_interactObjMessage;
	public string spanish_interactObjMessage_Observe;
	public string spanish_changeLvlObjMessage;
	public string spanish_changeLvlObjMessage_Observe;
	public string spanish_dialogObjMessage;
	public string spanish_showTextMessage;
	public string spanish_batteryObjMessage;
	public string spanish_batteryObjMessage_Observe;
	public string spanish_doorObjMessage;
	public string spanish_doorObjMessage_Observe;
	public string spanish_dragDoorObjMessage_Observe;
	
	public string japanese_inventoryObjMessage;
	public string japanese_inventoryObjMessage_Observe;
	public string japanese_observeObjMessage;
	public string japanese_interactObjMessage;
	public string japanese_interactObjMessage_Observe;
	public string japanese_changeLvlObjMessage;
	public string japanese_changeLvlObjMessage_Observe;
	public string japanese_dialogObjMessage;
	public string japanese_showTextMessage;
	public string japanese_batteryObjMessage;
	public string japanese_batteryObjMessage_Observe;
	public string japanese_doorObjMessage;
	public string japanese_doorObjMessage_Observe;
	public string japanese_dragDoorObjMessage_Observe;
	
	public string french_inventoryObjMessage;
	public string french_inventoryObjMessage_Observe;
	public string french_observeObjMessage;
	public string french_interactObjMessage;
	public string french_interactObjMessage_Observe;
	public string french_changeLvlObjMessage;
	public string french_changeLvlObjMessage_Observe;
	public string french_dialogObjMessage;
	public string french_showTextMessage;
	public string french_batteryObjMessage;
	public string french_batteryObjMessage_Observe;
	public string french_doorObjMessage;
	public string french_doorObjMessage_Observe;
	public string french_dragDoorObjMessage_Observe;
	
	public string chinese_inventoryObjMessage;
	public string chinese_inventoryObjMessage_Observe;
	public string chinese_observeObjMessage;
	public string chinese_interactObjMessage;
	public string chinese_interactObjMessage_Observe;
	public string chinese_changeLvlObjMessage;
	public string chinese_changeLvlObjMessage_Observe;
	public string chinese_dialogObjMessage;
	public string chinese_showTextMessage;
	public string chinese_batteryObjMessage;
	public string chinese_batteryObjMessage_Observe;
	public string chinese_doorObjMessage;
	public string chinese_doorObjMessage_Observe;
	public string chinese_dragDoorObjMessage_Observe;
	
	public string russian_inventoryObjMessage;
	public string russian_inventoryObjMessage_Observe;
	public string russian_observeObjMessage;
	public string russian_interactObjMessage;
	public string russian_interactObjMessage_Observe;
	public string russian_changeLvlObjMessage;
	public string russian_changeLvlObjMessage_Observe;
	public string russian_dialogObjMessage;
	public string russian_showTextMessage;
	public string russian_batteryObjMessage;
	public string russian_batteryObjMessage_Observe;
	public string russian_doorObjMessage;
	public string russian_doorObjMessage_Observe;
	public string russian_dragDoorObjMessage_Observe;

	private Texture2D privatePointerText;


	// Use this for initialization
	void Start(){
		privatePointerText = pointerText;
	}
	
	/*
	 * This script is really easy. We cast a ray and when the ray hit something
	 * we can interact with we change the main pointer to let the player know
	 * that he can interact with this object.
	 * Buttons are defined inside " FPH_ControlManager ".
	 */
	void Update(){
		RaycastHit hit;
		Vector3 frontDir = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, frontDir * rayDistance, Color.green);
		if(Physics.Raycast(transform.position, frontDir, out hit, rayDistance) && FPH_ControlManager.canBeControlled){
			if(hit.transform.gameObject.tag == "InventoryObject"){
				if(hit.transform.gameObject.GetComponent<FPH_InventoryInteractObject>().canBeObserved){
					if(showInteractionIcon){
						privatePointerText = ponter_Inventory_Observe;
					}
					else{
						ShowTextPerLanguage(
							english_inventoryObjMessage_Observe
							);
					}
				}
				if(!hit.transform.gameObject.GetComponent<FPH_InventoryInteractObject>().canBeObserved){
					if(showInteractionIcon){
						privatePointerText = ponter_Inventory;
					}
					else{
						ShowTextPerLanguage(
							english_inventoryObjMessage
							);
					}
				}

				if(Input.GetKeyUp(FPH_ControlManager.static_inventoryObjButton)){
					hit.transform.gameObject.SendMessage("ObtainObj", SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_InventoryInteractObject>().canBeObserved){
					hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "ObserveObject"){ 
				if(showInteractionIcon){
					privatePointerText = pointer_Observe;
				}
				else{
					ShowTextPerLanguage(
						english_observeObjMessage
						);
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_observeButton)){
					hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "InteractObject"){// InventoryObject ObserveObject  InteractObject   
				if(hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					if(showInteractionIcon){
						privatePointerText = pointer_Interact_Observe;
					}
					else{
						ShowTextPerLanguage(
							english_interactObjMessage_Observe
							);
					}
				}
				if(!hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					if(showInteractionIcon){
						privatePointerText = pointer_Interact;
					}
					else{
						ShowTextPerLanguage(
							english_interactObjMessage
							);
					}
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_interactButton)){
					hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "ChangeLevelObject"){
				if(hit.transform.gameObject.GetComponent<FPH_ChangeLevelOrPos>().canBeObserved){
					if(showInteractionIcon){
						privatePointerText = pointer_ChangeLevel_Observe;
					}
					else{
						ShowTextPerLanguage(
							english_changeLvlObjMessage_Observe
							);
					}
				}
				if(!hit.transform.gameObject.GetComponent<FPH_ChangeLevelOrPos>().canBeObserved){
					if(showInteractionIcon){
						privatePointerText = pointer_ChangeLevel;
					}
					else{
						ShowTextPerLanguage(
							english_changeLvlObjMessage
							);
					}
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_interactChangeLevelButton)){
					hit.transform.gameObject.SendMessage("ShowChangeLevel", SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_ChangeLevelOrPos>().canBeObserved){
					hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "DialogObject"){
				if(showInteractionIcon){
					privatePointerText = pointer_Dialog;
				}
				else{
					ShowTextPerLanguage(
						english_dialogObjMessage
						);
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_interactDialogButton)){
					hit.transform.gameObject.SendMessage("Talk");
				}
			}
			else if(hit.transform.gameObject.tag == "ShowTextObject"){
				if(showInteractionIcon){
					privatePointerText = pointer_ShowText;
				}
				else{
					ShowTextPerLanguage(
						english_showTextMessage
						);
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_showTextButton)){
					hit.transform.gameObject.SendMessage("ShowText", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "BatteryObject"){
				if(hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					if(showInteractionIcon){
						privatePointerText = ponter_Inventory_Observe;
					}
					else{
						ShowTextPerLanguage(
							english_batteryObjMessage_Observe
							);
					}
				}
				if(!hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					if(showInteractionIcon){
						privatePointerText = ponter_Inventory;
					}
					else{
						ShowTextPerLanguage(
							english_batteryObjMessage
							);
					}
				}
				
				if(Input.GetKeyUp(FPH_ControlManager.static_inventoryObjButton)){
					hit.transform.gameObject.SendMessage("ObtainObj", SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_ObserveObject>()){
					hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(hit.transform.gameObject.tag == "DoorObject"){
				if(hit.transform.gameObject.GetComponent<FPH_DoorObject>()){
					if(hit.transform.gameObject.GetComponent<FPH_DoorObject>().canBeObserved){
						if(showInteractionIcon){
							privatePointerText = ponter_Door_Observe;
						}
						else{
							ShowTextPerLanguage(
								english_doorObjMessage_Observe
								);
						}
					}
					if(!hit.transform.gameObject.GetComponent<FPH_DoorObject>().canBeObserved){
						if(showInteractionIcon){
							privatePointerText = ponter_Door;
						}
						else{
							ShowTextPerLanguage(
								english_doorObjMessage
								);
						}
					}
					
					if(Input.GetKeyUp(FPH_ControlManager.static_interactDoorButton)){
						hit.transform.gameObject.SendMessage("OpenDoor", SendMessageOptions.DontRequireReceiver);
					}
					
					if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_DoorObject>().canBeObserved){
						hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
					}
				}
				if(hit.transform.gameObject.GetComponent<FPH_DoorObject_Drag>()){
					if(hit.transform.gameObject.GetComponent<FPH_DoorObject_Drag>().canBeObserved){
						if(showInteractionIcon){
							privatePointerText = ponter_DoorDrag_Observe;
						}
						else{
							privatePointerText = ponter_DoorDrag;
							ShowTextPerLanguage(
								english_dragDoorObjMessage_Observe
								);
						}
					}
					if(!hit.transform.gameObject.GetComponent<FPH_DoorObject_Drag>().canBeObserved){
						privatePointerText = ponter_DoorDrag;
					}
					
					if(Input.GetKeyUp(FPH_ControlManager.static_observeButton) && hit.transform.gameObject.GetComponent<FPH_DoorObject_Drag>().canBeObserved){
						hit.transform.gameObject.SendMessage("Observe", SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			else{
				privatePointerText = pointerText;
				FPH_LanguageManager.static_observeTextMesh.text = "";
			}
		}
		else{
			privatePointerText = pointerText;
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
	}

	void OnGUI(){
		if(FPH_ControlManager.canBeControlled){
			if(playerType == 1){
				if(privatePointerText != pointerText){
					GUI.DrawTexture(new Rect(1.0f, (Screen.height * 0.694444444f), (Screen.width * 0.00703125f) * 23.0f, (Screen.height * 0.0125f) * 23.0f), privatePointerText);
				}
			}
			if(playerType == 0){
				if(showInteractionIcon){
					if(privatePointerText == pointerText){
						GUI.DrawTexture(new Rect((Screen.width/2) - (Screen.width * 0.003515625f), (Screen.height/2) - (Screen.height * 0.00625f), (Screen.width * 0.00703125f), (Screen.height * 0.0125f)), privatePointerText);
					}
					if(privatePointerText != pointerText){
						GUI.DrawTexture(new Rect((Screen.width/2) - (Screen.width * 0.080859375f), (Screen.height/2) - (Screen.height * 0.143055555f), (Screen.width * 0.00703125f) * 23.0f, (Screen.height * 0.0125f) * 23.0f), privatePointerText);
					}
				}
				else{
					GUI.DrawTexture(new Rect((Screen.width/2) - (Screen.width * 0.003515625f), (Screen.height/2) - (Screen.height * 0.00625f), (Screen.width * 0.00703125f), (Screen.height * 0.0125f)), pointerText);
				}
			}
		}
	}

	void ShowTextPerLanguage(string englishText = "", string spanishText = "", string italianText = "", string germanText = "", string frenchText = "", string japaneseText = "", string chineseText = "", string russianText = ""){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = englishText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = spanishText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = italianText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = germanText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = frenchText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = japaneseText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = chineseText;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = russianText;
		}
	}
}