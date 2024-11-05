using UnityEngine;

public class WaitingPatient:GotoTargetAction
{
    public  WaitingPatient(IAgent agent): base("WaitingPatient", agent, 1, "WaitingArea")
    {
        AddPreCondition(CreateHelper.State(StateType.PatientNum));
        AddEffectCondition(CreateHelper.State(StateType.GotoWaitingRoom));
        AddEffectCondition(CreateHelper.State(StateType.GotoWaitingRoom));
    }

    protected override void Finish()
    {
    }
}
