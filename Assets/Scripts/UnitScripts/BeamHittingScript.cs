/*
By Tyler McMillan
Description: Beam Angel unit script that fires beams of light at enemies doing damage; this script deals with checking where enemies are and what can be hit
*/
using UnityEngine;

public class BeamHittingScript : MonoBehaviour
{
    [SerializeField] int _beamDamage = 1;
    [SerializeField] GameObject _beamOfLight;
    public void HitEnemyWithBeam()
    {
        GameObject _closestEnemy = FindClosestEnemy();
        if (_closestEnemy != null)
        {

            int _hitTargetHealth = -1;
            if (_closestEnemy != null)
            {
                //make beam of light appear on target
                _beamOfLight.transform.position = _closestEnemy.transform.position;
                _beamOfLight.GetComponent<Animator>().SetTrigger("Beam");
                _hitTargetHealth = _closestEnemy.GetComponent<UnitHealthScript>().TakeDamage(_beamDamage);
            }
            if (_hitTargetHealth < 1 && _closestEnemy != null) //do this if this object killed something
            {
                _closestEnemy.GetComponent<UnitHealthScript>().KillObject();
            }
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Move");
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject _closestEnemy = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject _enemy in enemies)
        {
            if (_enemy.GetComponent<EnemyMovementScript>().GetBeamable()) //ensure enemy you are trying to hit is on the screen
            {
                Vector3 diff = _enemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    _closestEnemy = _enemy;
                    distance = curDistance;
                }
            }
        }
        return _closestEnemy;
    }
    public void CheckEnemiesExist()
    {
        if (FindClosestEnemy() != null)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
