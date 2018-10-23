using UnityEngine;

/// <summary>
/// Turret to focus on the target action
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Actions/Focus On Target")]
public class FocusOnTargetActions : StateMachineAction {
    
    /// <summary>
    /// Turret to focus on the target
    /// </summary>
    /// <param name="controller">Controller that contains the target</param>
    public override void Act(StateController controller)
    {
        if (controller is TurretStateController)
        {
            Focus(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
        }
    }

    /// <summary>
    /// Focus action
    /// </summary>
    /// <param name="controller">Controller that contains the target</param>
    public void Focus(TurretStateController controller)
    {
        controller.Focus();
    }
}
