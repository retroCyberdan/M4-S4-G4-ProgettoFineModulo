using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public bool pushPlayer = true;
    public int damage = 1;
    public Vector2 pushForce = new Vector2(2, 2);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pushPlayer)
                other.GetComponent<Rigidbody2D>().AddForce(pushForce, ForceMode2D.Impulse);

            other.GetComponent<LifeController>().TakeDamage(damage);
        }
    }
}
