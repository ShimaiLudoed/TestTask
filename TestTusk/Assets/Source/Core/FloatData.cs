using UnityEngine;

public class FloatData : MonoBehaviour
{
  [field: SerializeField] public float GameSpeed { get; private set; }
  [field: SerializeField] public float Force { get; private set; }
  [field: SerializeField] public float VerticalSpeed { get; private set; }
  [field: SerializeField] public float Height { get; private set; }
}
