using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public GameObject projectile;
    private float health = 150;
    private float projectileSpeed = 10;
    private float shotsPerSecond = 0.5f;
    public int scoreValue = 100;
    private ScoreTracker st;

    public AudioClip fireSound;
    public AudioClip deathSound;

    void Start() {
        st = GameObject.Find("Score").GetComponent<ScoreTracker>();

    }

    void OnTriggerEnter2D(Collider2D collider) {

        Projectile lazer = collider.gameObject.GetComponent<Projectile>();

        if (lazer) {
            health -= lazer.getDamage();
            lazer.Hit();
            if (health <= 0) { // Destroy Enemy
                Die();
            }
        }
    }

    void Die() {
        Destroy(gameObject);
        st.Score(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }


    void Update() {
        float prob = Time.deltaTime * shotsPerSecond;

        if (Random.value < prob)
            fire();
    }


    void fire() {
        GameObject enemyLazer = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity) as GameObject;
        enemyLazer.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}