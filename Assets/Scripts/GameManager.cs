using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawn(Target.State.support);
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

    public void spawn(Target.State state)
    {
        while (true)
        {
            int i = Mathf.RoundToInt(Random.Range(0, spawners.Length));
            Spawner spawner = spawners[i].GetComponent<Spawner>();
            if (!spawner.getFull())
            {
                spawner.spawn(state);
                spawner.setFull(true);
                break;
            }
        }
    }
}
