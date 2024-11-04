using System.Collections.Generic;

public class Patient: IAgent
{
    protected override void InitActions()
    {
        var gotoHospital = new GotoTargetAction("Go To Hp", this, 1, "WaitingArea");
        gotoHospital.SetEffectCondition(new List<WorldState>(){ new WorldState("Hp",1)});

        var gotoDoor = new GotoTargetAction("Go To Door", this, 1, "Door");
        gotoDoor.SetPreCondition(new List<WorldState>(){ new WorldState("Hp",1)});
        gotoDoor.SetEffectCondition(new List<WorldState>(){ new WorldState("GoToDoor",1)});
        actions.Add(gotoHospital);
        actions.Add(gotoDoor);
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Go To Door");
        goal.AddStation("GoToDoor",1);
        goals.Add(goal);
    }
}
