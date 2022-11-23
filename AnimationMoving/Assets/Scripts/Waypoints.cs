using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private static Transform[] _points;

    private void Awake()
    {
        _points = new Transform[transform.childCount];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    public static Transform[] Points
    {
        get { return _points; }
        set { _points = value; }
    }
}
