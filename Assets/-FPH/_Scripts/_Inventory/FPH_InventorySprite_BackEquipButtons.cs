using UnityEngine;
using System.Collections;

public class FPH_InventorySprite_BackEquipButtons : MonoBehaviour {

	public enum ButtonEnum {Back, Equip}
	public ButtonEnum buttonType = ButtonEnum.Back;

	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		
	}
	
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
		HandleButtonUp();
	}
	
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	public void OnTouchDown(){
		HandleButtonDown();
	}
	
	
	void HandleButtonUp(){
		buttonSprite.sprite = spriteReleased;
		
		if(buttonType == ButtonEnum.Back){
			FPH_InventoryManager.selectedIndex = -1;
			FPH_InventoryManager.equippedItem = "";
			FPH_InventoryManager.equippedItem_Index = -1;
		}
		if(buttonType == ButtonEnum.Equip){
			FPH_InventoryManager.EquipObject();
		}
	}
	
	void HandleButtonDown(){
		buttonSprite.sprite = spritePressed;
	}
}
