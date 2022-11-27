using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private float arriveTime = 3f;
    Move move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (move.IsMove == false)
        //{
        //    MoveToken();
        //}
        
    }

    void MoveToken()
    {
        Debug.Log("is Move " + move.IsMove);
        if (move.IsMove == false)
        {
            transform.position = Vector3.Lerp(start.position, end.position, Mathf.PingPong(Time.time / arriveTime, 1f));
        }
    }
}
