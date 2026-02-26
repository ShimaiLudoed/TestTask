using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;
    
    private Coin.CoinFactory _coinFactory;
    private FloatData _floatData;
    private TransformData _transformData;
    private LayerData _layerData;
    private ScoreView _scoreView;
    
    private Coroutine _spawnCoroutine;

    [Inject]
    public void Construct(Coin.CoinFactory coinFactory, FloatData floatData, TransformData transformData, LayerData layerData, ScoreView scoreView)
    {
        _coinFactory = coinFactory;
        _floatData = floatData;
        _transformData = transformData;
        _layerData = layerData;
        _scoreView = scoreView;
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
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        Coin coin = _coinFactory.Create(_floatData, _transformData, _layerData, _scoreView);
        
        if (coin != null)
        {
            coin.transform.position = spawnPoint.position;
            coin.transform.rotation = spawnPoint.rotation;
            
            coin.transform.SetParent(transform);
        }
    }
}