using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthScript : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3; //max or starting health of units
    private int _currentHealth; //current health of unit

    [SerializeField] private HealthbarScript _healthbar; //reference to the healthbar
    [SerializeField] bool _isPatrol = false;


    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.SetMaxHealth(_maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
    public int TakeDamage(int m_damage)
    {
        _currentHealth -= m_damage;
        _healthbar.SetHealth(_currentHealth);
        return _currentHealth;
    }
    public void KillObject()
    {
        if (_isPatrol)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
}
