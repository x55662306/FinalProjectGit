using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject tartgetPrefabs;

    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        full = false;
    }

    public bool getFull()
    {
        return full;
    }

    public void setFull(bool b)
    {
        full = b;
    }

    public void spawn(Target.State state)
    {
        GameObject target = Instantiate(tartgetPrefabs, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        target.GetComponent<Target>().SetState(state);
    }
}
