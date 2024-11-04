using System.Collections.Generic;

public class Patient: IAgent
{
    protected override void InitActions()
    {
        var gotoHospital = new GotoTargetAction("GoToHp", this, 1, "WaitingArea");
        gotoHospital.AddPreCondition(ConditionHelper.GoToDoor());
        gotoHospital.AddEffectCondition(ConditionHelper.GoToHospital());

        var gotoDoor = new GotoTargetAction("GoToDoor", this, 1, "Door");
        gotoDoor.AddEffectCondition(ConditionHelper.GoToDoor());
        actions.Add(gotoHospital);
        actions.Add(gotoDoor);
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Go To Door");
        goal.AddStation(ConditionHelper.GoToHospital());
        goals.Add(goal);
    }
}
