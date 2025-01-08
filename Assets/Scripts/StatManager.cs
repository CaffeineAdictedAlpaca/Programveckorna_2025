using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    float health;
    float attack;
    float charisma;

    void Start()
    {
        // Keep statManeger when changing scene
        DontDestroyOnLoad(gameObject);
    }
}
