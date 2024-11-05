using UnityEngine;

public class GotoCubicle:GotoTargetAction
{
    public  GotoCubicle(IAgent agent): base("GoToDoor", agent, 1, "Door")
    {
        AddEffectCondition(CreateHelper.State(StateType.Treated));
        AddEffectCondition(CreateHelper.State(StateType.Treated));
    }

    protected override void Prepare()
    {
        GameObject go;
        agent.resources.TryGetValue("Cubicle", out go);
        targetGo = go;
        if (targetGo == null)
        {
            return;
        }
        base.Prepare();
    }
}