using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private LayerData _layerData;
    private FloatData _floatData;
    private Rigidbody2D _rb;
    public float verticalSpeed = 2f; // Скорость движения вверх-вниз
    public float height = 2f; // Высота движения

    [Inject]
    public void Construct(LayerData layerData, FloatData floatData)
    {
        _layerData = layerData;
        _floatData = floatData;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveUpDown = Mathf.Sin(Time.time * verticalSpeed) * height;
        _rb.linearVelocity = new Vector2(Vector2.left.x * _floatData.GameSpeed, moveUpDown);
    }

    public class EnemyFactory : PlaceholderFactory<LayerData,FloatData,Enemy>
    { }
}
