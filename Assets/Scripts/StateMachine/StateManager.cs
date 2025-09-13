using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class StateManager<Estate> : MonoBehaviour where Estate : Enum
{
    protected Dictionary<Estate, BaseState<Estate>> states = new Dictionary<Estate, BaseState<Estate>>();

    protected BaseState<Estate> currentState;

    protected bool isTransitioning = false;

    void Start()
    {
        currentState.EnterState();
    }

    void Update()
    {
        Estate nextStateKey = currentState.GetNextState();

        if (!isTransitioning && nextStateKey.Equals(currentState.StateKey))
        {
            currentState.Updatestate();

        }
        else if(!isTransitioning)
        {
            TransitionToState(nextStateKey);

        }
    }

    public void TransitionToState(Estate stateKey)
    {
        isTransitioning = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioning = false;
    }

}
