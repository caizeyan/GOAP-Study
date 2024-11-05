using UnityEngine;

public class GotoWaitingRoomAction:GotoTargetAction
{
    public  GotoWaitingRoomAction(IAgent agent): base("GoToWaitingRoom", agent, 1, "WaitingArea")
    {
        AddPreCondition(CreateHelper.State(StateType.GotoDoor));
        AddEffectCondition(CreateHelper.State(StateType.GotoWaitingRoom));
    }

    protected override void Finish()
    {
        GWorld.Instance.AddPatient(this.agent.gameObject);
    }
}
