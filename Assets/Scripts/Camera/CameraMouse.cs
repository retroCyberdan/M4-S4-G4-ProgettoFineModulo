using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    public Transform target;           // <- il player o oggetto attorno a cui ruotare
    public float distance = 5f;      // <- distanza dal target
    public float xSpeed = 120f;      // <- velocità di rotazione orizzontale
    public float ySpeed = 80f;       // <- velocità di rotazione verticale

    public float yMinLimit = -20f;     // <- limite minimo angolo verticale
    public float yMaxLimit = 80f;      // <- limite massimo angolo verticale

    private float x = 0f;
    private float y = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Blocca il cursore (opzionale)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}