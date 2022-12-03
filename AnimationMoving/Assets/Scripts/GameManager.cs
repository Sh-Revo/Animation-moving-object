using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Models")]
    [SerializeField] private GameObject[] _models;
    [SerializeField] private Transform _spawnPointModels;
    [SerializeField] private float _startSpawnTime;
    [SerializeField] private float _speedModel;
    [SerializeField] private float _radiusMoveModel;
    private float _spawnTime;
    private int _index = 0;
    private float _time = 0f;
    [SerializeField] private float _timeForRotate = 10f;
    private bool _isAliveModels = true;

    private TokenController _tokenController;
    private WinObjectController _winObjectController;
    private TapButtonController _tapButtonController;

    [Header("Images")]
    [SerializeField] private GameObject[] _images;
    [SerializeField] private Transform _spawnPointImages;
    private int _indexImages = 0;
    private float _spawnTimeImages;

    private void Start()
    {
        _spawnTime = _startSpawnTime;
        _spawnTimeImages = _startSpawnTime;
        _tokenController = FindObjectOfType<TokenController>().gameObject.GetComponent<TokenController>();
        _winObjectController = FindObjectOfType<WinObjectController>().gameObject.GetComponent<WinObjectController>();
        _tapButtonController = FindObjectOfType<TapButtonController>().gameObject.GetComponent<TapButtonController>();
    }

    void Update()
    {
        if (BoxController.IsTap)
        {
            InitModel();
            InitImage(_isAliveModels);
            _time += Time.deltaTime;
            if (_time >= _timeForRotate)
            {
                var cloneModels = GameObject.FindGameObjectsWithTag("Model");
                foreach (var clone in cloneModels)
                {
                    Destroy(clone);
                    _isAliveModels = false;
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

    void InitModel()
    {
        if (_spawnTime <= 0)
        {
            if (_index >= _models.Length)
            {
                return;
            }
            Instantiate(_models[_index], _spawnPointModels.transform.position, Quaternion.identity);
            _spawnTime = _startSpawnTime;
            _index++;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }
    }

    void InitImage(bool isAliveModels)
    {
        if (isAliveModels == true)
        {
            if (_spawnTimeImages <= 0)
            {
                if (_indexImages >= _images.Length)
                {
                    _indexImages = 0;
                }
                Instantiate(_images[_indexImages], _spawnPointImages.transform.position, Quaternion.identity);
                _spawnTimeImages = _startSpawnTime;
                _indexImages++;
            }
            else
            {
                _spawnTimeImages -= Time.deltaTime;
            }
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
