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
    public bool talked;

    public Vector2 spawn;
    public Vector2 QTE_spawn;

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

    //dialogue
    [SerializeField]
    GameObject fight_option;
    [SerializeField]
    GameObject attack_option;
    [SerializeField]
    GameObject defend_option;
    [SerializeField]
    GameObject persuade_succes_option;
    [SerializeField]
    GameObject persuade_fail_option;

    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject fight;
    [SerializeField]
    GameObject defend;
    [SerializeField]
    GameObject persuade_succes;
    [SerializeField]
    GameObject persuade_fail;
    [SerializeField]
    GameObject hit_succes;
    [SerializeField]
    GameObject hit_miss;
    [SerializeField]
    GameObject dodge_succes;
    [SerializeField]
    GameObject dodge_miss;
    [SerializeField]
    GameObject death;

    StatManager player;
    smol_monster smol;
    swing swing;
    public Image player_screen;
    public Text chari;
    public bool persuaded;

    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        defend.SetActive(false);
        start.SetActive(false);
        fight.SetActive(false);
        defend_option.SetActive(false);
        persuade_succes_option.SetActive(false);
        persuade_fail_option.SetActive(false);
        persuade_fail.SetActive(false);
        hit_succes.SetActive(false);
        hit_miss.SetActive(false);
        dodge_succes.SetActive(false);
        dodge_miss.SetActive(false);
        death.SetActive(false);
        swing = FindAnyObjectByType<swing>();
        smol = FindAnyObjectByType<smol_monster>();
        player = FindAnyObjectByType<StatManager>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        healthtext.SetActive(false);
        fight_option.SetActive(false);
        persuade_succes.SetActive(false);
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
        print("start");
        player_screen.enabled = false;
        talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (persuade_succes.activeSelf == false && persuaded == true)
        {
            Destroy(gameObject);
            FindAnyObjectByType<CameraScript>().enabled = true;
        }
        if (player.charisma < 150)
        {
            chari.color = Color.red;
            print("kaka");
        }
        else
        {
            chari.color = Color.white;
        }
        if (smol.talking == true)
        {
            if (talked == false)
            {
                Talk();
                smol.talking = false;
                talked = true;
            }
        }
        if (health <= 0 && health > -1000)
        {
            die();
        }
        if (health == -9999)
        {
            if (death.activeSelf == false)
            {
                FindAnyObjectByType<CameraScript>().enabled = true;
                Destroy(gameObject);
                smol.dead = true;
            }
        }

        if (Dodge_QTE_start == true || Attack_QTE_start == true)
        {
            stick.transform.position += new Vector3(1700, 0, 0) * Time.deltaTime;
            if (stick.transform.position.x >= 1800)
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
    public void Talk()
    {
        print("talk");
        FindAnyObjectByType<CameraScript>().enabled = false;
        start.SetActive(true);
        fight_option.SetActive(true);
        defend_option.SetActive(true);
    }
    public void Defend()
    {
        print("defend");
        defend.SetActive(true);
        fight_option.SetActive(false);
        defend_option.SetActive(false);
        persuade_succes_option.SetActive(true);
        persuade_fail_option.SetActive(true);
    }
    public void Fight()
    {
        print("fight");
        fight.SetActive(true);
        healthtext.SetActive(true);
        fight_option.SetActive(false);
        defend_option.SetActive(false);
        attack_option.SetActive(true);
    }
    public void Persuade_succes()
    {
        if (player.charisma >= 150)
        {
            persuaded = true;
            persuade_succes_option.SetActive(false);
            persuade_fail_option.SetActive(false);
            persuade_succes.SetActive(true);
        }
    }
    public void Persuade_fail()
    {
        persuade_succes_option.SetActive(false);
        persuade_fail_option.SetActive(false);
        persuade_fail.SetActive(true);
        healthtext.SetActive(true);
        attack_option.SetActive(true);
        print("fight");
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
        hit_succes.SetActive(true);
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
        dodge_miss.SetActive(true);
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
        dodge_window.transform.position = new Vector2(Random.Range(800, 1600), 140);
        dodge_window.transform.localScale = new Vector3(player.agility * 0.008f, 0.74163f, 0);
        stick.transform.position = spawn;
        Dodge_QTE_start = true;
        hit_miss.SetActive(false);
        hit_succes.SetActive(false);
    }

    public void QTE_attacking()
    {
        attack_option.SetActive(false);
        bar.SetActive(true);
        attack_window.SetActive(true);
        attack_window.transform.position = new Vector2(Random.Range(800, 1600), 140);
        attack_window.transform.localScale = new Vector3(player.agility * 0.008f, 0.74163f, 0);
        stick.SetActive(true);
        stick.transform.position = spawn;
        Attack_QTE_start = true;
        dodge_miss.SetActive(false);
        dodge_succes.SetActive(false);
    }
    public void QTE_hit()
    {
        hit_miss.SetActive(true);
        bar.SetActive(false);
        attack_window.SetActive(false);
        stick.SetActive(false);
        anim.SetTrigger("PlayerATK");
        swing.anim();
    }
    public void QTE_dodge()
    {
        dodge_succes.SetActive(true);
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
    public void die()
    {
        anim.enabled = false;
        health = -9999;
        death.SetActive(true);
        healthtext.SetActive(false);
        bar.SetActive(false);
        dodge_window.SetActive(false);
        stick.SetActive(false);
        attack_option.SetActive(false);
    }
}
