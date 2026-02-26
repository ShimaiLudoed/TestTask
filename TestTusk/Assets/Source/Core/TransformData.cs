using UnityEngine;

public class TransformData : MonoBehaviour
{
  [field: SerializeField] public Transform CoinSpawn{get; private set;}
  [field: SerializeField] public Transform EnemySpawn{get; private set;}
}
