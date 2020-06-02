using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetTipPrefab;

    private GameObject targetTip;

    // Start is called before the first frame update
    void Start()
    {
        targetTip = Instantiate(targetTipPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            UIManagerGame.score += 10;
            Destroy(targetTip);
            Destroy(gameObject);
        }
    }
}
