using TMPro;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private FloatData floatData;
    [SerializeField] private IntData intData;
    [SerializeField] private TextData textData;
    [SerializeField] private TransformData transformData;
    [SerializeField] private LayerData layerData;
    [SerializeField] private PlayerView playerView;
    //[SerializeField] private EnemyView enemyView;
    //[SerializeField] private CoinView coinView;
    //[SerializeField] private ScoreView scoreView;
    //[SerializeField] private EntitySpawner spawner;
    public override void InstallBindings()
    {
        Container.Bind<ISound>().To<Sound>().AsSingle().NonLazy();
        
        Container.Bind<AudioData>().FromInstance(audioData).AsSingle().NonLazy();
        Container.Bind<FloatData>().FromInstance(floatData).AsSingle().NonLazy();
        Container.Bind<IntData>().FromInstance(intData).AsSingle().NonLazy();
        Container.Bind<TextData>().FromInstance(textData).AsSingle().NonLazy();
        Container.Bind<TransformData>().FromInstance(transformData).AsSingle().NonLazy();
        Container.Bind<LayerData>().FromInstance(layerData).AsSingle().NonLazy();

        Container.Bind<PlayerView>().FromInstance(playerView).AsSingle().NonLazy();
        Container.Bind<PlayerController>().AsSingle().NonLazy();

        //Container.Bind<EnemyView>().FromInstance(enemyView).AsSingle().NonLazy();
        //Container.Bind<CoinView>().FromInstance(coinView).AsSingle().NonLazy();
        //Container.Bind<ScoreView>().FromInstance(scoreView).AsSingle().NonLazy();
    }
}