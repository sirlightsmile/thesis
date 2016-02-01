﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_ShowTextFile_GUI))] 
public class Editor_FPH_ShowTextFile_GUI : Editor {

	private string language = "English";
	private Vector2 englishScroll;

	public override void OnInspectorGUI(){
		FPH_ShowTextFile_GUI myInspector = (FPH_ShowTextFile_GUI) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 50.0f;
		myInspector.showTextGuiSkin = (GUISkin) EditorGUILayout.ObjectField("GUI Skin:", myInspector.showTextGuiSkin, typeof(GUISkin), false);
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal(GUILayout.MinWidth(60.0f));
			if(GUILayout.Button("English", GUILayout.Width(80.0f))){
				language = "English";
			}
			if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
				language = "Italian";
			}
			if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
				language = "Spanish";
			}
			if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
				language = "Russian";
			}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(GUILayout.MinWidth(60.0f));
			if(GUILayout.Button("German", GUILayout.Width(80.0f))){
				language = "German";
			}
			if(GUILayout.Button("French", GUILayout.Width(80.0f))){
				language = "French";
			}
			if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
				language = "Chinese";
			}
			if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
				language = "Japanese";
			}
		GUILayout.EndHorizontal();

		GUILayout.Space(10.0f); //Put some spece between different elements

		
		if(language == "English"){
			EditorGUILayout.LabelField("Text (English):");
			EditorGUI.indentLevel = 5;
			myInspector.englishTextFile = EditorGUILayout.TextField(myInspector.englishTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Italian"){
			EditorGUILayout.LabelField("Text (Italian):");
			EditorGUI.indentLevel = 5;
			myInspector.italianTextFile = EditorGUILayout.TextField(myInspector.italianTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Spanish"){
			EditorGUILayout.LabelField("Text (Spanish):");
			EditorGUI.indentLevel = 5;
			myInspector.spanishTextFile = EditorGUILayout.TextField(myInspector.spanishTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "German"){
			EditorGUILayout.LabelField("Text (German):");
			EditorGUI.indentLevel = 5;
			myInspector.germanTextFile = EditorGUILayout.TextField(myInspector.germanTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "French"){
			EditorGUILayout.LabelField("Text (French):");
			EditorGUI.indentLevel = 5;
			myInspector.frenchTextFile = EditorGUILayout.TextField(myInspector.frenchTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Chinese"){
			EditorGUILayout.LabelField("Text (Chinese):");
			EditorGUI.indentLevel = 5;
			myInspector.chineseTextFile = EditorGUILayout.TextField(myInspector.chineseTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Japanese"){
			EditorGUILayout.LabelField("Text (Japanese):");
			EditorGUI.indentLevel = 5;
			myInspector.japaneseTextFile = EditorGUILayout.TextField(myInspector.japaneseTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Russian"){
			EditorGUILayout.LabelField("Text (Russian):");
			EditorGUI.indentLevel = 5;
			myInspector.russianTextFile = EditorGUILayout.TextField(myInspector.russianTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
	}
}
