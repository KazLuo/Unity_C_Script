using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Vector2 movement;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public ScoreAdd powerup;

    // Start is called before the first frame update
    void Update()
    {
       
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        //int Finalscore = powerup.FinalScore;
        //if (Finalscore % 5 == 1 )
        //{
            //moveSpeed += 0.2f;

        //}
    }

    void Start() 
    {
        powerup = GameObject.Find("Player").GetComponent<ScoreAdd>();
    }
}
