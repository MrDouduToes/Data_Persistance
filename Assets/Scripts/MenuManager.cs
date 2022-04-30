using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string finalName;
    public string bestName;
    public float score;
    public float bestScore;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestName();
        LoadBestScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string finalName;
        public string bestName;
        public float score;
        public float bestScore;

    }

    public void SaveName()
    {
        SaveData nameData = new SaveData();
        nameData.finalName = finalName;

        string json = JsonUtility.ToJson(nameData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void SaveScore()
    {
        SaveData scoreData = new SaveData();
        scoreData.score = score;

        string scoreJson = JsonUtility.ToJson(scoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", scoreJson);
    }

    public void SaveBestName()
    {
        SaveData bestNameData = new SaveData();
        bestNameData.bestName = bestName;

        string nameJson = JsonUtility.ToJson(bestNameData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", nameJson);
    }

    public void SaveBestScore()
    {
        SaveData bestScoreData = new SaveData();
        bestScoreData.bestScore = bestScore;

        string scoreJson = JsonUtility.ToJson(bestScoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", scoreJson);
    }

    public void LoadBestName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("se ha encontrado la ruta del nombre");//kita
            string nameJson = File.ReadAllText(path);
            SaveData nameData = JsonUtility.FromJson<SaveData>(nameJson);
            Debug.Log("se ha encontrado el nombre " + nameData.bestName);//kita
            bestName = nameData.bestName;
        }
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("se ha encontrado la ruta del numero");//kita
            string scoreJson = File.ReadAllText(path);
            SaveData scoreData = JsonUtility.FromJson<SaveData>(scoreJson);
            Debug.Log("se ha encontrado el numero" + scoreData.bestScore);//kita
            bestScore = scoreData.bestScore;
        }
    }

}