using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public static int Score;
    private Text ScoreText;

    // Start is called before the first frame update
    private void Awake()
    {
        ScoreText = GetComponent<Text>();
    }
   

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + Score;
    }
}
