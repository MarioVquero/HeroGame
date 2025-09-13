using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState<Estate> where Estate : Enum
{
    public BaseState(Estate key)
    {
        StateKey = key;
    }

    public Estate StateKey{ get; private set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void Updatestate();
    public abstract Estate GetNextState();

    public abstract float CurrentState();


}
