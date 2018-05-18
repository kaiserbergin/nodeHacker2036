using System;
using UnityEngine;

public class RollerBall : MonoBehaviour, IMiniGame {
    //Mini Game Objects
    public GameObject gameBoard;
    public Ball ball; 
    public GoalSphere[] goalSpheres;
    public PenaltySphere[] penaltySpheres;
    int goalSpheresCollected;
    public GameObject prizeObject;

    //Event data
    public Guid gameId;
    public IItem prize;
    public int damage;
    public String successMessage = "You Won!";
    public String failureMessage = "You Failed!";

    //Reset variables
    private Vector3 originalBallPostion;
    private Quaternion oringialBallRotation;
    private Vector3 originalGameBoardPosition;
    private Quaternion originalGameBoardRotation;

    //Audio Ques
    public AudioSource ballAudioSource;
    public AudioSource tableAudioSource;
    public AudioClip goalCollectedAudioClip;
    public AudioClip penaltyCollectedAudioClip;
    public AudioClip puzzleSolvedAudioClip;

    private void Awake() {
        gameId = Guid.NewGuid();
        prize = prizeObject.GetComponent<IItem>(); 
    }

    private void Start() {
        originalBallPostion = ball.transform.position;
        oringialBallRotation = ball.transform.rotation;
        originalGameBoardPosition = gameBoard.transform.position;
        originalGameBoardRotation = gameBoard.transform.rotation;
    }

    public void OnGoalSphereCollected() {
        goalSpheresCollected++;
        PlayAudioClip(ballAudioSource, goalCollectedAudioClip);
        if(goalSpheresCollected == goalSpheres.Length) {
            PlayAudioClip(tableAudioSource, puzzleSolvedAudioClip);
            MiniGameManager.instance.MiniGameSolved(gameId, prize, successMessage);
            for (int i = 0; i < penaltySpheres.Length; i++) {
                penaltySpheres[i].gameObject.SetActive(false);
            }
            
        }
    }

    public void OnPenaltySphereCollected() {
        MiniGameManager.instance.MiniGameFailed(gameId, damage, failureMessage);
        goalSpheresCollected = 0;
        PlayAudioClip(ballAudioSource, penaltyCollectedAudioClip);
        for (int i = 0; i < goalSpheres.Length; i++) {
            goalSpheres[i].gameObject.SetActive(true);
        }
        ResetMiniGame();
    }

    private void PlayAudioClip(AudioSource audioSource, AudioClip audioClip) {
        if(audioSource != null && audioClip != null) {
            if (audioSource.clip != null && audioSource.isPlaying) {
                audioSource.Stop();
            }
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void ResetMiniGame() {
        gameBoard.transform.SetParent(null);
        gameBoard.transform.position = originalGameBoardPosition;
        gameBoard.transform.rotation = originalGameBoardRotation;
        ball.transform.position = originalBallPostion;
        ball.transform.rotation = oringialBallRotation;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
