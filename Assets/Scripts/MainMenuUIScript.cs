using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KartGame.Track;

public class MainMenuUIScript : MonoBehaviour
{
	void Awake() {
		m_PlayButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.LoadLevel(); });
		m_ExitButton.onClick.AddListener(delegate { CustomSceneManager.sceneManager.ExitGame(); });

		DisplayRecord();
	}

	void DisplayRecord() {
		TrackRecord tr = TrackRecord.Load(trackName, 1);
		if(tr != null && tr.time < float.PositiveInfinity) {
			m_RecordText.gameObject.SetActive(true);
			m_RecordText.text = string.Format(m_RecordText.text, tr.time);
		}
		else {
			m_RecordText.gameObject.SetActive(false);
		}
	}

	[SerializeField]
	private Button m_PlayButton;

	[SerializeField]
	private Button m_ExitButton;

	[SerializeField]
	private Text m_RecordText;

	private string trackName = "ArtTest";
}
