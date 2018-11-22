using UnityEngine;

/// <summary>
/// Abstract Class For Desions
/// </summary>
public abstract class SMDecision : ScriptableObject
{

    public abstract bool Decide(StateController controller);
}
