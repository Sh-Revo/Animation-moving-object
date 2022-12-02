using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _tapButton;
    [SerializeField] private Transform _tapButtonTarget;
    [SerializeField] private float _speedButton = 25f;
    [SerializeField] private Animator _animatorTapButton;

    public void StartMoveTapButton()
    {
        Vector3 direction = _tapButtonTarget.position - _tapButton.transform.position;
        _tapButton.transform.Translate(direction.normalized * _speedButton * Time.deltaTime, Space.World);

        if (Vector3.Distance(_tapButton.transform.position, _tapButtonTarget.position) <= 0.1f)
        {
            _speedButton = 0f;
            _animatorTapButton.enabled = true;
        }
    }
}
