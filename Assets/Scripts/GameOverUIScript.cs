using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIScript : MonoBehaviour
{
	void Awake() {
		m_RetryButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.LoadLevel(); });
		m_MenuButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.LoadMenu(); });
	}

	[Tooltip("Reference to the retry button.")]
	public Button m_RetryButton;

	[Tooltip("Reference to the menu button.")]
	public Button m_MenuButton;
}
