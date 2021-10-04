using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hitpoints : MonoBehaviour
{
    public int health = 100;
    public int damageTaken = 5;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.transform.parent.gameObject != null && collision.gameObject.transform.parent.gameObject.tag == "Zombie") {
            TakeDamage(damageTaken);
            GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Text>().text = "Health: " + health;
        }

        if(collision.gameObject.tag == "Explosion") {
            TakeDamage(50);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            if (gameObject.tag != "Player") Destroy(gameObject);
            else SceneManager.LoadScene("Intro");
        }
    }
}
