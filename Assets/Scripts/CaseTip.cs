using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseTip : MonoBehaviour
{
    private GameObject target;
    private GameObject player;
    private float minimapRadius = 14.0f;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 vec = target.transform.position - player.transform.position;
            float dist = vec.magnitude;
            transform.rotation = Quaternion.Euler(90, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
            if (dist < minimapRadius)
                this.transform.position = target.transform.position;
            else
                this.transform.position = player.transform.position + vec.normalized * minimapRadius;
        }
    }
    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void setSprite(string type)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + type);
    }
}
