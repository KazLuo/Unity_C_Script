using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershhting : MonoBehaviour
{
    public int damagepershoot = 20;
    public float range  = 200f;
    private Ray shootray;
    private RaycastHit shoothit;
    //設定可以被射擊的Mask
    private int shootableMask;
    private Light gunlight;
    private ParticleSystem gunparticle;
    private AudioSource gunAudio;
    private LineRenderer gunline;
    //每一發的間隔時間
    public float timeBetweenBullet = 0.15f;
    //雷射效果的顯示時間
    private float effectsDisplayTime = 0.2f;
    //計時器
    float timer;


    private void Awake()
    {
        shootableMask = LayerMask.GetMask("enemy");
        gunparticle = GetComponent<ParticleSystem>();
        gunline = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunlight = GetComponent<Light>();

    }
    private void Shoot( )
    {
        timer = 0f;
        gunAudio.Play( );
        gunlight.enabled = true;
        gunparticle.Stop( );
        gunparticle.Play( );
        gunline.enabled = true;
        //0指的是LineRenderer中的Element 0,transposition指的是腳本放在槍口位置
        gunline.SetPosition(0, transform.position);
        shootray.origin = transform.position;
        shootray.direction = transform.forward;//注意這邊不可使用Vector3.forward,Vector3屬世界座標系
                                               //我們是要隨角色轉動的正面，故使用transform

        if (Physics.Raycast(shootray, out shoothit, range, shootableMask))
        {

           EnemyHealth enemyHealth =
            shoothit.collider.GetComponent<EnemyHealth>();
            enemyHealth.takedamage(damagepershoot,shoothit.point);


            gunline.SetPosition(1, shoothit.point);
        }
        else
        {
            gunline.SetPosition(1, shootray.origin + shootray.direction * range);
        }

    }
    void DisableEffects()
    {
        gunlight.enabled = false;
        gunline.enabled = false;


    }
    // Update is called once per frame
    void Update()
    {
        timer +=  Time.deltaTime;
        if(Input.GetButtonDown("Fire1")&& timer >= timeBetweenBullet)
        {
            Shoot();
        }
        if(timer >= timeBetweenBullet * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
}
