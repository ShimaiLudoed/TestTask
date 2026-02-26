using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class Enemy : MonoBehaviour
{
    private LayerData _layerData;
    private FloatData _floatData;
    private Rigidbody2D _rb;

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
        float moveUpDown = Mathf.Sin(Time.time * _floatData.VerticalSpeed) * _floatData.Height;
        _rb.linearVelocity = new Vector2(Vector2.left.x * _floatData.GameSpeed, moveUpDown);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskCheck.ContainsLayer(_layerData.PlayerLayer, other.gameObject.layer))
        {
            SceneManager.LoadScene("Main");
        }

        if (LayerMaskCheck.ContainsLayer(_layerData.WallLayer, other.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
    
}
