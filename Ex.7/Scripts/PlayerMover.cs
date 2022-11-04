using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Rigidbody2D),typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;
    private const string IsRunning = "isRunning";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        else
            _animator.SetBool(IsRunning, false);
 
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        CheckOnGround();
    }

    private void Run()
    {
        _animator.SetBool(IsRunning, true);

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        _spriteRenderer.flipX = direction.x < 0;
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckOnGround()
    {
        float radiusCircle = 0.5f;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusCircle);
        _isGrounded = colliders.Length > 1;
    }
}
