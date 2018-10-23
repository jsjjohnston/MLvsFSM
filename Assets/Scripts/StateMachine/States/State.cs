using UnityEngine;

/// <summary>
/// A state an agent can be in
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/State")]
public class State : ScriptableObject {

    /// <summary>
    /// Actions to perfrom in the state
    /// </summary>
    public StateMachineAction[] actions;

    /// <summary>
    /// Transitions that can change the state
    /// </summary>
    public Transition[] transitions;

    /// <summary>
    /// Colour of the gizmo
    /// </summary>
    public Color sceneGizmoColour = Color.gray;

    /// <summary>
    /// Update the sate
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    public void UpdateState(StateController controller)
    {
        DoActions(controller); // Do all Actions asociated with the state
        CheckTransitions(controller); // Decided if transition to new state is required
    }

    /// <summary>
    /// Do all actions asociated with the state
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    private void DoActions(StateController controller)
    {
        foreach (var action in actions)
        {
            action.Act(controller); // Perform action
        }
    }

    /// <summary>
    /// Check all transitions to decided to change state
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    private void CheckTransitions(StateController controller)
    {
        foreach (var transition in transitions)
        {
            bool decisionScceeded = transition.decision.Decide(controller); // Made Decision

            if (decisionScceeded)
                controller.TransitionToState(transition.trueState); // Set controller state to true state
            else
                controller.TransitionToState(transition.falseState); // Set controller state to false state
        }
    }
}
