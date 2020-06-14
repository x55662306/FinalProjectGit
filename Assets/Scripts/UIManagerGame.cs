using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerGame: MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text healthText;

    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        displayUI();
    }

    void displayUI()
    {
        scoreText.text = StaticVarible.score.ToString();
        timeText.text = Mathf.RoundToInt(StaticVarible.time).ToString();
        healthText.text = playerScript.GetHealth().ToString();
    }


}
