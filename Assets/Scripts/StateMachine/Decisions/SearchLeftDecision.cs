using UnityEngine;

/// <summary>
/// Decide when to start searching to the left
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Decisions/Search Left Decision")]
public class SearchLeftDecision : Decision
{
    /// <summary>
    /// Threshold when to start searching to the left
    /// </summary>
    [Range(0, 178)]
    public float rotationThreshold = 90f;

    /// <summary>
    /// Decided if to start searching to the left
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    public override bool Decide(StateController controller)
    {
        bool thresholdReached = false;
        if (controller is TurretStateController)
        {
            thresholdReached = SearchLeft(controller as TurretStateController);
        }
        else
        {
            return false;
        }
        return thresholdReached;
    }

    /// <summary>
    /// Check if search threshold has been met
    /// </summary>
    /// <param name="controller">Instance of the state machine</param>
    /// <returns>Returns true if threshold met and false if not</returns>
    public bool SearchLeft(TurretStateController controller)
    {
        // Get curret inspector angle 
        float angleY = UnityEditor.TransformUtils.GetInspectorRotation(controller.transform).y;

        if (angleY >= rotationThreshold)
        {
            controller.DoNotFocus();
            return true;
        }
        else
            return false;
    }
}
