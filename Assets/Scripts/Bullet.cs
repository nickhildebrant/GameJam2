using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject hitEffect;

    private void OnCollisionEnter(Collision collision) {
        Instantiate(hitEffect, transform.position, transform.rotation);
        var otherHealth = collision.gameObject.GetComponent<Hitpoints>();
        if (otherHealth != null) {
            otherHealth.TakeDamage(damage);
        }
        Destroy(transform.parent.gameObject);
    }
}
