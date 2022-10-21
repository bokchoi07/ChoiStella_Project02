using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => currentState;
    protected bool InTransition { get; private set; }

    State currentState;
    protected State previousState;

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();
        if(targetState == null)
        {
            Debug.LogWarning("cannot change to state, as it doesn't exist on State Machine object." +
                            " make sure you have desired State attached to State Machine!");
            return;
        }

        //else, we found our state!
        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if(previousState != null)
        {
            InitiateStateChange(previousState);
        }
    }

    void InitiateStateChange(State targetState)
    {
        // if our new state is different and we're not transitioning, do it
        if(currentState != targetState && !InTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        // start transition
        InTransition = true;
        // transitioning
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        // end transition
        InTransition = false;
    }

    private void Update()
    {
        if(CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}
