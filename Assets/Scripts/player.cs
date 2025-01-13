using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI health;
    [SerializeField]
    TextMeshProUGUI damage;

    StatManager P;
    // Start is called before the first frame update
    void Start()
    {
        P = FindAnyObjectByType<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + P.health;
        damage.text = "ATK: " + P.attack;
    }
}
