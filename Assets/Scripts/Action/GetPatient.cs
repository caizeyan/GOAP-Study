
public class GetPatient:GotoTargetAction
{
    public  GetPatient(IAgent agent): base("WaitingPatient", agent, 1, "")
    {
        AddPreCondition(CreateHelper.State(StateType.GotoWaitingRoom));
        AddEffectCondition(CreateHelper.State(StateType.HavePatient));
    }

    protected override void Prepare()
    {
        targetGo = GWorld.Instance.GetPatient();
        if (targetGo == null)
        {
            return;
        }
        base.Prepare();
    }

    protected override void Finish()
    {
    }
}
