using UnityEngine;
using System.Collections;

public class FPH_LanguageManager : MonoBehaviour {

	public enum LanguagesEnum {English, Spanish, Italian, German, French, Japanese, Chinese, Russian}
	
	public TextMesh observeTextMesh;

	public bool isDebugging;
	public LanguagesEnum debugLanguage = LanguagesEnum.English;

	public static LanguagesEnum gameLanguage = LanguagesEnum.English;
	public static TextMesh static_observeTextMesh;
	public static GameObject showTextObj;
	public static GameObject showTextObj_Sprite;
	public static int showTextID;


	// Use this for initialization
	void Awake(){
		static_observeTextMesh = observeTextMesh;
		showTextObj = null;
		showTextObj_Sprite = null;
		showTextID = 0;

		if(isDebugging){
			gameLanguage = debugLanguage;
		}
		else{
			if(Application.systemLanguage == SystemLanguage.English){
				gameLanguage = LanguagesEnum.English;
			}
			else if(Application.systemLanguage == SystemLanguage.Spanish){
				gameLanguage = LanguagesEnum.Spanish;
			}
			else if(Application.systemLanguage == SystemLanguage.Italian){
				gameLanguage = LanguagesEnum.Italian;
			}
			else if(Application.systemLanguage == SystemLanguage.German){
				gameLanguage = LanguagesEnum.German;
			}
			else if(Application.systemLanguage == SystemLanguage.French){
				gameLanguage = LanguagesEnum.French;
			}
			else if(Application.systemLanguage == SystemLanguage.Japanese){
				gameLanguage = LanguagesEnum.Japanese;
			}
			else if(Application.systemLanguage == SystemLanguage.Chinese){
				gameLanguage = LanguagesEnum.Chinese;
			}
			else if(Application.systemLanguage == SystemLanguage.Russian){
				gameLanguage = LanguagesEnum.Russian;
			}
			else{ // If system language is an unsupported language set game language to english
				gameLanguage = LanguagesEnum.English;
			}
		}
	}
}
