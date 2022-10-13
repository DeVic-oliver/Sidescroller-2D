using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button StartButton;
    public Button ExitButton;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
