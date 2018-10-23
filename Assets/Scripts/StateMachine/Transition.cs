/// <summary>
/// Manages tranistion data
/// </summary>
[System.Serializable]
public class Transition
{
    public Decision decision;   // The decision to be made
    public State trueState;     // The state to change into if the decision returns true
    public State falseState;    // The state to change into if the decision returns false
}
