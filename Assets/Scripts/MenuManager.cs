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
        public string bestNameJson;
        public float bestScoreJson;

    }

    public void SaveBestName()
    {
        SaveData j_name = new SaveData();

        j_name.bestNameJson = bestName;

        string nameJson = JsonUtility.ToJson(j_name);

        File.WriteAllText(Application.persistentDataPath + "/planeName.json", nameJson);
    }

    public void SaveBestScore()
    {
        SaveData j_score = new SaveData();

        j_score.bestScoreJson = bestScore;

        string scoreJson = JsonUtility.ToJson(j_score);

        File.WriteAllText(Application.persistentDataPath + "/planeScore.json", scoreJson);
    }

    public void LoadBestName()
    {
        string path = Application.persistentDataPath + "/planeName.json";
        if (File.Exists(path))
        {
            Debug.Log("se ha encontrado la ruta del nombre");//kita
            string j_name = File.ReadAllText(path);
            SaveData nameData = JsonUtility.FromJson<SaveData>(j_name);
            Debug.Log("se ha encontrado el nombre " + nameData.bestNameJson);//kita
            bestName = nameData.bestNameJson;
        }
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/planeScore.json";
        if (File.Exists(path))
        {
            Debug.Log("se ha encontrado la ruta del numero");//kita
            string j_score = File.ReadAllText(path);
            SaveData scoreData = JsonUtility.FromJson<SaveData>(j_score);
            Debug.Log("se ha encontrado el numero" + scoreData.bestScoreJson);//kita
            bestScore = scoreData.bestScoreJson;
        }
    }

}