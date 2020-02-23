using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

	public static SaveManager saveManager;

	void Awake() {
		if(saveManager == null) {
			saveManager = this;
			DontDestroyOnLoad(gameObject);
			Load();
		}
		else if(saveManager != this) {
			Destroy(gameObject);
		}
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + m_SavePath);

		PlayerData data = new PlayerData();
		data.coins = earnedCoins;

		bf.Serialize(file, data);
		file.Close();
	}


	public void Load() {
		if(File.Exists(Application.persistentDataPath + m_SavePath)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + m_SavePath, FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			earnedCoins = data.coins;
		}
		else {
			Debug.Log("Creating new save");
			earnedCoins = 0;
		}
	}

	public int earnedCoins;

	private const string m_SavePath = "/playerInfo.dat";
}

/* Ideally, this would be the perfect place to handle track save and load,
 * but since the preset separated those  in a save file for each track,
 * plus I thought it was better to keep it simple 
 */

[System.Serializable]
class PlayerData
{
	public int coins;
}