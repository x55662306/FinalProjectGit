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

    public Animator anim;
    private State state;
    private GameObject targetTip;
    private GameObject gameManager;
    private GameObject player;
    private GameObject spawner;
    public GameObject targetTipPrefab;
    private Player playerScript;
    private string caseType;
    private int id;
    private int reward;
    private int toxicity;
    public int action = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("action", action);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Over"))
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && state == State.support && spawner.GetComponent<Spawner>().getFull())
        {
            gameManager.GetComponent<GameManager>().spawnSpecificCase(State.recieve, id);
            spawner.GetComponent<Spawner>().setFull(false);
            Destroy(targetTip);
            action = 2;
            playerScript.SetAction(2);
        }
        else if (other.name == "Player" && state == State.recieve && spawner.GetComponent<Spawner>().getFull())
        {
            StaticVarible.time += 15;
            StaticVarible.score += reward;
            player.GetComponent<Player>().AddHealth(toxicity*StaticVarible.diffculty);
            Destroy(targetTip);
            gameManager.GetComponent<GameManager>().spawnRandomCase(State.support);
            spawner.GetComponent<Spawner>().setFull(false);
            action = 1;
            playerScript.SetAction(3);
        }
    }

    public void SetState(State state)
    {
        this.state = state;
    }

    public State getState()
    {
        return state;
    }

    public void SetInfo(State state, int id, GameObject spawner)
    {
        this.state = state;
        this.id = id;
        this.caseType = CaseinfoLoader.caseInfoList[id].caseType;
        this.reward = CaseinfoLoader.caseInfoList[id].reward;
        this.toxicity = CaseinfoLoader.caseInfoList[id].toxicity;
        this.spawner = spawner;
        CreateTip();
    }

    private void CreateTip()
    {
        targetTip = Instantiate(targetTipPrefab);
        targetTip.GetComponent<CaseTip>().setTarget(gameObject);
        targetTip.GetComponent<CaseTip>().setSprite(caseType);
    }
}
