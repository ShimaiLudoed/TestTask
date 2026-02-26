using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class PlayerView : MonoBehaviour
{
    private Rigidbody2D _rb;
    private LayerData _layerData;
    private ISound _sound;
    private FloatData _floatData;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    [Inject]
    public void Construct(ISound sound, FloatData floatData, LayerData layerData)
    {
        _sound = sound;
        _floatData = floatData;
        _layerData = layerData;
    }
    public void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
        _rb.AddForce(Vector3.up * _floatData.Force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMaskCheck.ContainsLayer(_layerData.GroundLayer,collision.gameObject.layer))
        {
            _sound.EndGameSound();
            SceneManager.LoadScene("Game");
        }
    }
}
