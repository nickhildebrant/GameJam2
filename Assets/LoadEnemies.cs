using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject enemies;

    [SerializeField] private GameObject deLoad;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            enemies.SetActive(true);
            //if(deLoad != null) enemies.SetActive(false);
        }
    }
}
