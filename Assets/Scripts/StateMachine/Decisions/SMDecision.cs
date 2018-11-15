using UnityEngine;

public abstract class SMDecision : ScriptableObject
{

    public abstract bool Decide(StateController controller);
}
