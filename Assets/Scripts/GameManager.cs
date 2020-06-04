using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        gameOverCheck();
    }
    void countDown()
    {
        StaticVarible.time -= Time.deltaTime;
    }

    void gameOverCheck()
    {
        if(StaticVarible.time < 0)
            SceneManager.LoadScene("Result");
    }
}
