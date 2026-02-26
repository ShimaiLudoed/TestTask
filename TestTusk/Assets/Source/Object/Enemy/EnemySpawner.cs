using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minSpawnDelay = 2f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private int maxEnemiesOnScreen = 5;
    
    private Enemy.EnemyFactory _enemyFactory;
    private LayerData _layerData;
    private FloatData _floatData;
    
    private Coroutine _spawnCoroutine;
    private int _currentEnemyCount;

    [Inject]
    public void Construct(Enemy.EnemyFactory enemyFactory, LayerData layerData, FloatData floatData)
    {
        _enemyFactory = enemyFactory;
        _layerData = layerData;
        _floatData = floatData;
    }

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
            
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
    }
    
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            
            if (_currentEnemyCount < maxEnemiesOnScreen)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoint == null)
        {
            return;
        }
        ;
        Enemy enemy = _enemyFactory.Create(_layerData, _floatData);
        
        if (enemy != null)
        {
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.transform.SetParent(transform);
            
            _currentEnemyCount++;
        }
    }
}