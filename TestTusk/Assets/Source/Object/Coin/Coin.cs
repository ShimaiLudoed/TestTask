using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class Coin : MonoBehaviour
{
  private FloatData _floatData;

  private LayerData _layerData;
  private ScoreView _scoreView;
    private Rigidbody2D _rb;

  [Inject]
  public void Construct(FloatData floatData, TransformData transformData, LayerData layerData, ScoreView scoreView)
  {
    _floatData = floatData;
        _layerData = layerData;
        _scoreView = scoreView;
  }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMaskCheck.ContainsLayer(_layerData.PlayerLayer, collision.gameObject.layer))
        {
            _scoreView.AddScore();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        _rb.linearVelocity = new Vector2(Vector2.left.x * _floatData.GameSpeed, transform.position.y);
    }
}
