using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroCube : MonoBehaviour {
    public List<string> acceptableTags;
    public VideoPlayer introVideoPlayer;
    public GameObject interroBangCube;
    public GameObject introCube;

    private void Awake() {
        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if ((acceptableTags.Contains(collision.gameObject.tag) || collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))) {
            if (interroBangCube.activeInHierarchy) {
                interroBangCube.SetActive(false);
                introCube.SetActive(true);
                introVideoPlayer.Play();
            } else {
                if(introVideoPlayer.isPlaying) {
                    introVideoPlayer.Pause();
                } else {
                    introVideoPlayer.Play();
                }
            }
        }
    }
}
