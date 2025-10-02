using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public TimerStarter timerStarter;
    [SerializeField] private GameObject timerStartPoint; //Trigger to start timer
    [SerializeField] private UIManager uIManager;
    [SerializeField] private GameObject EndStatusOBJ;

    public bool hasWon = false;


    public int score = 100;

    [SerializeField] private float gameTimer;
    [SerializeField] private float initialGameTime = 60f;
    public TMP_Text Timertext;
    public TMP_Text ScoreText;
    public TMP_Text EndStatus;

    // Start is called before the first frame update
    void Start()
    {
        EndStatusOBJ.SetActive(false);
        // set initial gametime
        gameTimer = initialGameTime;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (score >= 48)
        {
            hasWon = true;
        }

        if (timerStarter.timerStart == true) //Starts the timer when player triggers timerStartPoint
        {
            gameTimer -= Time.deltaTime;
            Debug.Log(gameTimer);
            float minutes = Mathf.FloorToInt(gameTimer / 60);
            float seconds = Mathf.FloorToInt(gameTimer % 60);

            if (seconds <= 0 || score >=48 )
            {
                EndStatusOBJ.SetActive(true);
                if (hasWon == true && score >= 48)
                {
                    EndStatus.text = "YOU WIN";
                }
                else
                {
                    EndStatus.text = "YOU LOSE";
                }
                uIManager.Pause();
            }

            // Debug.Log(minutes + " " + seconds);
            ScoreText.text = $"Score: {score}";//score.ToString();
            Timertext.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);

        }
    }
}
