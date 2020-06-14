using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerResult : MonoBehaviour
{
    public Text textResult;
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        textResult.text = StaticVarible.score.ToString();
        SetImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetImage()
    {
        if (StaticVarible.victory)
            rawImage.texture = Resources.Load<Texture>("Sprites/Victory");
        else
            rawImage.texture = Resources.Load<Texture>("Sprites/Fail");
    }
}
