using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterhealthbar : MonoBehaviour
{
    public Slider slider;
    public monster monster;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        monster = FindAnyObjectByType<monster>();
        slider.maxValue = monster.maxhealth;
    }
    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = monster.health;
    }
}
