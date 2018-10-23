using UnityEngine;

/// <summary>
/// Serches for target by turning to the left
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Actions/Search Left")]
public class SearchLeftAction : StateMachineAction
{
    /// <summary>
    /// Turn to the left action
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

    public void TurnLeft(TurretStateController controller)
    {
        controller.transform.Rotate(0, -controller.turretStats.serachingTurnSpeed * Time.deltaTime, 0);
    }
}
