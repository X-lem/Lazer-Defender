using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 15.0f;
    float xMax;
    float xMin;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        MoveShip();
    }


    void MoveShip() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        }

        float xPosition = Mathf.Clamp(transform.position.x, xMin, xMax);

        transform.position = new Vector3(xPosition, transform.position.x, transform.position.y);
    }
}