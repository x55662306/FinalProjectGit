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
    private int id;
    private string caseType;
    private int reward;
    private int toxicity;
    


    // Sart is called before the first frame update
    void Start()
    {
        targetTip = Instantiate(targetTipPrefab);
        targetTip.GetComponent<CaseTip>().setTarget(gameObject);
        targetTip.GetComponent<CaseTip>().setSprite(caseType);
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
            gameManager.GetComponent<GameManager>().spawnCase(State.recieve, id);
            spawner.GetComponent<Spawner>().setFull(false);
            Destroy(targetTip);
            Destroy(gameObject);
        }
        else if (other.name == "Player" && state == State.recieve)
        {
            StaticVarible.score += reward;
            player.GetComponent<Player>().AddHealth(toxicity);
            Destroy(targetTip);
            gameManager.GetComponent<GameManager>().spawnCase(State.support, id);
            spawner.GetComponent<Spawner>().setFull(false);
            Destroy(gameObject);
        }
    }

    public void SetState(State state)
    {
        this.state = state;
    }

    public void SetInfo(State state, int id, GameObject spawner)
    {
        this.state = state;
        this.id = CaseinfoLoader.caseInfoList[id].id;
        this.caseType = CaseinfoLoader.caseInfoList[id].caseType;
        this.reward = CaseinfoLoader.caseInfoList[id].reward;
        this.toxicity = CaseinfoLoader.caseInfoList[id].toxicity;
        this.spawner = spawner;
    }
}
