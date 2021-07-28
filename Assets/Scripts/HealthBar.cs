using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider m_Slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(int health)
    {
        m_Slider.maxValue = health;
        m_Slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        m_Slider.value = health;
        fill.color = gradient.Evaluate(m_Slider.normalizedValue);
    }
}
