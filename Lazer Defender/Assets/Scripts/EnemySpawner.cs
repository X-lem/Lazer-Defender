using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;


	// Use this for initialization
	void Start () {



        //foreach (Transform child in transform) {
            // Keeping the GameObjects orderly in the Unity UI
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            enemy.transform.parent = transform;
        //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
