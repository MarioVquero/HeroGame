using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public float gameTimer;
    public TMP_Text Timertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        float seconds = Mathf.FloorToInt(gameTimer % 60);
        Timertext.text = string.Format("Timer: {0:00}", seconds);
    
    }
}
