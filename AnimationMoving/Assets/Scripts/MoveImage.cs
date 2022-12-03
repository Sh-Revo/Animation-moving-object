using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _speed = 10f;
    private int _wayPointImageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartMoveImage();
    }

    void StartMoveImage()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f)
        {
            _speed = 0;
            _wayPointImageIndex = 1;
            Destroy(gameObject);
        }
    }
}
