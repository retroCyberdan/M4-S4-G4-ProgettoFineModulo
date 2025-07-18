using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _platform;

    private Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _platform.transform.position = _pointA.transform.position;
        _targetPosition = _pointB.transform.position;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            while ((_targetPosition - _platform.transform.position).sqrMagnitude > 0.01f)
            {
                _platform.transform.position = Vector3.MoveTowards(_platform.transform.position, _targetPosition, _speed * Time.deltaTime);
                yield return null;
            }

            _targetPosition = _targetPosition == _pointA.transform.position ? _pointB.transform.position : _pointA.transform.position;

            yield return new WaitForSeconds(_delay);
        }
    }
}