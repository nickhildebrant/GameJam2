using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.transform.parent.GetComponent<Hitpoints>() != null) {
            collision.gameObject.transform.parent.GetComponent<Hitpoints>().TakeDamage(50);
        }
    }
}
