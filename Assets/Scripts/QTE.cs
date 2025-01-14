using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    monster monster;

    public bool dodge_window;
    public bool attack_window;

    // Start is called before the first frame update
    void Start()
    {
        monster = FindAnyObjectByType<monster>();
        dodge_window = false;
        attack_window = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || monster.QTE_miss == true)
        {
            if (monster.Dodge_QTE_start == true)
            {
                monster.Dodge_QTE_start = false;
                if (dodge_window == true)
                {
                    print("dodge hit");
                    monster.QTE_dodge();
                }
                else if (dodge_window == false)
                {
                    print("dodge miss");
                    monster.MonsterATK();
                    monster.QTE_miss = false;
                }
            }
            if (monster.Attack_QTE_start == true)
            {
                monster.Attack_QTE_start = false;
                if (attack_window == true)
                {
                    print("attack hit");
                    monster.PlayerATK();
                }
                else if (attack_window == false)
                {
                    print("attack miss");
                    monster.QTE_hit();
                    monster.QTE_miss = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="dodge_window")
        {
            dodge_window = true;
        }
        if (collision.gameObject.tag == "attack_window")
        {
            attack_window = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="dodge_window")
        {
            dodge_window = false;
        }
        if (collision.gameObject.tag == "attack_window")
        {
            attack_window = false;
        }
    }
}
