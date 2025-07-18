using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    [SerializeField] private Vector2 _turn;
    [SerializeField] private float _sensitivity = .5f;
    [SerializeField] private Vector3 _deltaMove;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _mover;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _turn.x += Input.GetAxis("Mouse X") * _sensitivity;
        _turn.y += Input.GetAxis("Mouse Y") * _sensitivity;

        _mover.transform.localRotation = Quaternion.Euler(0, _turn.x, 0);
        transform.localRotation = Quaternion.Euler(-_turn.y, 0, 0);

        _deltaMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed * Time.deltaTime;
    }
}