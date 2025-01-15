using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpened : MonoBehaviour
{
    [SerializeField] GameObject chestBox;
    void Start()
    {
        chestBox.SetActive(false);
    }
}
