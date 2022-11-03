using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _deltaX;
    [SerializeField] private float _deltaY;
    [SerializeField] private float _deltaZ;

    private void Start()
    {
        _deltaX = -4;
        _deltaY = -0;
        _deltaZ = 11;
    }

    private void Update()
    {
        transform.position = new Vector3(_target.position.x - _deltaX, _target.position.y - _deltaY, _target.position.z - _deltaZ);
    }
}
