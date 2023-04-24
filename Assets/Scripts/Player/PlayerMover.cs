using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _baseSpeed;

    private Vector2 _direction;

    public Vector2 Direction => _direction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Animation();
    }

    private void Move()
    {
        _direction.x = Input.GetAxis(Horizontal);
        _direction.y = Input.GetAxis(Vertical);
        _rigidbody2D.velocity = _direction * _baseSpeed * _speed;
    }

    private void Animation()
    {
        if (_direction != Vector2.zero)
        {
            _animator.SetFloat(Horizontal, _direction.x);
            _animator.SetFloat(Vertical, _direction.y);
        }
    }
}
