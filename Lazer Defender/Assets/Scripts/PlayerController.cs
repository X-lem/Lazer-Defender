using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject lazerPrefab;
    float playerSpeed = 15.0f;
    float playerHealth = 300f;
    float lazerSpeed = 1000f;
    float fireingRate = 0.3f;
    float xMax;
    float xMin;
    float yMax;
    public float padding = 0.7f;
    public AudioClip fireSound;


    // Use this for initialization
    void Start() {

        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance));
        Vector3 topMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, zDistance));

        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
        yMax = topMost.y;
    }

    // Update is called once per frame
    void Update() {

        MoveShip();
        Shoot();
    }


    void MoveShip() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        // Restrict the X movement of the spaceship
        float xPosition = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void Shoot() {

        if(Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("fire", 0.000001f, fireingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("fire");
        }

    }

    void fire() {
        GameObject lazer = Instantiate(lazerPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.identity) as GameObject;
        lazer.rigidbody2D.velocity = new Vector3(0, lazerSpeed * Time.deltaTime, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider) {

        Projectile lazer = collider.gameObject.GetComponent<Projectile>();

        if (lazer) {
            playerHealth -= lazer.getDamage();
            lazer.Hit();
            Debug.Log(collider);
            if (playerHealth <= 0) {// Destroy Player
                Die();
            }
        }
    }

    void Die() {
        Debug.Log("Die Method Called");
        // Load new level
        LevelManager lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        lm.LoadLevel("Win");
        Destroy(gameObject);

    }
}