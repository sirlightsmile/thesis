﻿using UnityEngine;
using System.Collections;

public class ScreenFadeOut : MonoBehaviour {

	/// <summary>
	/// How long it takes to fade.
	/// </summary>
	public float fadeTime = 2.0f;
	
	/// <summary>
	/// The initial screen color.
	/// </summary>
	public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);
	
	private Material fadeMaterial = null;
	private bool isFading = false;
	
	/// <summary>
	/// Initialize.
	/// </summary>
	void Awake()
	{
		// create the fade material
		fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
	}
	
	/// <summary>
	/// Starts the fade in
	/// </summary>
	void OnEnable()
	{
		StartCoroutine(FadeIn());
	}
	
	/// <summary>
	/// Starts a fade in when a new level is loaded
	/// </summary>
	void OnLevelWasLoaded(int level)
	{
		StartCoroutine(FadeIn());
	}
	
	/// <summary>
	/// Cleans up the fade material
	/// </summary>
	void OnDestroy()
	{
		if (fadeMaterial != null)
		{
			Destroy(fadeMaterial);
		}
	}
	
	/// <summary>
	/// Fades alpha from 1.0 to 0.0
	/// </summary>
	IEnumerator FadeIn()
	{
		float elapsedTime = 0.0f;
		//fadeMaterial.color = fadeColor;
		Color color = fadeColor;
		color.a = 0.0f;
		fadeMaterial.color = color;
		isFading = true;
		while (elapsedTime < fadeTime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			color.a = 0.0f + Mathf.Clamp01(elapsedTime / fadeTime);
			fadeMaterial.color = color;
		}
		isFading = false;
	}
	
	/// <summary>
	/// Renders the fade overlay when attached to a camera object
	/// </summary>
	void OnPostRender()
	{
		if (isFading)
		{
			fadeMaterial.SetPass(0);
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Color(fadeMaterial.color);
			GL.Begin(GL.QUADS);
			GL.Vertex3(0f, 0f, -12f);
			GL.Vertex3(0f, 1f, -12f);
			GL.Vertex3(1f, 1f, -12f);
			GL.Vertex3(1f, 0f, -12f);
			GL.End();
			GL.PopMatrix();
		}
	}
}
