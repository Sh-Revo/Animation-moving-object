using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private int _wayPointIndex = 0;
    [SerializeField] private GameObject _model;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _radius = 5f;
    private float posX = 0f;
    private float posY = 0f;
    private float posZ = 0f;
    private float angle = 0f;

    void Start()
    {
        //_model = GetComponent<Model>();
        //_target = Waypoints.Points[0];
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
        Debug.Log("_wayPointIndex start " + _wayPointIndex);
    }
 
    void Update()
    {
        Debug.Log("Lenght " + Waypoints.Points.Length);
        Debug.Log("_wayPointIndex " + _wayPointIndex);
        if (_wayPointIndex == 0)
        {
            StartMove();
        }
        else
        {
            StartMoveByCircle();
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

    void GetNextWayPoint()
    {
        if (_wayPointIndex >= Waypoints.Points.Length - 1)
        {
            StartMoveByCircle();
            //Destroy(gameObject);
            //return;
        }
        _wayPointIndex++;
        _target = Waypoints.Points[_wayPointIndex];
    }

    void StartMoveByCircle()
    {
        //WaveSpawner.enemiesAlive--;
        //Destroy(gameObject);
        posX = Mathf.Cos(angle) * _radius;
        posY = Mathf.Sin(angle) * _radius;
        //posZ = _target.position.y;

        transform.position = new Vector3(posX, 0, posY) + new Vector3(_target.position.x, _target.position.y, _target.position.z);
        angle += Time.deltaTime * _speed * 0.5f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
