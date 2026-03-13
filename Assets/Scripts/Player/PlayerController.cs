using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 _direction;
    private Rigidbody2D _rb;

    private bool _isPaused;

    private PlayerAnimationController _animationController;

    #region Properties
    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsPaused { get => _isPaused; set => _isPaused = value; }
    #endregion

    private void Awake()
    {
        _animationController = GetComponent<PlayerAnimationController>();
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

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Attack();
        }
    }
    #endregion

    #region Actions
    void Move()
    {
        if (IsPaused) return;

        _rb.linearVelocity = Direction * speed;
    }

    void Attack()
    {
        if (IsPaused) return;

        _rb.linearVelocity = Vector2.zero;
        _animationController.StartAttack();
    }
    #endregion
}