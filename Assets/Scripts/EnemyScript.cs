using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EnemySpawning
{
    GameObject player;
    [SerializeField]
    Rigidbody2D Erig;

    float Ehealth;

    Vector2 path;

    void Start(){
        player=GameObject.Find("MainChar");
        Ehealth=EhealthMax;
    }

    void FixedUpdate(){
        path=player.transform.position -transform.position;
        path=path/path.magnitude;
        Move();

        // EhealthMax=10+Mathf.Floor(Time.time/13)*5;
        // Espeed=30+Mathf.Floor(Time.time/13)*5;
        // Edamage=10+((int)(Time.time/13))*5;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name=="MainChar"){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
       if (col.tag=="bullet"){
           TakeDamage(PlayerScript.fireAttack);
        }
        else{TakeDamage(PlayerScript.meleeAttack);
            Knockback();}
    }

    void TakeDamage(float damage){
        Ehealth-=damage;
        if(Ehealth<=0){
            Destroy(gameObject);
            PlayerScript.kills++;
        }
    }

    void Move(){
        Erig.AddForce(path*Espeed);
    }

    void Knockback(){
        Erig.AddForce(-path*PlayerScript.knockForce,ForceMode2D.Impulse);
    }

    // void Despawn(){

    // }
}
