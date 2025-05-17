using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rig;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject meleeRadius;
    public GameObject gameOverMenu;
//upgradables    
    public static int speed=50;
    public static int fireRate=1;
    public static int fireAttack=10;
    public static int meleeAttack=20;
    public static int health=10;
    public static int coins;
    int dashSpeed=50;
    public static int knockForce=50;
    //float lightStrength;
    
    public static int kills;
    public static float runtime; 

    public static Vector2 aim;
    float xMove;
    float yMove;
    int ofset;
    int thishealth;

    void Start()
    {
        kills =0;
        runtime=0;
        thishealth=health;
        int[] array=FileManager.ReadData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            rig.AddForce(aim*dashSpeed,ForceMode2D.Impulse);
        }
        if (!TimeManager.paused){
            if (Input.GetMouseButtonDown(0)){
                Shoot();
            }
            if (Input.GetMouseButtonDown(1)){
                Melee();
        }}
        runtime+=Time.deltaTime;
    }

    void FixedUpdate(){
        rig.AddForce(new Vector2(xMove*speed,yMove*speed));
        Aim();
        xMove=Input.GetAxisRaw("Horizontal");
        yMove=Input.GetAxisRaw("Vertical");
        
    }

    void OnCollisionEnter2D(){
        GetDamage();
    }

    void Aim(){
        aim=Input.mousePosition-new Vector3(Screen.width/2,Screen.height/2,0);      
        aim= aim/aim.magnitude;
        arrow.transform.position=new Vector3(aim.x +transform.position.x,aim.y+transform.position.y,0);
        if (aim.x<0){ofset=180;}
        else{ofset=0;};
        arrow.transform.rotation=Quaternion.Euler(0,0,Mathf.Rad2Deg*Mathf.Atan(aim.y/aim.x)+ofset);
    }

    void Shoot(){
        for (int i=0;i<fireRate;i++){
            Instantiate(bullet,
                new Vector2(aim.x +transform.position.x,aim.y+transform.position.y),
                Quaternion.Euler(0,0,-2f*fireRate+i*4f));
        }
    }

    void Melee(){
        GameObject mr =Instantiate (meleeRadius,
            transform.position,
            Quaternion.Euler(0,0,Mathf.Rad2Deg*Mathf.Atan(aim.y/aim.x)+ofset)); 
        Destroy(mr,0.05f);
    }

    void GetDamage(){
        thishealth-=EnemyScript.Edamage;
        if (thishealth<=0){
            Death();
        }
    }

    void Death(){
        TimeManager.Pause();
        coins+=(int)kills/5 + (int)runtime/5;
        FileManager.WriteData(GetData());
        gameOverMenu.SetActive(true);
    }

    public static int[] GetData(){
        int[] data=new int[6];
        data[0]=speed;
        data[1]=fireRate;
        data[2]=fireAttack;
        data[3]=meleeAttack;
        data[4]=health;
        data[5]=coins;
        return data;
    }

}
