using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 100;
    public float time = 100;
    public Text scoreText;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        displayUI();
    }

    void displayUI()
    {
        scoreText.text = score.ToString();
        timeText.text = Mathf.RoundToInt(time).ToString();
    }

    void countDown()
    {
        time -= Time.deltaTime;
    }
}
