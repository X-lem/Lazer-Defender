using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float enemySpeed = 5.0f;
    public float width = 10f;
    public float hight = 5f;
    public float padding = 0f;
    float xMax;
    float xMin;
    bool isMovingRight = false;
    private bool isCoroutineExecuting = false;
    float delayTime = 2f;

    // Use this for initialization
    void Start () {

        SpawnUntilFill();

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
        
        if(allEnemiesDead()) {

            // Create dely before new enemys are spawned
            StartCoroutine(delay(delayTime));
        }
	}


    void SpawnUntilFill() {
        Transform freePosition = NextFreePosition();
        if (freePosition) {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }

        // Spawn enemys at a slow rate
        if (NextFreePosition())
            Invoke("SpawnUntilFill", Random.Range(0.5f, 5.0f));
        
    }

    void moveFormation() {

        if (isMovingRight)
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;
        else
            transform.position += Vector3.left * enemySpeed * Time.deltaTime;

        float rEdgeFormation = transform.position.x + (0.5f * width);
        float lEdgeFormation = transform.position.x - (0.5f * width);

        if (lEdgeFormation < xMin)
            isMovingRight = true;
        else if (rEdgeFormation > xMax)
            isMovingRight = false;

    }


    Transform NextFreePosition() {
        foreach (Transform child in transform) {
            if (child.childCount == 0) {
                return child;
            }
        }
        return null;
    }

    

    // Checks to see if all the enemies are dead
    bool allEnemiesDead() {

        foreach(Transform child in transform) {
            if (child.childCount > 0) {
                return false;
            }
        }
        return true;
    }

    IEnumerator delay(float time) {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        SpawnUntilFill();

        isCoroutineExecuting = false;

    }
}
