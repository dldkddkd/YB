using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip[] audio = new AudioClip[5];
	public AudioSource soundSource;
	public AudioClip c;
	public int i;
	// Use this for initialization
	void Start () {
		soundSource = GetComponent<AudioSource> ();
		StartCoroutine ("Playlist");
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		c = audio[i];
	}
	IEnumerator Playlist(){
		soundSource.clip = audio [i];
		soundSource.Play ();
		while (true) {
			yield return new WaitForSeconds (1.0f);
			if (!soundSource.isPlaying) {
				if (i < 4)
					i++;
				else
					i = 0;
				soundSource.clip = audio [i];
				soundSource.Play ();
			}
		}
	}
}
