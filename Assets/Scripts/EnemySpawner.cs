using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _enemySpawnsPerSecond;

    [SerializeField]
    private float _freindlySpawnsPerSecond;

    [SerializeField]
    private float _spawnRateAmplifier;

    [SerializeField]
    private List<GameObject> Enemies;

    [SerializeField]
    private List<GameObject> Freindlies;

    [SerializeField]
    private List<Transform> _spawnpoints;

    [SerializeField]
    private List<Transform> _endpoints;

    public void Start()
    {
        StartCoroutine(EnemySpawnerCooldown());
        StartCoroutine(FreindlySpawnerCooldown());
        StartCoroutine(SpawnRateAmplifier());
        Debug.Log("start");
    }

    private IEnumerator EnemySpawnerCooldown()
    {
        yield return new WaitForSeconds(1 / _enemySpawnsPerSecond);
        SpawnEnemy();
        StartCoroutine(EnemySpawnerCooldown());
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)], _spawnpoints[Random.Range(0, _spawnpoints.Count)]);
        enemy.GetComponent<Enemy>()._target = _endpoints[Random.Range(0, _endpoints.Count)];
    }

    private IEnumerator FreindlySpawnerCooldown()
    {
        yield return new WaitForSeconds(1 / _freindlySpawnsPerSecond);
        SpawnFreindly();
        StartCoroutine(FreindlySpawnerCooldown());
    }

    private void SpawnFreindly()
    {
        GameObject freindly = Instantiate(Freindlies[Random.Range(0, Freindlies.Count)], _spawnpoints[Random.Range(0, _spawnpoints.Count)]);
        freindly.GetComponent<Freindly>()._target = _endpoints[Random.Range(0, _endpoints.Count)];
    }

    private IEnumerator SpawnRateAmplifier()
    {
        yield return new WaitForSeconds(1);
        _enemySpawnsPerSecond *= (1 + _spawnRateAmplifier);
        _freindlySpawnsPerSecond /= (1 + _spawnRateAmplifier);
        Debug.Log(_enemySpawnsPerSecond);
        Debug.Log(_freindlySpawnsPerSecond);
        StartCoroutine(SpawnRateAmplifier());
    }
}
