using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CasePrefabs;

    private GameObject[] spawners;
    private Player playerScript;
    private int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        setTargetScore();
        int i = Mathf.RoundToInt(Random.Range(0, CaseinfoLoader.caseInfoList.Count));
        spawnCase(Case.State.support, i);
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
        if (StaticVarible.time < 0 || playerScript.GetHealth() < 0)
            SceneManager.LoadScene("Result");
        else if (StaticVarible.score >= targetScore)
        {
            StaticVarible.victory = true;
            SceneManager.LoadScene("Result");
        }
    }

    private void setTargetScore()
    {
        switch (StaticVarible.diffculty)
        {
            case 0:
                targetScore = 100;
                break;
            case 1:
                targetScore = 200;
                break;
            case 2:
                targetScore = 300;
                break;
        }
    }

    public int getTartgetScore()
    {
        return targetScore;
    }

    public void spawnCase(Case.State state, int id)
    {
        while (true)
        {
            int i = Mathf.RoundToInt(Random.Range(0, spawners.Length));
            Spawner spawner = spawners[i].GetComponent<Spawner>();
            if (!spawner.getFull())
            {
                GameObject mycase = Instantiate(CasePrefabs, spawners[i].transform.position, new Quaternion(0, 0, 0, 0));
                mycase.GetComponent<Case>().SetInfo(state, id, spawners[i]);
                spawner.setFull(true);
                break;
            }
        }
    }
}
