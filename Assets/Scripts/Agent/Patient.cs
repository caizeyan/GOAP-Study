using System.Collections.Generic;

public class Patient: IAgent
{
    protected override void InitActions()
    {
        List<IAction> list = new List<IAction>();
        actions.Add(CreateHelper.HospitalAction(this));
        actions.Add(CreateHelper.DoorAction(this));
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Patient");
        goal.AddStation(StateType.GotoHospital);
        goals.Add(goal);
    }
}
