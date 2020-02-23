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

			bool leftTouch, rightTouch;
			GetTouchInputs(out leftTouch, out rightTouch);


			if(leftTouch && rightTouch) {
				m_Acceleration = -1f;
			}
			else {
				m_Acceleration = 1f;

				if(leftTouch)
					m_Steering = -1f;
				else if(rightTouch)
					m_Steering = 1f;
				else
					m_Steering = 0f;
			}

			// UNUSED CONTROLS
			//m_HopHeld = Input.GetKey(KeyCode.Space);

			if(m_FixedUpdateHappened) {
				m_FixedUpdateHappened = false;

				// UNUSED CONTROLS
				/*m_HopPressed = false;
				m_BoostPressed = false;
				m_FirePressed = false;*/
			}

			// UNUSED CONTROLS
			/*m_HopPressed |= Input.GetKeyDown(KeyCode.Space);
			m_BoostPressed |= Input.GetKeyDown(KeyCode.RightShift);
			m_FirePressed |= Input.GetKeyDown(KeyCode.RightControl);*/
		}

		void FixedUpdate() {
			m_FixedUpdateHappened = true;
		}

		private void GetTouchInputs(out bool left, out bool right) {
			left = right = false;
			int halfWidth = Screen.width / 2;
			for(int i = 0; i < Input.touchCount; ++i) {
				if(!left && Input.GetTouch(i).position.x < halfWidth)
					left = true;
				else if(!right && Input.GetTouch(i).position.x > halfWidth)
					right = true;
			}
		}
	}
}