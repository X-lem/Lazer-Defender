using UnityEngine;
using System;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

    private AudioSource music;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music.GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
		}
		
	}

    void OnLevelWasLoaded(int level) {
        Debug.Log("OnLevelWasLoaded Method Called: " + level);
        music.Stop(); // Stop existing music
        switch (level) {
            case 0:
                music.clip = startClip;
                break;
            case 1:
                music.clip = gameClip;
                break;
            case 2:
                music.clip = endClip;
                break;
            default:
                Debug.Log("Music Level not defined");
                break;
        }

        music.loop = true;
        music.Play();

    }
}
