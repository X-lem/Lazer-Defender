using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public GameObject projectile;
    private float health = 150;
    private float projectileSpeed = 10;
    private float shotsPerSecond = 0.5f;

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
        float prob = Time.deltaTime * shotsPerSecond;

        if (Random.value < prob)
            fire();
    }


    void fire() {
        GameObject enemyLazer = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity) as GameObject;
        enemyLazer.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
    }
}