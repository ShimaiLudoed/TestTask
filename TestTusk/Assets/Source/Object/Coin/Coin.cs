using System;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
  private FloatData _floatData;
  private TransformData _transformData;

  [Inject]
  public void Construct(FloatData floatData, TransformData transformData)
  {
    _floatData = floatData;
    _transformData = transformData;
  }

  private void Update()
  {
    
  }
}
