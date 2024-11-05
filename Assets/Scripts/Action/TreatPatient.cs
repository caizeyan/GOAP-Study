using UnityEngine;

public class TreatPatient:GotoTargetAction
{
    public  TreatPatient(IAgent agent): base("WaitingPatient", agent, 1, "Cubicle")
    {
        AddPreCondition(CreateHelper.State(StateType.HavePatient));
        AddPreCondition(CreateHelper.State(StateType.CubicleNum));
        AddEffectCondition(CreateHelper.State(StateType.TreatPatient));
    }

    protected override void Prepare()
    {
        targetGo = GWorld.Instance.GetCubicle();
        if (targetGo == null)
        {
            return;
        }
        agent.resources["Patient"].GetComponent<IAgent>().resources.Add("Cubicle",targetGo);
        base.Prepare();
    }

    protected override void Finish()
    {
        GWorld.Instance.ModifyState(CreateHelper.State(StateType.TreatPatientNum));
        GWorld.Instance.AddCubicle(targetGo);
    }
}
