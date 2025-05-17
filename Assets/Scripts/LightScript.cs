using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    public static float[] heights;
    float scale=5;
    int mapLength=50;
    int mapBreadth=50;
    float seed;
    public Light2D globalLight;
    public static Vector2 mapCenter;

    void HeightMap(){
        for (int i = 0;i<heights.Length;i++)
        {
            int xCoord=i%mapBreadth;
            int yCoord=(int)i/mapBreadth;
            heights[i] = Mathf.PerlinNoise(xCoord/(float)32*scale+seed,yCoord/(float)32*scale+seed);
        }
    }

    void Start(){
        heights=new float[mapBreadth*mapLength];
        // HeightMap();
        // GenerateLight();
        StartCoroutine(LightUpdate());
    }

    public GameObject light;
    [SerializeField]
    float cutoff;

    void GenerateLight(){
        for (int x=0;x<mapBreadth;x++){
            for (int y=0;y<mapLength;y++){
                if (heights[x+y*mapBreadth]>cutoff){
                    Instantiate(light,new Vector2(x+transform.position.x-(mapBreadth/2),y+transform.position.y-(mapBreadth/2)),Quaternion.identity);
                }
            }
        }
    }

    IEnumerator LightUpdate(){
        while (true){
            mapCenter=transform.position;
            seed = Random.Range(0,10000);
            HeightMap();
            for (float i=0f;i<0.7f;i+=0.1f){
                globalLight.GetComponent<Light2D>().intensity+=0.1f;
                if (i==0.5f){
                    GameObject[] Lights=GameObject.FindGameObjectsWithTag("lights");
                    foreach (GameObject light in Lights){
                        Destroy(light);
                    }
                }
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(0.3f);
            GenerateLight();
            for (float i =0f;i<0.7f;i+=0.1f){
                globalLight.GetComponent<Light2D>().intensity-=0.1f;
                // if (i==0.5f){
                    
                // }
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(12f);

        }
    }
}
