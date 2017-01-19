using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float health = 150;

    void OnTriggerEnter2D(Collider2D collider) {

        Projectile lazer = collider.gameObject.GetComponent<Projectile>();

        if (lazer) {
            health -= lazer.getDamage();
            lazer.Hit();
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
