using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    [SerializeField] private Slider _healthslider;
    private int _maxHealth; //gets set in unit health script (also where it deals with it dying / taking damage or healing)
    [SerializeField] private Gradient _healthFillGradient;

    [SerializeField] private Image _healthbarFillImage;

    public void SetMaxHealth(int m_health) //set initial maximum amount of health
    {
        _healthslider.maxValue = m_health;
        _healthslider.value = m_health;

        _healthbarFillImage.color = _healthFillGradient.Evaluate(1f);
    }

    public void SetHealth(int m_health) //adjust health value (healing or damage)
    {
        _healthslider.value = m_health;
        _healthbarFillImage.color = _healthFillGradient.Evaluate(_healthslider.normalizedValue); //change color of health bar depending on level, normalized value means how much of the slider is used 0f-1f rather then if they had 3 health 0-3
    }
}
