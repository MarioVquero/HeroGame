using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    [SerializeField] private bool isEnemy;

    [SerializeField] private int score;

    public GameManagerScript GMscript;

    // Start is called before the first frame update
    void Start()
    {
        GMscript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AOE"))
        {
            if (!isEnemy)
            {
                GMscript.score += score;
                Destroy(gameObject);
            }
            else
            {
                GMscript.score -= score;
                Destroy(gameObject);
            }
            
        }

    }
}
