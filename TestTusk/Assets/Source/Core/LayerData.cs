using UnityEngine;

public class LayerData : MonoBehaviour
{
  [field: SerializeField] public LayerMask GroundLayer {get; private set;}
  [field: SerializeField] public LayerMask CoinLayer {get; private set;}
  [field: SerializeField] public LayerMask WallLayer { get; private set; }
}
