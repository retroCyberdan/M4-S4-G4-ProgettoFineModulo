using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private GroundChecker _groundChecker;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_groundChecker == null) _groundChecker = GetComponentInChildren<GroundChecker>(); // <- se non e`associata, assegno la componente al primo Child
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _groundChecker.IsGrounded)
        {
            _rb.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange); // <- salto solo se tocco terra
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        // acquisisco gli input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0f || v != 0f) // <- gestisco la fisica al variare di "h" o "v"
        {
            Vector3 direction = new Vector3(h, 0, v); // <- creo un vettore direzione

            if (direction.sqrMagnitude > 0.05f)
            {
                direction.Normalize(); // <- quindi la normalizzo

                //transform.forward = direction; // <- ruoto il personaggio nella direzione dove sto andando in modo smooth

                //altro modo per eseguire un cambio di direzione smooth
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Quaternion smoothRotation = Quaternion.Slerp(_rb.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                _rb.MoveRotation(smoothRotation);

                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Time.deltaTime, 0f); // <- utilizzo RotateTowards per eseguire un cambio di direzione smooth
                //transform.rotation = Quaternion.LookRotation(newDirection);

                _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime)); // <- eseguo il movimento tramite MovePosition()
            }
        }
    }
}
