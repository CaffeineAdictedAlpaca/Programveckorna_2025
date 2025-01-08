using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float health;
    public float attack;
    public float charisma;

    void Start()
    {
        // Keep statManeger when changing scene
        DontDestroyOnLoad(gameObject);
    }
}
