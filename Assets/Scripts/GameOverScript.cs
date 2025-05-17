using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text gameOverT;

    void Start(){
        gameOverT.text=$"ENEMIES KILLED: {PlayerScript.kills}\nTIME SURVIVED: {(int)PlayerScript.runtime}\nCOINS EARNED: {(int)PlayerScript.kills/5 + (int)PlayerScript.runtime/5}";
    }

    public void MainMenu(){
        TimeManager.Pause();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Application.Quit();
    }
}
