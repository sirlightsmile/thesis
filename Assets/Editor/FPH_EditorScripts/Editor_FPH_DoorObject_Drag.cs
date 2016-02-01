using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_DoorObject_Drag))] 
public class Editor_FPH_DoorObject_Drag : Editor {
	
	private string language = "English";
	
	
	public override void OnInspectorGUI() {
		FPH_DoorObject_Drag myInspector = (FPH_DoorObject_Drag) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 65.0f;
		myInspector.doorType = EditorGUILayout.Popup("Door Type:", myInspector.doorType, myInspector.doorTypeArray);

		GUILayout.Space(10.0f); //Put some spece between different elements

		if(myInspector.doorType != 1){
			GUILayout.BeginHorizontal();
			myInspector.factor = EditorGUILayout.FloatField("Rot Speed:", myInspector.factor);
			myInspector.minRot = EditorGUILayout.FloatField("Min Rot:", myInspector.minRot);
			myInspector.maxRot = EditorGUILayout.FloatField("Max Rot:", myInspector.maxRot);
			GUILayout.EndHorizontal();
		}

		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 85.0f;
		myInspector.secToOserve = EditorGUILayout.FloatField("Show text for: ", myInspector.secToOserve);
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 110.0f;

		#region NormallyOpen
		if(myInspector.doorType == 0){
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

				GUILayout.BeginHorizontal();
				if(GUILayout.Button("English", GUILayout.Width(80.0f))){
					language = "English";
				}
				if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
					language = "Italian";
				}
				if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
					language = "Spanish";
				}
				if(GUILayout.Button("German", GUILayout.Width(80.0f))){
					language = "German";
				}
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
				if(GUILayout.Button("French", GUILayout.Width(80.0f))){
					language = "French";
				}
				if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
					language = "Japanese";
				}
				if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
					language = "Chinese";
				}
				if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
					language = "Russian";
				}
				GUILayout.EndHorizontal();
	
	
				if(language == "English"){
					EditorGUILayout.LabelField("Text (English):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_English = EditorGUILayout.TextField(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Italian"){
					EditorGUILayout.LabelField("Text (Italian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Italian = EditorGUILayout.TextField(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Spanish"){
					EditorGUILayout.LabelField("Text (Spanish):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Spanish = EditorGUILayout.TextField(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "German"){
					EditorGUILayout.LabelField("Text (German):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_German = EditorGUILayout.TextField(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "French"){
					EditorGUILayout.LabelField("Text (French):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_French = EditorGUILayout.TextField(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Chinese"){
					EditorGUILayout.LabelField("Text (Chinese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Chinese = EditorGUILayout.TextField(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Japanese"){
					EditorGUILayout.LabelField("Text (Japanese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Japanese = EditorGUILayout.TextField(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Russian"){
					EditorGUILayout.LabelField("Text (Russian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Russian = EditorGUILayout.TextField(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
			}
		}
		
		#endregion

		#region Locked
		if(myInspector.doorType == 1){
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);

			GUILayout.Space(10.0f); //Put some spece between different elements
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("English", GUILayout.Width(80.0f))){
				language = "English";
			}
			if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
				language = "Italian";
			}
			if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
				language = "Spanish";
			}
			if(GUILayout.Button("German", GUILayout.Width(80.0f))){
				language = "German";
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("French", GUILayout.Width(80.0f))){
				language = "French";
			}
			if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
				language = "Japanese";
			}
			if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
				language = "Chinese";
			}
			if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
				language = "Russian";
			}
			GUILayout.EndHorizontal();

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextField(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextField(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextField(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextField(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextField(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextField(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextField(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextField(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
		}
		#endregion
		
		#region EquipObject
		if(myInspector.doorType == 2){
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);

			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.neededObject_Name = EditorGUILayout.TextField("Needed Object Name:", myInspector.neededObject_Name, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
			myInspector.hasBeenUnlockedKey = EditorGUILayout.TextField("Key when unlocked:", myInspector.hasBeenUnlockedKey);
			myInspector.removeItemWhenUsed = EditorGUILayout.Toggle("Remove item after use:", myInspector.removeItemWhenUsed);
			EditorGUIUtility.labelWidth = 100.0f;
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("English", GUILayout.Width(80.0f))){
				language = "English";
			}
			if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
				language = "Italian";
			}
			if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
				language = "Spanish";
			}
			if(GUILayout.Button("German", GUILayout.Width(80.0f))){
				language = "German";
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("French", GUILayout.Width(80.0f))){
				language = "French";
			}
			if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
				language = "Japanese";
			}
			if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
				language = "Chinese";
			}
			if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
				language = "Russian";
			}
			GUILayout.EndHorizontal();

			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextField(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextField(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextField(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextField(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextField(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextField(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextField(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextField(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Wrong Item Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_English = EditorGUILayout.TextField(myInspector.wrongItemMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Wrong Item Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Italian = EditorGUILayout.TextField(myInspector.wrongItemMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Wrong Item Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Spanish = EditorGUILayout.TextField(myInspector.wrongItemMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Wrong Item Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_German = EditorGUILayout.TextField(myInspector.wrongItemMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Wrong Item Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_French = EditorGUILayout.TextField(myInspector.wrongItemMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Wrong Item Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Chinese = EditorGUILayout.TextField(myInspector.wrongItemMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Wrong Item Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Japanese = EditorGUILayout.TextField(myInspector.wrongItemMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Wrong Item Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Russian = EditorGUILayout.TextField(myInspector.wrongItemMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			
			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

				if(language == "English"){
					EditorGUILayout.LabelField("Text (English):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_English = EditorGUILayout.TextField(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Italian"){
					EditorGUILayout.LabelField("Text (Italian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Italian = EditorGUILayout.TextField(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Spanish"){
					EditorGUILayout.LabelField("Text (Spanish):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Spanish = EditorGUILayout.TextField(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "German"){
					EditorGUILayout.LabelField("Text (German):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_German = EditorGUILayout.TextField(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "French"){
					EditorGUILayout.LabelField("Text (French):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_French = EditorGUILayout.TextField(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Chinese"){
					EditorGUILayout.LabelField("Text (Chinese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Chinese = EditorGUILayout.TextField(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Japanese"){
					EditorGUILayout.LabelField("Text (Japanese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Japanese = EditorGUILayout.TextField(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Russian"){
					EditorGUILayout.LabelField("Text (Russian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Russian = EditorGUILayout.TextField(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
			}
		}
		#endregion
		
		#region NeedKey
		if(myInspector.doorType == 3){
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.neededKey = EditorGUILayout.TextField("Needed Bool Key:", myInspector.neededKey, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
			EditorGUIUtility.labelWidth = 100.0f;
			
			GUILayout.Space(10.0f); //Put some spece between different elements

			GUILayout.BeginHorizontal();
			if(GUILayout.Button("English", GUILayout.Width(80.0f))){
				language = "English";
			}
			if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
				language = "Italian";
			}
			if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
				language = "Spanish";
			}
			if(GUILayout.Button("German", GUILayout.Width(80.0f))){
				language = "German";
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("French", GUILayout.Width(80.0f))){
				language = "French";
			}
			if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
				language = "Japanese";
			}
			if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
				language = "Chinese";
			}
			if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
				language = "Russian";
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextField(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextField(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextField(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextField(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextField(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextField(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextField(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextField(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}

			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);

				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

				if(language == "English"){
					EditorGUILayout.LabelField("Text (English):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_English = EditorGUILayout.TextField(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Italian"){
					EditorGUILayout.LabelField("Text (Italian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Italian = EditorGUILayout.TextField(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Spanish"){
					EditorGUILayout.LabelField("Text (Spanish):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Spanish = EditorGUILayout.TextField(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "German"){
					EditorGUILayout.LabelField("Text (German):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_German = EditorGUILayout.TextField(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "French"){
					EditorGUILayout.LabelField("Text (French):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_French = EditorGUILayout.TextField(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Chinese"){
					EditorGUILayout.LabelField("Text (Chinese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Chinese = EditorGUILayout.TextField(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Japanese"){
					EditorGUILayout.LabelField("Text (Japanese):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Japanese = EditorGUILayout.TextField(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
				if(language == "Russian"){
					EditorGUILayout.LabelField("Text (Russian):");
					EditorGUI.indentLevel = 5;
					myInspector.observMessage_Russian = EditorGUILayout.TextField(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
					EditorGUI.indentLevel = 0;
				}
			}
		}
		#endregion

		
		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}