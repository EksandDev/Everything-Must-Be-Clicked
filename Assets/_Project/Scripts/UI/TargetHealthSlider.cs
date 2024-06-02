using UnityEngine;
using UnityEngine.UI;

public class TargetHealthSlider : MonoBehaviour
{
    private Slider _slider;
    private int _health;
    private int _maxHealth;

    public int Health 
    {
        get => _health;
        set
        {
            if (value <= 0)
                return;

            _health = value;

            ChangeHealthValue(_health);
        } 
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            if (value <= 0 || value == _maxHealth)
                return;

            _maxHealth = value;

            ChangeMaxHealthValue(_maxHealth);
        }
    }

    private void ChangeHealthValue(int newValue)
    {
        _slider.value = newValue;
    }

    private void ChangeMaxHealthValue(int newValue)
    {
        _slider.maxValue = newValue;
    }

    private void Awake() => _slider = GetComponent<Slider>();
}