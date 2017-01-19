using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float movementSpeed = 5.0f;
    public float width = 10f;
    public float hight = 5f;
    public float padding = 0.2f;
    float xMax;
    float xMin;
    bool isMovingRight = false;

    // Use this for initialization
    void Start () {

        foreach (Transform child in transform) {
            // Keeping the GameObjects orderly in the Unity UI
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }

        // Get window position
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance));

        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
    }


    public void OnDrawGizmos() {

        Gizmos.DrawWireCube(transform.position, new Vector3(width, hight, 0));
    }
	
	// Update is called once per frame
	void Update () {

        moveFormation();
	}

    void moveFormation() {

        if (isMovingRight)
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        else
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        float rEdgeFormation = transform.position.x + (0.5f * width);
        float lEdgeFormation = transform.position.x - (0.5f * width);

        if (lEdgeFormation < xMin || rEdgeFormation > xMax)
            isMovingRight = !isMovingRight;
    }
}
