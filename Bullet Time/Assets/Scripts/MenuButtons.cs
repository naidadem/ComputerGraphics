using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void Play()
    {
        SceneManager.LoadScene("lvl", LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
