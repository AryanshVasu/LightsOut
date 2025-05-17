using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // public Rigidbody2D rigid;
    int bulletSpeed=2;
    public Vector2 dir;

    void Start()
    {
        dir=PlayerScript.aim;
        Destroy(gameObject,1f);
    }

    void FixedUpdate(){
        transform.Translate((Quaternion.Euler(0,0,transform.rotation.z)*dir)/bulletSpeed);
    }
}
