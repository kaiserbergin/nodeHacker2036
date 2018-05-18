using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioClip[] bgMusic;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (!musicSource.isPlaying) {
            PlayRandomizedBGMusic();
        }
    }

    public void PlayRandomizedBGMusic() {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, bgMusic.Length);
        if (musicSource.isPlaying) {
            musicSource.Stop();
        }
        //Set the clip to the clip at our randomly chosen index.
        musicSource.clip = bgMusic[randomIndex];

        //Play the clip.
        musicSource.Play();
    }
}
