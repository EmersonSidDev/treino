using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    private Vector2 _lastDirection = Vector2.down;

    private PlayerController _playerController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector2 direction = _playerController.Direction;

        _lastDirection = direction;

        _animator.SetFloat("MoveX", _lastDirection.x);
        _animator.SetFloat("MoveY", _lastDirection.y);
        _animator.SetFloat("Speed", direction.sqrMagnitude);

        HandleFlip(direction);
    }

    void HandleFlip(Vector2 direction)
    {
        if (direction.x != 0)
            _sprite.flipX = direction.x < 0;
    }
}