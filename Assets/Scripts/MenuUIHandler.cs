using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public string nameFilter;
    public bool canRunGame = false;


    public void FilterName()
    {
        nameFilter = playerName.text;
        MenuManager.Instance.finalName = nameFilter;
        Debug.Log("El nombre k se a introdusio e " + nameFilter); //kitar
        canRunGame = true;
        Debug.Log("Ya podes juga boludo");
    }



    public void StartNew()
    {
        if (canRunGame == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Pone un nombre cabesa cacahuete");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public static void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif


    }
}