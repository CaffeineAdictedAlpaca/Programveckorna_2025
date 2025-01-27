using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterhealthbar : MonoBehaviour
{
    public Slider slider;
    public monster enemy;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider.maxValue = enemy.maxhealth;
    }
    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = enemy.health;
    }
}
