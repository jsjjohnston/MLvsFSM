using UnityEngine;

/// <summary>
/// Decided when to start serching to the right
/// </summary>
[CreateAssetMenu(menuName = "StateMachine/Decisions/Search Right Decision")]
public class SearchRightDecision : Decision {

    /// <summary>
    /// threshold to rotate to teh right
    /// </summary>
    [Range(0, 360)]
    public float rotationThreshold = 90f;

    /// <summary>
    /// Make decision 
    /// </summary>
    public override bool Decide(StateController controller)
    {
        bool thresholdReached = false;
        if (controller is TurretStateController)
        {
            thresholdReached = SearchRight(controller as TurretStateController); // Search right
        }
        else
        {
            return false;
        }
        return thresholdReached; // Return result
    }

    /// <summary>
    /// Actions to perfrom in the state
    /// </summary>
    public bool SearchRight(TurretStateController controller)
    {
        float angle = UnityEditor.TransformUtils.GetInspectorRotation(controller.transform).y; // Get angle in inspector 

        // Return if angle is within threshold
        if (angle <= -rotationThreshold)
        {
            controller.DoNotFocus(); 
            return true;
        }
        else
            return false;
    }
}
