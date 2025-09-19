using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject timerStartPoint; //Trigger to start timer
    [SerializeField] private UIManager uIManager;

    public TimerStarter timerStarter;

    public int score = 100;

    [SerializeField] public float gameTimer;
    public TMP_Text Timertext;
    public TMP_Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {


        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timerStarter.timerStart == true) //Starts the timer when player triggers timerStartPoint
        {
            gameTimer += Time.deltaTime;

            float minutes = Mathf.FloorToInt(gameTimer / 60);
            float seconds = Mathf.FloorToInt(gameTimer % 60);

            if (seconds >= 30)
            {
                uIManager.Pause();
            }

            // Debug.Log(minutes + " " + seconds);
            ScoreText.text = $"Score: {score}";//score.ToString();
            Timertext.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);

        }
    }
}
