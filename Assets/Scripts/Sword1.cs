using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : MonoBehaviour
{

    StatManager statManager;
    // Start is called before the first frame update
    void Start()
    {
        statManager = GameObject.FindAnyObjectByType<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
