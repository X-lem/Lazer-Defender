using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 15.0f;
    float xMax;
    float xMin;
    public float padding = 0.2f;


    // Use this for initialization
    void Start() {

        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance));

        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
    }

    // Update is called once per frame
    void Update() {

        MoveShip();
    }


    void MoveShip() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }

        // Restrict the X movement of the spaceship
        float xPosition = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}