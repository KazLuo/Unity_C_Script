using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    public int StartHealth = 100;
    private int currentHealth;
    public int score = 0;
    private Animator anim;
    private bool isDead;
    private bool isSinking;
    public AudioClip deadClip;
    private AudioSource enemyAudio;
    private ParticleSystem hitparticals;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = StartHealth;
        enemyAudio = GetComponent<AudioSource>();
        hitparticals = GetComponentInChildren<ParticleSystem>();

     }

    private void Death()
    {
        isDead = true;
        anim.SetTrigger("isdead");
        enemyAudio.clip = deadClip;
        enemyAudio.Play();
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<enemyattack>().enabled = false;
        GetComponent<enemymovement>().enabled = false;
        ScoreManeger.Score += score;
    }
    public void takedamage(int damage,Vector3 potion)
    {
        if (isDead) return;
        currentHealth -= damage;
        enemyAudio.Play();
        hitparticals.transform.position = potion;
        hitparticals.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }
    void Start()
    {
        
    }
    public void StartSinking()
    {
        isSinking = true;
        Destroy(gameObject,2f);
    }
    // Update is called once per frame
    void Update()
    {
      if(this.isSinking)
        {
            transform.Translate(Vector3.down * Time.deltaTime);

        }
    }
}
