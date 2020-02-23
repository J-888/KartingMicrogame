using KartGame.Track;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float rotateSpeed = 25f;

	private TrackManager trackManager;

	private void Awake() {
		trackManager = FindObjectOfType<TrackManager>();
	}

	void Update() {
		gameObject.transform.Rotate(new Vector3(0f, 0f, 1f), rotateSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player"){
			gameObject.SetActive(false);

			if(trackManager)
				trackManager.PickUpCoin();
		}
	}
}
