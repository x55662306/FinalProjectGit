using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerTitle : MonoBehaviour
{
    public Button startBt;
    public Dropdown diffDropdown;

    // Start is called before the first frame update
    void Start()
    {
        startBt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
        diffDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(diffDropdown);
        });
        StaticVarible.diffculty = diffDropdown.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropdownValueChanged(Dropdown change)
    {
        StaticVarible.diffculty = change.value;
    }
}
