using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerTitle : MonoBehaviour
{
    public Button startBt;

    // Start is called before the first frame update
    void Start()
    {
        startBt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
