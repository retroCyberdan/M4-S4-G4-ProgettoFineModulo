using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    public Vector3 _startingPosition;
    public Vector3 _finalPosition;
    public float _speed = 2f;

    private bool _start2final = true;

    void Update()
    {
        Vector3 target = _start2final ? _finalPosition : _startingPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
            _start2final = !_start2final;
    }
}
