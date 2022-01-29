using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player Components/Player Movement")]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float _jumpForce = 3.0f;
    [SerializeField, Range(1, 10)] private float _speed = 4.0f;

    [Header("Settings")]
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private float _overlapRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private AnimationCurve _curve;

    private Rigidbody2D _body;
    private Animator _anim;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 posOverlap = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(posOverlap, _overlapRadius, _groundLayer);
    }

    public void Move(float direction, bool jump)
    {
        if (jump) Jump();
               
        if (direction > 0 && transform.localEulerAngles.y != 0) transform.localEulerAngles = new Vector3(0, 0, 0);
        else if (direction < 0 && transform.rotation.y == 0) transform.localEulerAngles = new Vector3(0, 180, 0);

        if (Mathf.Abs(direction) > 0.01f) HorizontalMovement(direction);
    }

    public void Jump()
    {
        if (_isGrounded)
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
    }

    public void HorizontalMovement(float direction)
    {
        _body.velocity = new Vector2(_curve.Evaluate(direction), _body.velocity.y);
    }

#if UNITY_EDITOR
    [ContextMenu("Set Movement Speed")]
    public void SetSpeed()
    {
        _curve.keys[0].value = -_speed;
        _curve.keys[2].value = _speed;
    }
#endif
}
