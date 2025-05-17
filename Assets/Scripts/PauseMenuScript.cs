using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void Continue(){
        gameObject.SetActive(false);
        TimeManager.Pause();
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Application.Quit();
    }
}
