using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScript : MonoBehaviour
{

    bool isDead = false;


    GameObject roomTracker;
    StatManager statManager;
    GameObject fadeCanvas;
    GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        roomTracker = FindAnyObjectByType<RoomTracker>().gameObject;
        fadeCanvas = FindAnyObjectByType<FadeScript>().gameObject;
        statManager = FindObjectOfType<StatManager>();
        gameUI = GameObject.FindWithTag("GameUI");
    }

    // Update is called once per frame
    void Update()
    {


        if (statManager.health <= 0)
        {

            isDead = true;
            Destroy(roomTracker);
            print("Destroyed roomtracker");
            Destroy(statManager);
            print("destroyed statmanager");
            Destroy(gameUI);
            print("destroyed gameUI");
            Destroy(fadeCanvas);
            print("destroyed fadecanvas");

            SceneManager.LoadScene("MainMenu");
        }


    }
}
