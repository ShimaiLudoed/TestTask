using System;
using System.Collections;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
  [SerializeField] private Transform spawnPoint;
  [SerializeField] private float minSpawnDelay;
  [SerializeField] private float maxSpawnDelay;
    
  private FloatData _floatData;
  private LayerData _layerData;
  private ScoreView _scoreView;
  private Func<FloatData, LayerData, ScoreView, Coin> _coinFactory;
    
  private Coroutine _spawnCoroutine;
  private bool _isInitialized = false;

  [Inject]
  public void Construct(
    FloatData floatData, 
    LayerData layerData, 
    ScoreView scoreView,
    Func<FloatData, LayerData, ScoreView, Coin> coinFactory)
  {
    _floatData = floatData;
    _layerData = layerData;
    _scoreView = scoreView;
    _coinFactory = coinFactory;
    _isInitialized = true;
  }

  private void Start()
  {
    if (_isInitialized)
    {
      StartSpawning();
    }
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
    if (spawnPoint == null || !_isInitialized)
    {
      return;
    }

    Coin coin = _coinFactory(_floatData, _layerData, _scoreView);
        
    if (coin != null)
    {
      coin.transform.position = spawnPoint.position;
      coin.transform.rotation = spawnPoint.rotation;
      coin.transform.SetParent(transform);
    }
  }
}