using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static string PlayerName;
    public static string HighScorePlayer = "player";
    public static int HighScore = 0;

    public MenuManager Instance;

    private void Awake() {
        Debug.Log("Awake!");
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        LoadHighScore();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    [System.Serializable]
    class SaveData {
        public string PlayerName;
        public int Score;
    }

    public static void SaveHighScore() {
        SaveData data = new SaveData();
        data.PlayerName = HighScorePlayer;
        data.Score = HighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath +  "/savefile.json", json);
    }

    public void LoadHighScore() {
        string path = Application.persistentDataPath +  "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayer = data.PlayerName;
            HighScore = data.Score;
        }
        Debug.Log(HighScorePlayer + " : " + HighScore);
    }
}
