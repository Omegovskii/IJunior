using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * _speed * Time.deltaTime;

        _renderer.flipX = movement < 0 ? true : false;

        bool enableAnimation = movement == 0 ? false : true;
        _animator.SetBool("isMove", enableAnimation);
    }
}
