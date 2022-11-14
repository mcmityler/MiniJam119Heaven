/*
By Tyler McMillan
Description: Deals with Game over and restart of game
*/
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameObject _restartButton;
    [SerializeField] GameObject _CloudScreenBG;
    [SerializeField] GameObject _inifiteFireObj;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _winnerText;

    int _maxFire = 25;
    int _fireCounter = 0;
    float _timeBetweenFires = 0.5f;
    float _counter = 0;
    bool _gameOver = false;
    [SerializeField] GameObject _heavensGate;
    [SerializeField] GameObject _creditButton;
    void Update()
    {
        if (_gameOver && _fireCounter < _maxFire) //spawn infinite Fires
        {
            _counter += Time.deltaTime;
            if (_counter > _timeBetweenFires)
            {
                _counter = 0;
                //spawn fire within game screen on game over
                SpawnInfiniteFire(_CloudScreenBG, _inifiteFireObj);
                SpawnInfiniteFire(_CloudScreenBG, _inifiteFireObj);
                SpawnInfiniteFire(_CloudScreenBG, _inifiteFireObj);
                SpawnInfiniteFire(_CloudScreenBG, _inifiteFireObj);

                _fireCounter++;
            }
        }
    }
    void SpawnInfiniteFire(GameObject m_spawnBox, GameObject m_enemytoSpawn)
    {
        Instantiate(m_enemytoSpawn, new Vector3(Random.Range(m_spawnBox.transform.position.x - 8, m_spawnBox.transform.position.x + 8),
            Random.Range(m_spawnBox.transform.position.y - 4.5f, m_spawnBox.transform.position.y + 4.5f), 0), Quaternion.identity);
    }
    public void GameOver()
    {
        //spawn game over text object
        _gameOverText.SetActive(true);
        //spawn restart button and game over text
        _restartButton.SetActive(true);
        _creditButton.SetActive(true);


        //stop waves from spawning
        this.gameObject.GetComponent<EnemyWaveScript>().StopWaves();

        _gameOver = true;
    }
    public void Winner()
    {
        //spawn restart button and game over text
        _restartButton.SetActive(true);
        //stop waves from spawning
        this.gameObject.GetComponent<EnemyWaveScript>().StopWaves();
        _winnerText.SetActive(true);
        _creditButton.SetActive(true);

    }
    public void RestartGame()
    {
        //what to do when you hit restart button
        foreach (GameObject _allyUnit in GameObject.FindGameObjectsWithTag("Ally")) //DESTROY ALL ALLY UNITS
        {
            if (_allyUnit.GetComponent<MovementScript>() != null)
            {
                if (_allyUnit.GetComponent<MovementScript>().GetIsPatrol() == true)
                {
                    Destroy(_allyUnit.transform.parent.gameObject);
                    continue;
                }

            }
            Destroy(_allyUnit);
        }
        foreach (GameObject _enemyUnit in GameObject.FindGameObjectsWithTag("Enemy")) //DESTROY ALL Enemy UNITS
        {
            Destroy(_enemyUnit);
        }

        //ResetPP
        this.gameObject.GetComponent<PrayerPointScript>().ResetPP();

        //ResetWaves & make it say starting game on wave num text
        this.gameObject.GetComponent<EnemyWaveScript>().RestartWaves();

        //Remove Game Over Text Object
        _gameOverText.SetActive(false);

        //Remove Restart Button from screen
        _restartButton.SetActive(false);

        //Reset Infinite Fires
        foreach (GameObject _enemyUnit in GameObject.FindGameObjectsWithTag("FireEnemy")) //DESTROY ALL Enemy UNITS
        {
            Destroy(_enemyUnit);
        }
        _fireCounter = 0;
        _counter = 0;
        _gameOver = false;

        //spawn new HeavensGate
        Instantiate(_heavensGate, Vector3.zero, Quaternion.identity);

        _winnerText.SetActive(false);
        _creditButton.SetActive(false);



    }
}
