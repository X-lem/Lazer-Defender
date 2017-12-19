using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = ScoreTracker.score.ToString();
        ScoreTracker.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
