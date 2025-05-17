using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject garageCanvas;

    public static int[] data;
    
    void Awake(){
        TimeManager.Pause();    
    }
    public void Continue(){
        if (File.Exists("data.txt")){
            data=FileManager.ReadData();

            PlayerScript.speed=data[0];
            PlayerScript.fireRate=data[1];
            PlayerScript.fireAttack=data[2];
            PlayerScript.meleeAttack=data[3];
            PlayerScript.health=data[4];
            PlayerScript.coins=data[5];
        }
        garageCanvas.SetActive(true);
    }

    public void NewGame(){
        PlayerScript.speed=50;
        PlayerScript.fireRate=1;
        PlayerScript.fireAttack=10;
        PlayerScript.meleeAttack=20;
        PlayerScript.health=10;
        PlayerScript.coins=0;
        garageCanvas.SetActive(true);
    }

    public void Manuel(){
    }

    public void Quit(){
        Application.Quit();
    }
}
