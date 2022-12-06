using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjectController : MonoBehaviour
{
    [SerializeField] private GameObject _winModel;
    [SerializeField] private Transform _winTarget;
    [SerializeField] private float _speedWinModel = 5f;
    [SerializeField] private Animator _animatorWinModel;

    public void StartMoveWinObject()
    {
        Vector3 direction = _winTarget.position - _winModel.transform.position;
        _winModel.transform.Translate(direction.normalized * _speedWinModel * Time.deltaTime, Space.World);

        if (Vector3.Distance(_winModel.transform.position, _winTarget.position) <= 0.4f)
        {
            _speedWinModel = 0;
            _animatorWinModel.enabled = true;
        }
    }

    public float SpeedWinModel
    {
        get { return _speedWinModel; }
    }
}
