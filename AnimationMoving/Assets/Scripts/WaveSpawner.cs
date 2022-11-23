using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _models;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _startSpawnTime;
    private float _spawnTime;
    private int _index = 0;

    private void Start()
    {
        _spawnTime = _startSpawnTime;
    }

    void Update()
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
}
