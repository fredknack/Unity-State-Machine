using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IState currentlyRuningState;
    private IState previousState;

    public void ChangeState(IState newState)
    {
        if(currentlyRuningState != null)
            this.currentlyRuningState.Exit();
        
        this.previousState = this.currentlyRuningState;
        this.currentlyRuningState = newState;

        this.currentlyRuningState.Enter();
    }

    public void ExecuteStateUpdate()
    {
        var runningState = this.currentlyRuningState;
        if(runningState != null)
            runningState.Execute();
    }

    public void SwitchToPreviousState(){
        this.currentlyRuningState.Exit();
        this.currentlyRuningState = this.previousState;
        this.currentlyRuningState.Enter();
    }
}
