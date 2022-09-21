using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Flow", "JD_handleEnding", "handle game ending")]

public class handleEnding : Command
{
    public Flowchart flowchart;

    public override void OnEnter()
    {
        float finalResponseScore = flowchart.GetFloatVariable("responseScore");

        if (finalResponseScore is < 0.3f and > -0.3f)
        {
            // this should send the ambivalent ending
            flowchart.SendFungusMessage("ambivalent");
        }
        else if (finalResponseScore > 0.3f)
        {
            // this should send the rebellious ending
            flowchart.SendFungusMessage("rebellious");
        }
        else if (finalResponseScore < -0.3f)
        {
            // this should send the society cohesion ending
            flowchart.SendFungusMessage("cohesion");
        }

        StopParentBlock();
    }
}