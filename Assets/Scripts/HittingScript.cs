using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingScript : MonoBehaviour
{
    EnemyMovementScript _enemyMovement;
    MovementScript _allyMovementScript;
    private List<GameObject> _hitTargets = new List<GameObject>();
    bool _isEnemy = false;
    [SerializeField] private int _damageAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Enemy")
        {
            _isEnemy = true;
        }
        if (_isEnemy)
        {
            _enemyMovement = this.gameObject.GetComponent<EnemyMovementScript>();
        }
        else
        {
            _allyMovementScript = this.gameObject.GetComponent<MovementScript>();
        }
    }
    public void InAttackRange(GameObject m_targetToHit) //add targets to hit targets when they are in range of the trigger
    {
        //start anim and stop unit
        this.GetComponent<Animator>().SetTrigger("Hit");
        _hitTargets.Add(m_targetToHit);

        if (_isEnemy)
        {
            _enemyMovement.StopMovement();
        }
        else
        {
            _allyMovementScript.StopMovement();
        }
        transform.right = (_hitTargets[0].transform.position - transform.position);
    }
    public void HitTarget()
    {
        List<GameObject> m_hitTargetsTemp = new List<GameObject>(_hitTargets); //rotate through all object in hit range
        foreach (var m_hitTarget in m_hitTargetsTemp)
        {
            int _hitTargetHealth = -1;
            if (m_hitTarget != null)
            {
                _hitTargetHealth = m_hitTarget.GetComponent<UnitHealthScript>().TakeDamage(_damageAmount);
            }
            if (_hitTargetHealth < 1 && m_hitTarget != null) //do this if this object killed something
            {
                m_hitTarget.GetComponent<UnitHealthScript>().KillObject();
                _hitTargets.Remove(m_hitTarget);
                HitObjectKilled();
            }
            else if (m_hitTarget == null)//do this once the object you wanted to kill is dead
            {
                _hitTargets.Remove(m_hitTarget);
                HitObjectKilled();

            }
        }

    }
    public void HitObjectKilled()
    {
        if (_hitTargets.Count == 0)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Move");
            if (_isEnemy)
            {
                _enemyMovement.ResumeMovement();
            }
            else
            {
                _allyMovementScript.ResumeMovement();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && this.gameObject.tag == "Ally")
        {
            col.gameObject.GetComponent<HittingScript>().InAttackRange(this.gameObject);
            if (_allyMovementScript != null)
            {
                InAttackRange(col.gameObject);
            }
        }
    }
}
