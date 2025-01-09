using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monster : MonoBehaviour
{
    public float health;
    public float attack;
    public float charisma;

    [SerializeField]
    TextMeshProUGUI fight_option;
    [SerializeField]
    TextMeshProUGUI leave_option;
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
        fight_option.enabled = false;
        leave_option.enabled = false;
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
        Fight();
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
    public void Fight()
    {
        healthtext.enabled = true;
        anim.SetBool("fight",true);
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
