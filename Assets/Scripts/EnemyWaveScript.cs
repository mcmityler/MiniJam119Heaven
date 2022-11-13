/*
By Tyler McMillan
Description: Enemy wave script that deals with spawning enemies waves / game cycle.
*/
using UnityEngine;
using TMPro;
public class EnemyWaveScript : MonoBehaviour
{
    [SerializeField] GameObject _topSpawnBox, _botSpawnBox, _rightSpawnBox, _leftSpawnBox; //where the enemies can spawn
    [SerializeField] int _waveNum = 0; //what wave you are on

    float _timeBetweenWaves = 7f; //how many seconds you have to wait between waves
    float _counter = 0f;
    [SerializeField] GameObject _waveNumText;

    [SerializeField] GameObject _basicEnemyUnit;
    int _maxWaves = 5;
    bool _gameStarted = false;
    void Start()
    {
        _timeBetweenWaves = 1f; //make waves take longer to spawn

    }
    void Update()
    {
        if (_gameStarted == true && _waveNum < _maxWaves)
        {
            _counter += Time.deltaTime;
            if (_counter > _timeBetweenWaves)
            {
                _counter = 0;
                _waveNum++;
                SpawnNextWave();
                _waveNumText.GetComponent<TMP_Text>().text = "Wave " + _waveNum.ToString();
                _waveNumText.GetComponent<Animator>().SetTrigger("WaveNum");
            }
        }
        if (_waveNum >= _maxWaves) //if you hit max waves and kill all enemies show win screen
        {

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("Winner!!!!");
                this.gameObject.GetComponent<GameOverScript>().Winner();
            }
        }

    }
    public void StartWaves()
    {
        _gameStarted = true;
    }
    public void StopWaves()
    {
        _gameStarted = false;
    }
    void SpawnUnit(GameObject m_spawnBox, GameObject m_enemytoSpawn)
    {
        Instantiate(m_enemytoSpawn, new Vector3(Random.Range(m_spawnBox.transform.localPosition.x - m_spawnBox.transform.localScale.x / 2, m_spawnBox.transform.localPosition.x + m_spawnBox.transform.localScale.x / 2),
            Random.Range(m_spawnBox.transform.localPosition.y - m_spawnBox.transform.localScale.y / 2, m_spawnBox.transform.localPosition.y + m_spawnBox.transform.localScale.y / 2), 0), Quaternion.identity);
    }
    void SpawnNextWave()
    {
        switch (_waveNum)
        {
            case 1:
                SpawnUnit(_topSpawnBox, _basicEnemyUnit);
                SpawnUnit(_topSpawnBox, _basicEnemyUnit);
                SpawnUnit(_topSpawnBox, _basicEnemyUnit);
                _timeBetweenWaves = 15f; //make waves take longer to spawn
                break;
            case 2:
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                break;
            case 3:
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                break;
            case 4:
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                break;
            case 5:
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_rightSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_leftSpawnBox, _basicEnemyUnit);
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                SpawnUnit(_botSpawnBox, _basicEnemyUnit);
                SpawnUnit(_topSpawnBox, _basicEnemyUnit);
                SpawnUnit(_topSpawnBox, _basicEnemyUnit);

                break;
        }
    }

    public void RestartWaves()
    {
        _waveNum = 0;
        _counter = 0;
        _timeBetweenWaves = 7f;
        _waveNumText.GetComponent<TMP_Text>().text = "Starting Game";
        _waveNumText.GetComponent<Animator>().SetTrigger("WaveNum");
        StartWaves();
    }


}
