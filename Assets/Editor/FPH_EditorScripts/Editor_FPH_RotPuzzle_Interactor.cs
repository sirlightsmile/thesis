using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_RotPuzzle_Interactor))] 
public class Editor_FPH_RotPuzzle_Interactor : Editor {
	public override void OnInspectorGUI() {
		FPH_RotPuzzle_Interactor myInspector = (FPH_RotPuzzle_Interactor) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 75.0f;
		myInspector.ingameCamera = (GameObject) EditorGUILayout.ObjectField("Ingame Cam: ", myInspector.ingameCamera, typeof(GameObject), true);
		EditorGUIUtility.labelWidth = 90.0f;
		myInspector.rotPuzzleCamera = (GameObject) EditorGUILayout.ObjectField("RotPuzzle Cam: ", myInspector.rotPuzzleCamera, typeof(GameObject), true);
		GUILayout.EndHorizontal();

		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 130.0f;
		myInspector.codeToCheck = EditorGUILayout.TextField("Rot OK code:", myInspector.codeToCheck);
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		myInspector.onOk = EditorGUILayout.Popup("Action on OK code:", myInspector.onOk, myInspector.onOkArray);
		EditorGUIUtility.labelWidth = 150.0f;
		myInspector.reEnableOnOk = EditorGUILayout.Toggle("ReEnable collider on exit:", myInspector.reEnableOnOk);

		if(myInspector.onOk == 0){ // SendMessage
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.sendMessageTo = (GameObject) EditorGUILayout.ObjectField("SendMessage To: ", myInspector.sendMessageTo, typeof(GameObject), true);
			myInspector.messageToSend = EditorGUILayout.TextField("Message To Send:", myInspector.messageToSend);
		}
		if(myInspector.onOk == 1){ // SetVar
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.keyType = EditorGUILayout.Popup("Value To Save:", myInspector.keyType, myInspector.keyTypeArray);
			myInspector.neededKey = EditorGUILayout.TextField("Key To Save:", myInspector.neededKey);

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(myInspector.keyType == 0){ // Float
				myInspector.valueToSet_Float = EditorGUILayout.FloatField("Value To Save (Float):", myInspector.valueToSet_Float);
			}
			if(myInspector.keyType == 1){ // Int
				myInspector.valueToSet_Int = EditorGUILayout.IntField("Value To Save (Int):", myInspector.valueToSet_Int);
			}
			if(myInspector.keyType == 2){ // String
				myInspector.valueToSet_String = EditorGUILayout.TextField("Value To Save (String):", myInspector.valueToSet_String);
			}
			if(myInspector.keyType == 3){ // Bool
				myInspector.valueToSet_Bool = EditorGUILayout.Toggle("Value To Save (Bool):", myInspector.valueToSet_Bool);
			}
		}
	}
}