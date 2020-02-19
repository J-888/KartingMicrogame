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

	[SerializeField]
	private Button m_RetryButton;

	[SerializeField]
	private Button m_MenuButton;
}
