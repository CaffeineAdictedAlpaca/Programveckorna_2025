using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public float health;
    public float attack;
    public float charisma;

    StatManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void Fight()
    {
        player.health -= attack;
        health -= player.attack;
    }
}
