using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI health;

    StatManager P;
    // Start is called before the first frame update
    void Start()
    {
        P = FindAnyObjectByType<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "" + P.health;
    }
}
