using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    [SerializeField] private GameObject _token;
    [SerializeField] private GameObject[] _points;
    private Transform _target;
    private float _speed = 8f;
    private int _wayPointIndex = 0;

    private void Start()
    {
        _target = _points[0].transform;
    }

    public void MoveToken()
    {
        Vector3 direction = _target.position - _token.transform.position;
        _token.transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        _token.transform.Rotate(0.0f, (_speed / 5), 0.0f);

        if (Vector3.Distance(_token.transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (_wayPointIndex >= _points.Length - 1)
        {
            _speed = 0;
            return;
        }

        _wayPointIndex++;
        _target = _points[_wayPointIndex].transform;
    }

    public float Speed
    {
        get { return _speed; }
    }
}
