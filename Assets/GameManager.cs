using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Button startButton;
    public Button exitButton;
    public Button creditButton;


    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Donjon");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditScene");
    }
}
