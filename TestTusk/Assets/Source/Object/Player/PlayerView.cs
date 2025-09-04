using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _force;
    private LayerMask _groundLayer;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
    }
}
