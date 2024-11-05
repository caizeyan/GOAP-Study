using UnityEngine;

public class GotoHome:GotoTargetAction
{
    public  GotoHome(IAgent agent): base("GoToDoor", agent, 1, "Door")
    {
        AddPreCondition(CreateHelper.State(StateType.Treated));
        AddEffectCondition(CreateHelper.State(StateType.GoHome));
    }
    
}