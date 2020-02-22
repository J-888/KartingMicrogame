using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDisplayScript : MonoBehaviour
{
    void Update() {
		if(m_isOn) {    // Not needed, Unity will no longer call the Update() method of a script attached to a deactivated GameObject
			m_timeLeft -= Time.deltaTime;
			if(m_timeLeft <= 0) {
				Hide();
			}
		}
    }

	public void TempDisplay() {
		m_isOn = true;
		m_timeLeft = time;

		gameObject.SetActive(true);
	}

	// Called automatically, the function is public so it can be force hidden
	public void Hide() {
		m_isOn = false;
		m_timeLeft = time;

		gameObject.SetActive(false);
	}

	[Tooltip("How long to display the canvas")]
	public float time;

	private bool m_isOn = false;
	private float m_timeLeft = 2f;
}
