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

    public bool Dodge_QTE_start;
    public bool Attack_QTE_start;

    public Vector2 spawn;
    public Vector2 QTE_spawn;

    [SerializeField]
    GameObject fight_option;
    [SerializeField]
    GameObject leave_option;
    [SerializeField]
    GameObject attack_option;

    [SerializeField]
    GameObject bar;
    [SerializeField]
    GameObject stick;
    [SerializeField]
    GameObject dodge_window;
    [SerializeField]
    GameObject attack_window;

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
        attack_option.SetActive(false);
        bar.SetActive(false);
        attack_window.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        Dodge_QTE_start = false;
        Attack_QTE_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = "" + health;
        if (health<=0)
        {
            Destroy(gameObject);
        }

        if (Dodge_QTE_start == true || Attack_QTE_start == true)
        {
            stick.transform.position += new Vector3(1700, 0, 0) * Time.deltaTime;
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
        fight_option.SetActive(false);
        leave_option.SetActive(false);
        attack_option.SetActive(true);
    }
    public void leave()
    {
        fight_option.SetActive(false);
        leave_option.SetActive(false);
    }
    public void Player_turn()
    {
        attack_option.SetActive(true);
    }
    public void Monster_turn()
    {
        stick.SetActive(true);
        bar.SetActive(true);
        dodge_window.SetActive(true);
        dodge_window.transform.position = new Vector2(Random.Range(530, 1600), 140);
        dodge_window.transform.localScale = new Vector3(5f, 0.74163f, 0);
        stick.transform.position = spawn;
        Dodge_QTE_start = true;
    }

    public void PlayerATK()
    {
        health -= player.attack;
        anim.SetTrigger("PlayerATK");
        bar.SetActive(false);
        attack_window.SetActive(false);
        stick.SetActive(false);
    }
    public void MonsterATK()
    {
        bar.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        player.health -= attack;
        anim.SetTrigger("MonsterATK");
    }

    public void QTE_attacking()
    {
        attack_option.SetActive(false);
        bar.SetActive(true);
        attack_window.SetActive(true);
        attack_window.transform.position = new Vector2(Random.Range(530, 1600), 140);
        stick.SetActive(true);
        stick.transform.position = spawn;
        Attack_QTE_start = true;
    }
    public void QTE_hit()
    {
        bar.SetActive(false);
        attack_window.SetActive(false);
        stick.SetActive(false);
        anim.SetTrigger("PlayerATK");
    }
    public void QTE_dodge()
    {
        bar.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        anim.SetTrigger("MonsterATK");
    }
}