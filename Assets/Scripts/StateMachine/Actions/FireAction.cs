using UnityEngine;

/// <summary>
/// Fire at teh target
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Actions/Fire Action")]
public class FireAction : StateMachineAction
{
    /// <summary>
    /// Fire at target
    /// </summary>
    /// <param name="controller">Controller that contains the target</param>
    public override void Act(StateController controller)
    {
        if (controller is TurretStateController)
        {
            Fire(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
        }
    }

    /// <summary>
    /// Fire action
    /// </summary>
    /// <param name="controller">Controller that contains the target</param>
    public void Fire(TurretStateController controller)
    {
		controller.Fire();
	}
}
