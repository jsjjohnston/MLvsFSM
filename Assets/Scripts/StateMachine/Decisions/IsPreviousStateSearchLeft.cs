using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/Is Previous State Search Left")]
public class IsPreviousStateSearchLeft : SMDecision
{
    public State SearchLeft;
    public override bool Decide(StateController controller)
    {
        if (controller.previousState == SearchLeft)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
