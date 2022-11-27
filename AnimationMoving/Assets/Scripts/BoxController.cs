using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private static bool _isTap = false;

    private void OnMouseDown()
    {
        _isTap = true;
    }

    public static bool IsTap
    {
        get { return _isTap; }
    }
}
