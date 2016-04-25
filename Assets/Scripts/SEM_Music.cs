using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEM_Music : MonoBehaviour
{

    public List<AudioClip> Tracks;
    public AudioSource MusicPlayer;
   

	// Use this for initialization
	void Start ()
	{

	    int randomT = Random.Range(0, Tracks.Count - 1);

	    MusicPlayer.clip = Tracks[randomT];

	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (MusicPlayer.isPlaying)
	        return;

        int randomT = Random.Range(0, Tracks.Count - 1);

        while(MusicPlayer.clip != Tracks[randomT])
            randomT = Random.Range(0, Tracks.Count - 1);

        MusicPlayer.clip = Tracks[randomT];
	    MusicPlayer.Play();

	}
}
