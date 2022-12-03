using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private GameManager _gameManager;
    private float _radius;
    private int _wayPointIndex = 0;
    private float _speed;
    private float _posX = 0f;
    private float _posY = 0f;
    private float _angle = 0f;
    private bool _isMove = true;
    private float _coefAngle = 0.5f;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().gameObject.GetComponent<GameManager>();
        _posX = transform.position.x;
        _posY = transform.position.y;
        _radius = _gameManager.RadiusMoveModel;
        _speed = _gameManager.SpeedModel;
    }

    void Update()
    {
        if (_wayPointIndex == 0)
        {
            StartMove();
        }
        else
        {
            if (_isMove)
            {
                StartMoveByCircle();
            }
        }
    }

    void StartMove()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            _wayPointIndex = 1;
        }
    }

    void StartMoveByCircle()
    {
        _posX = Mathf.Cos(_angle) * _radius;
        _posY = Mathf.Sin(_angle) * _radius;
        transform.position = new Vector3(_posX, 0, _posY) + new Vector3(_target.position.x, _target.position.y, _target.position.z);
        _angle += Time.deltaTime * _speed * _coefAngle;
        if (_angle >= 360f)
        {
            _angle = 0f;
        }
    }

    public bool IsMove
    {
        get { return _isMove; }
    }
}
