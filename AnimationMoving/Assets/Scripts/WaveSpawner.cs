using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Models")]
    [SerializeField] private GameObject[] _models;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _startSpawnTime;
    private float _spawnTime;
    private int _index = 0;

    [Header("Token")]
    [SerializeField] private GameObject _token;
    [SerializeField] private GameObject[] _points;
    private Transform _target;
    private float _speed = 6f;
    private int _wayPointIndex = 0;

    [Header("Win Model")]
    [SerializeField] private GameObject _winModel;
    [SerializeField] private Transform _winTarget;
    private int _wayPointIndexWinModel = 0;
    private float _speedWinModel = 5f;

    private float _time = 0f;

    private void Start()
    {
        _spawnTime = _startSpawnTime;
        _target = _points[0].transform;
    }

    void Update()
    {
        if (BoxController.IsTap)
        {
            Init();
            _time += Time.deltaTime;
            if (_time >= 8f)
            {
                var cloneModels = GameObject.FindGameObjectsWithTag("Model");
                foreach (var clone in cloneModels)
                {
                    Destroy(clone);
                }
                MoveToken();
            }
            if (_speed == 0f)
            {
                if (_wayPointIndexWinModel == 0)
                {
                    StartMoveWinObject();
                }
            }
        }
    }

    void Init()
    {
        if (_spawnTime <= 0)
        {
            if (_index >= _models.Length)
            {
                return;
            }
            Instantiate(_models[_index], _spawnPoint.transform.position, Quaternion.identity);
            _spawnTime = _startSpawnTime;
            _index++;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }
    }

    void MoveToken()
    {
        Vector3 direction = _target.position - _token.transform.position;
        _token.transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

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

    void StartMoveWinObject()
    {
        Vector3 direction = _winTarget.position - _winModel.transform.position;
        _winModel.transform.Translate(direction.normalized * _speedWinModel * Time.deltaTime, Space.World);

        if (Vector3.Distance(_winModel.transform.position, _winTarget.position) <= 0.1f)
        {
            _wayPointIndexWinModel = 1;
        }
    }
}
