using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScript : MonoBehaviour
{
    public static bool paused;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.P)){
            Pause();
        }
    }
    public static void Pause(){
        if (paused){
            Time.timeScale=1;
        }
        else{Time.timeScale=0;}
        paused=!paused;
    }
}
