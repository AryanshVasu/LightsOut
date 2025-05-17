using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public GameObject floor;
    Vector2 lastChunk;
    int chunkSize=32;

    void Start(){
        lastChunk=GetChunk(transform.position);
        FloorGen();
    }

    void Update(){
        CheckChunk();
    }

    Vector2 GetChunk(Vector3 pos){
        Vector2 chunk=new Vector2(Mathf.Floor((pos.x/chunkSize)), Mathf.Floor((pos.y/chunkSize)));
        return chunk;
    }
    void CheckChunk(){
        Vector2 currentChunk= GetChunk(transform.position);
        if (lastChunk!=currentChunk){
            lastChunk=currentChunk;
            FloorDestroy();
            FloorGen();
        }
    }

    void FloorGen(){
        for (float x=-(1/2f);x<2;x++){
            for (float y=-1/2f;y<2;y++){
                Instantiate(floor,new Vector3((lastChunk.x+x)*chunkSize,(lastChunk.y+y)*chunkSize),Quaternion.identity);
            }
        }
    }

    void FloorDestroy(){
        GameObject[] Floors=GameObject.FindGameObjectsWithTag("floor");
        foreach(GameObject tile in Floors){
            Destroy(tile, 0.1f);
        }
    }
}
