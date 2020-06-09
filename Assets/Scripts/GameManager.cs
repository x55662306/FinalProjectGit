using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CasePrefabs;

    private GameObject[] spawners;
    
    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnCase(Case.State.support, "Hamburger", 10, -10);
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
        if (StaticVarible.time < 0)
            SceneManager.LoadScene("Result");
    }

    public void spawnCase(Case.State state, string type, int reward, int toxicity)
    {
        while (true)
        {
            int i = Mathf.RoundToInt(Random.Range(0, spawners.Length));
            Spawner spawner = spawners[i].GetComponent<Spawner>();
            if (!spawner.getFull())
            {
                GameObject mycase = Instantiate(CasePrefabs, spawners[i].transform.position, new Quaternion(0, 0, 0, 0));
                mycase.GetComponent<Case>().SetInfo(state, type, reward, toxicity, spawners[i]);
                spawner.setFull(true);
                break;
            }
        }
    }
}
