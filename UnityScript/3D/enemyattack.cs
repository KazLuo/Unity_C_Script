using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyattack : MonoBehaviour
{
    public int attackdamage = 15;
    private bool playerInRange;
    private HealthUI playerHealth;
    private float timer;
    private float timeBetweenattack = 1f;

    private Animator enemyAnimator;
    private bool playerIsDeath;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthUI>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void playerDeathAction()
    {
        playerIsDeath = true;
        enemyAnimator.SetTrigger("playerdead");
        GetComponent<enemymovement>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

    }
    private void OnEnable()
    {
        HealthUI.PlayerDeathEvent += playerDeathAction;
    }
    private void OnDisable()
    {
        HealthUI.PlayerDeathEvent -= playerDeathAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerHealth.tag)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerHealth.tag)
        {
            playerInRange = false;
        }
    }
    private void Attack()
    {
        timer = 0;
        playerHealth.takedamage(attackdamage);

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (playerInRange && playerIsDeath == false)
        {
            if(timer >= timeBetweenattack)
            {
                Attack();
            }


        }
    }
}
