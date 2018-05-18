using UnityEngine;
using System.Collections;

public class MessageDisplayer : MonoBehaviour {
    public GameObject hmd;

    public GameObject winText;
    public GameObject loseText;

    public float lift;
    public float displayTime;

    private float spawnTime;
    private GameObject displayedText;
    private Vector3 startPosition;
    private bool showMessage;

    private void Awake() {
        MiniGameManager.OnMiniGameSolved += MiniGameSolved;
        MiniGameManager.OnMiniGameFailed += MiniGameFailed;

        startPosition = winText.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (showMessage) {
            if (Time.time - spawnTime >= displayTime) {
                showMessage = false;
                displayedText.SetActive(false);
            }
        }
    }

    private void MiniGameSolved(object sender, OnSolvedEvent onSolvedEvent) {
        spawnTime = Time.time;
        displayedText = winText;
        displayedText.SetActive(true);
    }

    private void MiniGameFailed(object sender, OnFailedEvent onFailedEvent) {
        spawnTime = Time.time;
        displayedText = loseText;
        showMessage = true;
    }

    private void ResetText() {
        displayedText.SetActive(true);
        displayedText.transform.position = startPosition;
    }

    private void SetLookRotation() {
        Vector3 relativePos = hmd.transform.position - displayedText.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        displayedText.transform.rotation = rotation;
    }
}
