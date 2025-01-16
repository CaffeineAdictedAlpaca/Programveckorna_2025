using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public float attack;
    public float charisma;

    public float timer;
    public bool start_timer;

    public bool Dodge_QTE_start;
    public bool Attack_QTE_start;
    public bool QTE_miss;
    public bool damage;

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
    GameObject healthtext;

    StatManager player;
    smol_monster smol;
    swing swing;
    public Image player_screen;

    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        swing = FindAnyObjectByType<swing>();
        smol = FindAnyObjectByType<smol_monster>();
        player = FindAnyObjectByType<StatManager>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        healthtext.SetActive(false);
        fight_option.SetActive(false);
        leave_option.SetActive(false);
        attack_option.SetActive(false);
        bar.SetActive(false);
        attack_window.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        Dodge_QTE_start = false;
        Attack_QTE_start = false;
        QTE_miss = false;
        start_timer = false;
        timer = 1.5f;
        damage = false;
        player_screen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (smol.talking == true)
        {
            talk();
            smol.talking = false;
        }
        if (health<=0)
        {
            FindAnyObjectByType<CameraScript>().enabled = true;
            Destroy(gameObject);
        }

        if (Dodge_QTE_start == true || Attack_QTE_start == true)
        {
            stick.transform.position += new Vector3(1700, 0, 0) * Time.deltaTime;
            if (stick.transform.position.x >= 1700)
            {
                QTE_miss = true;
            }
        }
        if (start_timer == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            QTE_dodging();
        }
    }
    // Function to call when the object is clicked
    public void talk()
    {
        print("talk");
        FindAnyObjectByType<CameraScript>().enabled = false;
        fight_option.SetActive(true);
        leave_option.SetActive(true);
    }
    public void Fight()
    {
        healthtext.SetActive(true);
        fight_option.SetActive(false);
        leave_option.SetActive(false);
        attack_option.SetActive(true);
    }
    public void leave()
    {
        FindAnyObjectByType<CameraScript>().enabled = true;
        fight_option.SetActive(false);
        leave_option.SetActive(false);
        gameObject.SetActive(false);
    }
    public void Player_turn()
    {
        attack_option.SetActive(true);
        damage = false;
        player_screen.enabled = false;
    }
    public void Monster_turn()
    {
        start_timer = true;
        damage = false;
        player_screen.enabled = false;
    }


    public void PlayerATK()
    {
        health -= player.attack;
        anim.SetTrigger("PlayerATK");
        damage = true;
        swing.anim();
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
        damage = true;
        print("ajaj");
    }
    public void QTE_dodging()
    {
        timer = 1.5f;
        print("start");
        start_timer = false;
        stick.SetActive(true);
        bar.SetActive(true);
        dodge_window.SetActive(true);
        dodge_window.transform.position = new Vector2(Random.Range(700, 1600), 140);
        dodge_window.transform.localScale = new Vector3(player.agility * 0.006f, 0.74163f, 0);
        stick.transform.position = spawn;
        Dodge_QTE_start = true;
    }

    public void QTE_attacking()
    {
        attack_option.SetActive(false);
        bar.SetActive(true);
        attack_window.SetActive(true);
        attack_window.transform.position = new Vector2(Random.Range(700, 1600), 140);
        attack_window.transform.localScale = new Vector3(player.agility * 0.006f, 0.74163f, 0);
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
        swing.anim();
    }
    public void QTE_dodge()
    {
        bar.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        anim.SetTrigger("MonsterATK");
    }

    public void red()
    {
        if (damage == true)
        {
            player_screen.enabled = true;
            sprite.color = Color.red;
        }
    }
    public void white()
    {
        if (damage == true)
        {
            player_screen.enabled = true;
            sprite.color = Color.white;
        }
    }
    public void player_red()
    {
        if (damage == true)
        {
            print("YIPI");
            player_screen.enabled = true;
            Color color = player_screen.color;
            color.a = 0.5f;
            player_screen.color = color;
        }
    }
    public void player_white()
    {
        if (damage == true)
        {
            player_screen.enabled = true;
            Color color = player_screen.color;
            color.a = 0;
            player_screen.color = color;
        }
    }
}
