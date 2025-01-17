using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDisableUI : MonoBehaviour
{
    GameObject sword;
    GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {

        gameUI = GameObject.FindObjectOfType<UIManager>().gameObject;

        sword = GameObject.FindGameObjectWithTag("Sword").gameObject;


        

    }

    // Update is called once per frame
    void Update()
    {
        gameUI.SetActive(false);

        sword.SetActive(false);
    }
}
