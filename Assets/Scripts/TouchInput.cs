using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
	/// <summary>
	/// A basic touch implementation of the IInput interface for all the input information a kart needs.
	/// </summary>
	public class TouchInput : MonoBehaviour, IInput
	{
		public float Acceleration {
			get { return m_Acceleration; }
		}
		public float Steering {
			get { return m_Steering; }
		}
		public bool BoostPressed {
			get { return m_BoostPressed; }
		}
		public bool FirePressed {
			get { return m_FirePressed; }
		}
		public bool HopPressed {
			get { return m_HopPressed; }
		}
		public bool HopHeld {
			get { return m_HopHeld; }
		}

		float m_Acceleration;
		float m_Steering;
		bool m_HopPressed;
		bool m_HopHeld;
		bool m_BoostPressed;
		bool m_FirePressed;

		bool m_FixedUpdateHappened;

		void Update() {

			bool leftTouch, rightTouch, doubletapHeld, doubletapBegan;
			float doubletapAxis;
			GetTouchInputs(out leftTouch, out rightTouch, out doubletapHeld, out doubletapBegan, out doubletapAxis);

			if(doubletapHeld) {	// hop
				m_Acceleration = 1f;
				m_Steering = doubletapAxis;
			}
			else if(leftTouch && rightTouch) {	// reverse
				m_Acceleration = -1f;
			}
			else {	// normal
				m_Acceleration = 1f;

				if(leftTouch)
					m_Steering = -1f;
				else if(rightTouch)
					m_Steering = 1f;
				else
					m_Steering = 0f;
			}

			m_HopHeld = doubletapHeld;

			if(m_FixedUpdateHappened) {
				m_FixedUpdateHappened = false;
				m_HopPressed = false;

				// UNUSED CONTROLS
				/*m_BoostPressed = false;
				m_FirePressed = false;*/
			}

			m_HopPressed |= doubletapBegan;

			// UNUSED CONTROLS
			/*m_BoostPressed |= Input.GetKeyDown(KeyCode.RightShift);
			m_FirePressed |= Input.GetKeyDown(KeyCode.RightControl);*/
		}

		void FixedUpdate() {
			m_FixedUpdateHappened = true;
		}

		private void GetTouchInputs(out bool left, out bool right, out bool doubletapHeld, out bool doubletapBegan, out float doubletapAxis) {
			left = right = doubletapHeld = doubletapBegan = false;
			doubletapAxis = 0f;
			int halfWidth = Screen.width / 2;

			for(int i = 0; i < Input.touchCount; ++i) {
				if(Input.GetTouch(i).tapCount == 2) {   // doubletap
					doubletapHeld = true;
					doubletapBegan = Input.GetTouch(i).phase == TouchPhase.Began;
					left = right = false;
					doubletapAxis = (2f * (Input.GetTouch(i).position.x / Screen.width)) - 1f;  // Touch screen X position from -1f to 1f
					return;
				}
				else if(!left && Input.GetTouch(i).position.x < halfWidth)
					left = true;
				else if(!right && Input.GetTouch(i).position.x > halfWidth)
					right = true;
			}
		}
	}
}