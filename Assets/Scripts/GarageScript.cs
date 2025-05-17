using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GarageScript : MonoBehaviour
{
    public Text speedT;
    public Text speedCost;
    public Text fireRateT;
    public Text fireRateCost;
    public Text fireDamageT;
    public Text fireDamageCost;
    public Text meleeDamageT;
    public Text meleeDamageCost;
    public Text healthT;
    public Text healthCost;
    public Text Coins;

    void Update(){
        speedT.text=((PlayerScript.speed-45)/5).ToString();
        fireRateT.text=PlayerScript.fireRate.ToString();
        fireDamageT.text=PlayerScript.fireAttack.ToString();
        meleeDamageT.text=PlayerScript.meleeAttack.ToString();
        healthT.text=PlayerScript.health.ToString();

        if (PlayerScript.speed<75){
            speedCost.text=(((PlayerScript.speed-45)/5)*2).ToString();
        }
        else{speedCost.text="maxed";}
        if (PlayerScript.fireRate<4){
            fireRateCost.text=((PlayerScript.fireRate)*10).ToString();
        }
        else{fireRateCost.text="maxed";}
        if (PlayerScript.fireAttack<40){
            fireDamageCost.text=(((PlayerScript.fireAttack-5)/5)*3).ToString();
            }
        else{fireDamageCost.text="maxed";}
        if (PlayerScript.meleeAttack<50){
            meleeDamageCost.text=(((PlayerScript.meleeAttack-15)/5)*3).ToString();
            }
        else{meleeDamageCost.text="maxed";}
        if (PlayerScript.health<50){
            healthCost.text=(((PlayerScript.health)/10)*3).ToString();
            }
        else{healthCost.text="maxed";}

        Coins.text=$"COINS REMAINING= {PlayerScript.coins}";
    }

    public void speedInc(){
        if(PlayerScript.coins>int.Parse(speedCost.text) && PlayerScript.speed<75){
            PlayerScript.speed+=5;
            PlayerScript.coins-=int.Parse(speedCost.text);
        }
    }

    public void fireRateInc(){
        if (PlayerScript.coins>int.Parse(fireRateCost.text)&& PlayerScript.fireRate<4){
            PlayerScript.fireRate+=1;
            PlayerScript.coins-=int.Parse(fireRateCost.text);
        }
    }

    public void fireDamageInc(){
        if (PlayerScript.coins>int.Parse(fireDamageCost.text) && PlayerScript.fireAttack<40){
            PlayerScript.fireAttack+=5;
            PlayerScript.coins-=int.Parse(fireDamageCost.text);
        }
    }

    public void meleeDamageInc(){
        if (PlayerScript.coins>int.Parse(meleeDamageCost.text) && PlayerScript.meleeAttack<50){
            PlayerScript.meleeAttack+=5;
            PlayerScript.coins-=int.Parse(meleeDamageCost.text);
        }
    }

    public void healthInc(){
        if (PlayerScript.coins>int.Parse(healthCost.text) && PlayerScript.health<50){
            PlayerScript.health+=10;
            PlayerScript.coins-=3;
        }
    }


    public void start(){
        SceneManager.LoadScene("Game");
        FileManager.WriteData(PlayerScript.GetData());
        TimeManager.Pause();
    }

    public void back(){
        gameObject.SetActive(false);
    }
}
