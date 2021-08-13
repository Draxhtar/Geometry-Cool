using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Level that will be loaded when pressed NEXT LEVEL.")]
    private string nextLevel;

    [SerializeField] private string mainMenu;
    [SerializeField] private string currentScene;
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(currentScene);
    }
}
