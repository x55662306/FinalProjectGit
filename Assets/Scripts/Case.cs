using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
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
    private GameObject player;
    private GameObject spawner;
    private string type;
    private int reward;
    private int toxicity;


    // Sart is called before the first frame update
    void Start()
    {
        targetTip = Instantiate(targetTipPrefab);
        targetTip.GetComponent<CaseTip>().setTarget(gameObject);
        targetTip.GetComponent<CaseTip>().setSprite(type);
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && state == State.support)
        {
            gameManager.GetComponent<GameManager>().spawnCase(State.recieve, type, reward, toxicity);
            spawner.GetComponent<Spawner>().setFull(false);
            Destroy(targetTip);
            Destroy(gameObject);
        }
        else if (other.name == "Player" && state == State.recieve)
        {
            StaticVarible.score += reward;
            player.GetComponent<Player>().AddHealth(toxicity);
            Destroy(targetTip);
            gameManager.GetComponent<GameManager>().spawnCase(State.support, type, reward, toxicity);
            spawner.GetComponent<Spawner>().setFull(false);
            Destroy(gameObject);
        }
    }

    public void SetState(State state)
    {
        this.state = state;
    }

    public void SetInfo(State state, string type, int reward, int toxicity, GameObject spawner)
    {
        this.state = state;
        this.type = type;
        this.reward = reward;
        this.toxicity = toxicity;
        this.spawner = spawner;
    }
}
