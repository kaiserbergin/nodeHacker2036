using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SelectVideo : MonoBehaviour {
    public VideoClip videoClip;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public List<string> acceptableTags;

    private void Awake() {
        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (acceptableTags.Contains(other.tag) && videoClip != null && videoPlayer != null) {
            if(videoPlayer.clip != null && videoPlayer.clip.name == videoClip.name) {
                if (videoPlayer.isPlaying) {
                    videoPlayer.Pause();
                } else {
                    videoPlayer.Play();
                }
            } else {
                if (videoPlayer.isPlaying) videoPlayer.Pause();
                videoPlayer.clip = videoClip;
                videoPlayer.SetTargetAudioSource(0, audioSource);
                videoPlayer.Play();
            }
        }
    }
}
