using UnityEngine;
/// <summary>
/// Check if target is dead
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Decisions/Is Target Dead")]
public class IsTargetDeadDecision : Decision
{
    /// <summary>
    /// Decided if target is dead
    /// </summary>
    /// <param name="controller">State controller that containes the target</param>
    /// <returns>True if target is dead, False if target is still alive</returns>
    public override bool Decide(StateController controller)
    {
        bool isTargetDead;

        if (controller is TurretStateController)
        {
            isTargetDead = CheckTargetDead(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
            isTargetDead = false;
        }

        return isTargetDead;
    }

    /// <summary>
    /// Check if the target is dead
    /// </summary>
    /// <param name="controller">Instance of the turret controller</param>
    /// <returns>True if target is dead False if target is alive</returns>
    private bool CheckTargetDead(TurretStateController controller)
    {
        bool dead = !controller.target.gameObject.activeSelf;
        if (dead)
        {
            controller.DoNotFocus();
        }
        return dead;

    }
}
