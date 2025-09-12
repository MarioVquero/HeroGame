using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStarter : MonoBehaviour
{
    public bool timerStart;

    void Start()
    {
        timerStart = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timerStart = true;
            Debug.Log("Timer tiggered");
        }
    }
}
