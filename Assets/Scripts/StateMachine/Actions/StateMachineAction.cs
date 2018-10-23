using UnityEngine;

/// <summary>
/// Abstarct class for Actions a state machine and perform
/// </summary>
public abstract class StateMachineAction : ScriptableObject {

    /// <summary>
    /// Thresholde when to start searching to the left
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    public abstract void Act(StateController controller);
}
