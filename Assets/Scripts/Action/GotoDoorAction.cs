public class GotoDoorAction:GotoTargetAction
{
    public  GotoDoorAction(IAgent agent): base("GoToDoor", agent, 1, "Door")
    {
        AddEffectCondition(CreateHelper.State(StateType.GotoDoor));
    }
}
