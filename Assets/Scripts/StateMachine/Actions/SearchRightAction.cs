using UnityEngine;

/// <summary>
/// Serches for target by turning to the right
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Actions/Search Right")]
public class SearchRightAction : StateMachineAction
{
    /// <summary>
    /// Turn to the right action
    /// </summary>
    public override void Act(StateController controller)
    {
        if (controller is TurretStateController)
        {
            TurnRight(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
        }
    }


	/// <summary>
	/// Turn To The Right Action
	/// </summary>
	/// <param name="controller"></param>
    public void TurnRight(TurretStateController controller)
    {
        controller.transform.Rotate(0, controller.turretStats.serachingTurnSpeed * Time.deltaTime, 0);
    }

}
