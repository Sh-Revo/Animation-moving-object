using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;
    private static bool _isTap = false;
    private int _wayPointIndex = 0;

    private void Update()
    {
        if (_wayPointIndex == 0)
        {
            BoxMove();
        }
    }

    private void OnMouseDown()
    {
        _isTap = true;
    }

    public static bool IsTap
    {
        get { return _isTap; }
    }

    void BoxMove()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f)
        {
            _wayPointIndex = 1;
        }
    }
}
