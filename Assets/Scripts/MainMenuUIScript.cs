using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIScript : MonoBehaviour
{
	void Awake() {
		m_PlayButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.LoadLevel(); });
		m_ExitButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.ExitGame(); });
	}

	[SerializeField]
	private Button m_PlayButton;

	[SerializeField]
	private Button m_ExitButton;
}
