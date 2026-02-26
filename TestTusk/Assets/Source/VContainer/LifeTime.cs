using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LifeTime : LifetimeScope
{
  [SerializeField] private AudioData audioData;
  [SerializeField] private FloatData floatData;
  [SerializeField] private IntData intData;
  [SerializeField] private TextData textData;
  [SerializeField] private TransformData transformData;
  [SerializeField] private LayerData layerData;
  [SerializeField] private PlayerView playerView;
  [SerializeField] private ScoreView scoreView;
  [SerializeField] private Enemy enemyPrefab;
  [SerializeField] private Coin coinPrefab;
    
  protected override void Configure(IContainerBuilder builder)
  {
    builder.Register<ISound, Sound>(Lifetime.Singleton);
        
    builder.RegisterInstance(audioData);
    builder.RegisterInstance(floatData);
    builder.RegisterInstance(intData);
    builder.RegisterInstance(textData);
    builder.RegisterInstance(transformData);
    builder.RegisterInstance(layerData);
        
    builder.RegisterComponent(playerView);
    builder.RegisterComponent(scoreView);
    
    builder.RegisterComponent(FindObjectOfType<EnemySpawner>());
    builder.RegisterComponent(FindObjectOfType<CoinSpawner>());
        
    builder.Register<PlayerController>(Lifetime.Singleton);
        
    builder.RegisterEntryPoint<InputListener>(Lifetime.Singleton);
        
    builder.RegisterFactory<LayerData, FloatData, Enemy>(container => 
      (layerData, floatData) => 
      {
        var enemy = Container.Instantiate(enemyPrefab);
        return enemy;
      }, Lifetime.Singleton);
            
    builder.RegisterFactory<FloatData, LayerData, ScoreView, Coin>(container => 
      (floatData, layerData, scoreView) => 
      {
        var coin = Container.Instantiate(coinPrefab);
        return coin;
      }, Lifetime.Singleton);
  }
}