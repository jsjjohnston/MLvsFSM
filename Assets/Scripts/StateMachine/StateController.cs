using UnityEngine;

/// <summary>
/// Abstarct class to control states
/// </summary>
public abstract class StateController : MonoBehaviour {

    /// <summary>
    /// current state the state machine is set to
    /// </summary>
    public State currentState;

    /// <summary>
    /// 
    /// </summary>
    [HideInInspector] public State previousState;

    /// <summary>
    /// Enable or disable AI
    /// </summary>
    public bool aiActive;

    /// <summary>
    /// If AI enabled update the state
    /// </summary>
    protected virtual void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState (this);
    }

    /// <summary>
    /// Change to new state
    /// </summary>
    /// <param name="nextState">new state to change into</param>
    public void TransitionToState(State nextState)
    {
        if (nextState != null)
        {
            previousState = currentState;
            currentState = nextState;
        }
    }
}
