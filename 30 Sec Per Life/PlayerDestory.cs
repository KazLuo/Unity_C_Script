using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDestory : MonoBehaviour
{

    public GameObject Gameover;
    public GameObject player;
    public GameObject Restart;

    private int second;

    public ParticleSystem DeadPartical;
    GameManager gameManager;
    


    
    
  
    
   
    // Start is called before the first frame update
    void Start()
    {
        Gameover.SetActive(false);
        Restart.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
       ParticleSystem DeadPartical = GameObject.Find("Dead Partical").GetComponent<ParticleSystem>();
       DeadPartical.Stop();
       
    
    }
        
    

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject.Find("Main Camera").GetComponent<Camerafollow>().enabled = false;
        Gameover.SetActive(true);
        Restart.SetActive(true);
        GameObject.Find("Time").GetComponent<TimerUI>().enabled = false;
        GameObject.Find("BG").GetComponent<Camerafollow>().enabled=false;
        GameObject.Find("Dead Partical").GetComponent<Camerafollow>().enabled=false;
        gameManager.ScoreCount = 0;//死亡後 遊戲管理者內分數規0;
        DeadPartical.Play();
        Instantiate(DeadPartical, player.transform);
        

        


        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sand")
        {
            GameObject.Find("Player").GetComponent<playermovement>().moveSpeed = 1;
        }
        else if(collision.gameObject.tag == "Speed Board")
        {
            GameObject.Find("Player").GetComponent<playermovement>().moveSpeed = 10;
            
        }


        
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Sand")
        {
            GameObject.Find("Player").GetComponent<playermovement>().moveSpeed = 6;
        }
    }
}
