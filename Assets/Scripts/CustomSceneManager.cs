﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
	public static CustomSceneManager sceneManager;

	void Awake() {
		if(sceneManager == null) {
			sceneManager = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(sceneManager != this) {
			Destroy(gameObject);
		}
	}

	public void LoadMenu() {
		SceneManager.LoadScene(MainMenuScene);
	}

	public void LoadLevel() {
		SceneManager.LoadScene(LevelScene);
	}

	public void ExitGame() {
		Application.Quit();
	}

	//[SerializeField]
	private string MainMenuScene = "MainMenuScene";

	//[SerializeField]
	private string LevelScene = "LevelScene";
}
