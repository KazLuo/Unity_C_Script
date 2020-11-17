using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;
    private static int currentHealth;
    public int startHealth = 100;
    public AudioClip deathClip;         //AudioClip用於處理音效方面
    public Image damageImage;     //Image為UI內造成傷害時的閃爍
    public float flashspeed;  //閃爍的速度
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);  //閃爍顏色
    private bool damaged = false;  //判定傷害
    private AudioSource PlayerAudio;

    private bool isDeath;
    private Animator playerAnimator;

    public delegate void PlayerDamageAction();
    public static event PlayerDamageAction PlayerDeathEvent;


    private void Awake()
    {
        healthSlider.maxValue = startHealth;

        if (currentHealth >= 0)
        {
            healthSlider.value = startHealth;
            currentHealth = startHealth;
        }
        else
        {
            healthSlider.value = startHealth;
        }
        PlayerAudio = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();

    }

    private void Death()
    {
        isDeath = true;
        PlayerAudio.clip = deathClip;
        PlayerAudio.Play();
        playerAnimator.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false ;
        GetComponentInChildren<playershhting>().enabled = false;
        if(PlayerDeathEvent != null)
        {
            PlayerDeathEvent();
        }
    }
    public void takedamage(int amount)
    {
        if (isDeath) return;
        PlayerAudio.Play();
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Update()
    {
        if (damaged)
        {
            damaged = false;
            damageImage.color = flashColor;

        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, Time.deltaTime);
        }
    }

}
