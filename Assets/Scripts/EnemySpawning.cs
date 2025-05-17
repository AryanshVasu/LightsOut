using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemy;

    float b=0.05f;
    float a;
    int mapLength=50;
    int mapBreadth=50;

    public static float EhealthMax;
    public static float Espeed;
    public static int Edamage;

    void Start(){
        StartCoroutine(SpawnUpdate());
        EhealthMax=10;
        Espeed=30;
        Edamage=10;
    }

    void Update(){
            Edamage=10+((int)(PlayerScript.runtime/5))*5;
            EhealthMax=10+((int)(PlayerScript.runtime/5))*5;
            Espeed=30+((int)(PlayerScript.runtime/5))*5;
    }
    void Spawn(){
        for (int x=0;x<mapBreadth;x+=5){
            for (int y=0;y<mapLength;y+=5){
                if (GetProbablity(LightScript.heights[x+y*mapBreadth])>Random.Range(0,100)){
                    Instantiate(enemy,
                        new Vector2(x+LightScript.mapCenter.x-(mapBreadth/2),y+LightScript.mapCenter.y-(mapBreadth/2)),
                        Quaternion.identity);
                }
            }
        }
    }

    int GetProbablity(float x){
        a=(1-Mathf.Pow(1+4*b,0.5f))/2f;
        return (int)(((b/(x-a))+a)*100);
    }

    IEnumerator SpawnUpdate(){
        while (true){
            yield return new WaitForSeconds(1f);
            for (int i =0;i<6;i++){
                Spawn();
                yield return new WaitForSeconds(2f);
            }
            b+=0.01f;
        }
    }
}
