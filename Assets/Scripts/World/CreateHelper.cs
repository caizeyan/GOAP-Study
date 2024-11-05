public enum StateType
{
    GotoWaitingRoom,
    GotoDoor,
    GoHome,
    PatientNum,
    CubicleNum,
    HavePatient,
    TreatPatientNum,
    TreatPatient,
    Treated,
}

public static class CreateHelper
{
    public static WorldState State(StateType type)
    {
        return new (type.ToString(), 1);
    }
    
    public static WorldState State(StateType type, int num)
    {
        return new (type.ToString(), num);
    }

 
}
