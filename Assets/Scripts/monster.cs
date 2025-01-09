using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    public float health;
    public float attack;
    public float charisma;

    [SerializeField]
    GameObject fight_option;
    [SerializeField]
    GameObject leave_option;
    [SerializeField]
    TextMeshProUGUI healthtext;

    StatManager player;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<StatManager>();
        anim = GetComponent<Animator>();
        healthtext.enabled = false;
        fight_option.SetActive(false);
        leave_option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = "" + health;
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        talk();
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
    public void talk()
    {
        fight_option.SetActive(true);
        leave_option.SetActive(true);
    }
    public void Fight()
    {
        healthtext.enabled = true;
        anim.SetBool("fight", true);
        fight_option.SetActive(false);
        leave_option.SetActive(false);
    }
    public void leave()
    {
        fight_option.SetActive(false);
        leave_option.SetActive(false);
    }
    public void Attack()
    {
        player.health -= attack;
    }
    public void hurt()
    {
        health -= player.attack;
    }
}
