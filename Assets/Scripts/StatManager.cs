using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float attack;
    public float agility;
    public float charisma;
    public int money;

    void Start()
    {
        // Keep statManeger when changing scene
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        {
            
        }
    }
}
