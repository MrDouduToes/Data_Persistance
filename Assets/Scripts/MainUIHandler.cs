using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler: MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI score;
    public TextMeshProUGUI bestPlayerName;

    public void Update()
    {
        playerName.text = MenuManager.Instance.finalName;
        bestPlayerName.text = MenuManager.Instance.bestName + " has the better score with " + $"{MenuManager.Instance.bestScore} points";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
