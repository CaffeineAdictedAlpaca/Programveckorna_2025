using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smol_monster : MonoBehaviour
{
    public GameObject dialogue;
    monster monster;

    public bool talking;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
        monster = FindAnyObjectByType<monster>();
        talking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnObjectClicked()
    {
        dialogue.SetActive(true);
        talking = true;
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
}
