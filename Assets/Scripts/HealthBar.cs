using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    StatManager statTracker;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        statTracker = FindFirstObjectByType<StatManager>();
        slider.maxValue = statTracker.health;
    }
    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = statTracker.health;
    }

}
