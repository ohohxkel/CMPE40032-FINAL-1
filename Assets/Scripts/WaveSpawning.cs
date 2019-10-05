using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour
{


    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public int nextWave = 0;
 

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;

    public float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;

    public WaveTitle waveTitle;


    void Start()
    {
        waveCountdown = timeBetweenWaves;
        waveTitle = GameObject.Find("WaveText").GetComponent<WaveTitle>();

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                Debug.Log("Wave copleted!");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }



    }
    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("waves are completed, initiating looping sequence...");
        }
        nextWave++;

        WaveTitle.wave = nextWave;
        waveTitle.StartCoroutine("FadeInOut");
        

    }

   

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }


        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        if (nextWave > 1)
        {
            _wave.count += Random.Range(1, 10);
        }


        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;


        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Debug.Log("Spawning Wave...");
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}