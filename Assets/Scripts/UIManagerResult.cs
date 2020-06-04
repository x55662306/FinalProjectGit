using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerResult : MonoBehaviour
{
    public Text textResult;

    // Start is called before the first frame update
    void Start()
    {
        textResult.text = "分數: " + StaticVarible.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
