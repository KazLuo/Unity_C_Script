using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAdd : MonoBehaviour
{
    public GameObject ScoreText;
    GameManager gameManager;
  
    public int ScoreCount = 0;
    public int FinalScore;


    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
 
      
        this.ScoreText = GameObject.Find("Score");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        this.ScoreText.GetComponent<Text>().text ="Score:"+ this.FinalScore.ToString();

      

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreTrigger")
        {
            gameManager.ScoreCount++;
            FinalScore = gameManager.ScoreCount / 2;
        }

        // if (collision.gameObject.tag == "Sand")
        // {
        //     GameObject.Find("Player").GetComponent<playermovement>().moveSpeed = 1;
        // }


        
    }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     if (collision.gameObject.tag == "Sand")
    //     {
    //         GameObject.Find("Player").GetComponent<playermovement>().moveSpeed = 6;
    //     }
    // }

    

    
}
