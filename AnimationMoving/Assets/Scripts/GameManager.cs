using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Models")]
    [SerializeField] private GameObject[] _models;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _startSpawnTime;
    [SerializeField] private float _speedModel;
    [SerializeField] private float _radiusMoveModel;
    private float _spawnTime;
    private int _index = 0;
    private float _time = 0f;
    [SerializeField] private float _timeForRotate = 10f;

    private TokenController _tokenController;
    private WinObjectController _winObjectController;
    private TapButtonController _tapButtonController;

    private void Start()
    {
        _spawnTime = _startSpawnTime;
        _tokenController = FindObjectOfType<TokenController>().gameObject.GetComponent<TokenController>();
        _winObjectController = FindObjectOfType<WinObjectController>().gameObject.GetComponent<WinObjectController>();
        _tapButtonController = FindObjectOfType<TapButtonController>().gameObject.GetComponent<TapButtonController>();
    }

    void Update()
    {
        if (BoxController.IsTap)
        {
            Init();
            _time += Time.deltaTime;
            if (_time >= _timeForRotate)
            {
                var cloneModels = GameObject.FindGameObjectsWithTag("Model");
                foreach (var clone in cloneModels)
                {
                    Destroy(clone);
                }
                _tokenController.MoveToken();
            }
            if (_tokenController.Speed == 0f)
            {
                _winObjectController.StartMoveWinObject();
            }
            if (_winObjectController.SpeedWinModel == 0)
            {
                _tapButtonController.StartMoveTapButton();
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

    public float SpeedModel
    {
        get { return _speedModel; }        
    }

    public float RadiusMoveModel
    {
        get { return _radiusMoveModel; }
    }
}
