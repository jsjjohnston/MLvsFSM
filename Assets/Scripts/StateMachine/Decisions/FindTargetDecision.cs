using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/Find Target")]
public class FindTargetDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible;

        if (controller is TurretStateController)
        {
            targetVisible = Look(controller as TurretStateController);
        }
        else
        {
            Debug.LogError("Controller is not of type [Turrert State Controller]");
            targetVisible = false;
        }

        return targetVisible;
    }

    private bool Look(TurretStateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.projectilePoint.position, controller.projectilePoint.forward.normalized * controller.turretStats.lookRange, Color.black);

        if (Physics.SphereCast(controller.projectilePoint.position, controller.turretStats.lookSphereCastRadius, controller.projectilePoint.forward, out hit, controller.turretStats.lookRange)
            && hit.collider.CompareTag("Player")
            && controller.target != hit.transform)
        {
            controller.target = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}
