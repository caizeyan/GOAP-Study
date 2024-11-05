using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldStateDisplay : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        string str = "";
        foreach (var pair in  GWorld.Instance.GetStates())
        {
            str += pair.Key + "," + pair.Value+"/n";
        }

        text.text = str;
    }
}
