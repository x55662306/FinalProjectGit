using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum State
    {
        support,
        recieve
    }

    public GameObject targetTipPrefab;

    private State state;
    private GameObject targetTip;
    private GameObject gameManager;


    // Sart is called before the first frame update
    void Start()
    {
        targetTip = Instantiate(targetTipPrefab);
        targetTip.GetComponent<TargetTip>().setTarget(gameObject);
        targetTip.GetComponent<TargetTip>().setSprite("Hamburger");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && state == State.support)
        {
            gameManager.GetComponent<GameManager>().spawn(State.recieve);
            Destroy(targetTip);
            Destroy(gameObject);
        }
        else if (other.name == "Player" && state == State.recieve)
        {
            StaticVarible.score += 10;
            Destroy(targetTip);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().spawn(State.support);
        }
    }

    public void SetState(State s)
    {
        state = s;
    }
}
