using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;
    private static bool _isTap;
    private int _wayPointIndex = 0;

    private void Start()
    {
        _isTap = false;
    }

    private void Update()
    {
        if (_wayPointIndex == 0)
        {
            BoxMove();
        }
    }

    public static bool IsTap
    {
        get { return _isTap; }
    }

    void BoxMove()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            _wayPointIndex = 1;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isTap = true;
    }
}
