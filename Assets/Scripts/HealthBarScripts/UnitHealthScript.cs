/*
By Tyler McMillan
Description: Deals with each units individual health and death cycle
*/
using UnityEngine;

public class UnitHealthScript : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3; //max or starting health of units
    private int _currentHealth; //current health of unit

    [SerializeField] private HealthbarScript _healthbar; //reference to the healthbar
    [SerializeField] bool _isPatrol = false;
    [SerializeField] bool _isHeavensGate = false;
     CameraShake _cameraShake = null;


    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.SetMaxHealth(_maxHealth);
        _cameraShake = Camera.main.gameObject.GetComponent<CameraShake>();

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
        if (this.gameObject.name == "HeavenGate" && (_currentHealth == 25|| _currentHealth == 19 || _currentHealth == 15|| _currentHealth == 9|| _currentHealth == 5))
        {
            StartCoroutine(_cameraShake.Shake(0.1f, 0.1f)); //make camera shake whenever you take damage
            this.gameObject.GetComponent<HeavenGateScript>().ChangeSprite();
        }
        return _currentHealth;
    }
    public void KillObject()
    {
        if(_isHeavensGate){
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOverScript>().GameOver(); //call game over when the heavens gate is destroyed
        }
        if (_isPatrol)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
}
