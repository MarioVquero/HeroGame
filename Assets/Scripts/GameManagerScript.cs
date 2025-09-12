using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public GameObject timerStartPoint; //Trigger to start timer

    [SerializeField] public float gameTimer;
    public TMP_Text Timertext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStartPoint.GetComponent<TimerStarter>().timerStart) //Starts the timer when player triggers timerStartPoint
        {
            gameTimer += Time.deltaTime;

            float minutes = Mathf.FloorToInt(gameTimer / 60);
            float seconds = Mathf.FloorToInt(gameTimer % 60);
            Timertext.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
        }
    }
}
