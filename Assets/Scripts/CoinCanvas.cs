using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCanvas : MonoBehaviour
{
	[Tooltip("Reference to the coins text.")]
	public TextMeshProUGUI coinsText;

	private string stringFormatting;

	void Awake()
    {
		stringFormatting = coinsText.text; // Saving a copy before it gets overwritten
		RefreshCoinText(0);
	}

	public void RefreshCoinText(int coinNum) {
		coinsText.text = string.Format(stringFormatting, coinNum);
	}
}
