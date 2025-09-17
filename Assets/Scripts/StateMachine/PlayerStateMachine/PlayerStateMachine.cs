using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateManager<PlayerState>
{

    [Header("Player Components")]
    [SerializeField] private Transform playerTransform;


    [Header("Flight Variables")]
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float maxFlightHeight;
    [SerializeField] private float minFlightHeight;


    public Camera freeLookCam;
    private float currHeight;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // states.Add(PlayerState.fly, new PlayerFlyState(this.PlayerState.fly));

        // set iniial state
        // currentState = states[];
    }


}
