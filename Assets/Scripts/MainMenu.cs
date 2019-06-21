using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int _sceneNumber;

    public void Buttom1()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void ButtomQuit()
    {
        Application.Quit();
    }
}
