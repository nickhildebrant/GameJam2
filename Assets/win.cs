using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        SceneManager.LoadScene("Intro");
    }
}
