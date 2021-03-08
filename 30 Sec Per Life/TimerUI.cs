using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    public GameObject Timetext;
    float time = 30f;
    public GameObject Gameover;
    public GameObject Player;

    public playermovement playermove;

    // Start is called before the first frame update
    void Start()
    {
        Gameover.SetActive(false);

        this.Timetext = GameObject.Find("Time");

        this.Player= GameObject.Find("Player");
    }

    
    // Update is called once per frame
    void Update()
    {

        if (time > 0)
        {
            this.time -= Time.deltaTime;

            this.Timetext.GetComponent<Text>().text = "Time:" + this.time.ToString("F1");
            


        } else
        {
            Gameover.SetActive(true);

            Player.SetActive(false);
            
            

        }
        

    }
}
