using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public GameObject projectile;
    private float health = 150;

    void OnTriggerEnter2D(Collider2D collider) {

        Projectile lazer = collider.gameObject.GetComponent<Projectile>();

        if (lazer) {
            health -= lazer.getDamage();
            lazer.Hit();
            Debug.Log(collider);
            if (health <= 0) // Destroy Enemy
                Destroy(gameObject);
        }
    }


    void Update() {

        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);


    }
}