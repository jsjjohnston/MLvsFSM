using UnityEngine;

/// <summary>
/// Serches for target by turning to the left
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Actions/Search Left")]
public class SearchLeftAction : StateMachineAction
{
    /// <summary>
    /// Action to Take
    /// </summary>
    public override void Act(StateController controller)
    {
        if (controller is TurretStateController)
        {
            TurnLeft(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
        }
    }

	/// <summary>
	/// Turn Left Action
	/// </summary>
	/// <param name="controller"></param>
    public void TurnLeft(TurretStateController controller)
    {
        controller.transform.Rotate(0, -controller.turretStats.serachingTurnSpeed * Time.deltaTime, 0);
    }
}
