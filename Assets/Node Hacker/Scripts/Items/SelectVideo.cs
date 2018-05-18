using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SelectVideo : MonoBehaviour {
    public VideoClip videoClip;
    public VideoPlayer videoPlayer;
    public AudioSource videoAudioSource;
    public List<string> acceptableTags;

    private AudioSource interractionAudioSource;

    private void Awake() {
        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
        interractionAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if ((acceptableTags.Contains(other.tag) || other.gameObject.layer == LayerMask.NameToLayer("Projectile")) && videoClip != null && videoPlayer != null) {
            interractionAudioSource.Play();
            if(videoPlayer.clip != null && videoPlayer.clip.name == videoClip.name) {
                if (videoPlayer.isPlaying) {
                    videoPlayer.Pause();
                } else {
                    videoPlayer.Play();
                }
            } else {
                if (videoPlayer.isPlaying) videoPlayer.Pause();
                videoPlayer.clip = videoClip;
                videoPlayer.SetTargetAudioSource(0, videoAudioSource);
                videoPlayer.Play();
            }
        }
    }
}
