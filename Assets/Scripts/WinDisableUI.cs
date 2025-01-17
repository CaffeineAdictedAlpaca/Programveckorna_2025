using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDisableUI : MonoBehaviour
{

    GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {

        gameUI = GameObject.FindWithTag("GameUI").gameObject;


        

    }

    // Update is called once per frame
    void Update()
    {
        gameUI.SetActive(false);
    }
}
