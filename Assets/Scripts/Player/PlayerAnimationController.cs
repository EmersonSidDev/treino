using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Vector2 _lastDirection = Vector2.down;
    private float _speed;

    private PlayerController _playerController;
    private Animator _animator;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.SetFloat("LastMoveX", 0f);
        _animator.SetFloat("LastMoveY", -1f);
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = _playerController.Direction;

        _lastDirection = direction;
        _speed = _lastDirection.magnitude;

        _animator.SetFloat("MoveX", _lastDirection.x);
        _animator.SetFloat("MoveY", _lastDirection.y);

        //SetLastMove();
        if (_speed > 0)
        {
            _animator.SetFloat("LastMoveX", _lastDirection.x);
            _animator.SetFloat("LastMoveY", _lastDirection.y);
        }
    }

    public void StartAttack()
    {
        _playerController.IsPaused = true;
        _animator.SetTrigger("Attack");
    }

    public void EndAttack()
    {
        _playerController.IsPaused = false;
    }
}