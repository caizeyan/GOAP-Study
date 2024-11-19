using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("This is My Log")]
    [TaskIcon("{SkinColor}LogIcon.png")]
    public class MyLog: Action
    {
        public SharedString sharedString;
        public SharedString sharedString2;
        public string publicStr;
        private string privString;

        public override void OnAwake()
        {
            privString = "privy";
        }

        public override TaskStatus OnUpdate()
        {
            Debug.Log($"{sharedString},{publicStr},{privString},{sharedString2}");
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            sharedString = "";
            sharedString2 = "";
            privString = "";
            privString = "";
        }
    }
}