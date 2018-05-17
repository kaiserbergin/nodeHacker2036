using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Exit : MonoBehaviour {
    public List<string> acceptableTags;

    private Text exitMessage;
    [SerializeField]
    private bool unlocked;

    [TextArea]
    public string unlockedMessage;

    [SerializeField]
    private SteamVR_LoadLevel levelLoader;

    private void Awake() {
        MiniGameManager.OnMiniGameSolved += MiniGameSolved;

        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
    }
    private void Start() {
        exitMessage = gameObject.GetComponentInChildren<Text>();
    }

    private void MiniGameSolved(object sender, OnSolvedEvent onSolvedEvent) {
        exitMessage.text = unlockedMessage;
        unlocked = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (unlocked && acceptableTags.Contains(other.gameObject.tag)) {
            levelLoader.Trigger();
        }
    }
}
