using System.Collections.Generic;

public class Nurse: IAgent
{
    protected override void InitActions()
    {
        actions.Add(new WaitingPatient(this));
        actions.Add(new GetPatient(this));
    }

    protected override void InitGoals()
    {
        Goal goal = new Goal("Patient");
        goal.AddStation(StateType.HavePatient);
        goals.Add(goal);
    }
}
