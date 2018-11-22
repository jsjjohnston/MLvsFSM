using UnityEngine;

/// <summary>
/// Decided If Target IS Found
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Decisions/Find Target")]
public class FindTargetDecision : SMDecision
{
	/// <summary>
	/// Decide If Target is found
	/// </summary>
	/// <param name="controller"></param>
	/// <returns>Ture If Target Is Found</returns>
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

	/// <summary>
	/// Look For Target
	/// </summary>
	/// <param name="controller"></param>
	/// <returns>True If Found</returns>
    private bool Look(TurretStateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.projectilePoint.position, controller.projectilePoint.forward.normalized * controller.turretStats.lookRange, Color.black);

		bool sphereCastHit = Physics.SphereCast(controller.projectilePoint.position, 
			controller.turretStats.lookSphereCastRadius, 
			controller.projectilePoint.forward, 
			out hit, 
			controller.turretStats.lookRange);

		bool isPlayerTag = false;

		if (sphereCastHit)
		{
			isPlayerTag = hit.collider.CompareTag("Player");
		}
		
		if (sphereCastHit && isPlayerTag)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
