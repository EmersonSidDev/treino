using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 _direction;
    private Rigidbody2D _rb;

    public Vector2 Direction { get => _direction; set => _direction = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    #region Inputs
    void OnMove(InputValue value)
    {
        Direction = value.Get<Vector2>().normalized;
    }
    #endregion

    #region Actions
    void Move()
    {
        _rb.linearVelocity = Direction * speed;
    }
    #endregion
}