using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Flow", "JD_handleChoice", "handle player choices")]

public class handleChoice : Command
{
    public Flowchart flowchart;
    public int choiceScore;

    public override void OnEnter() {
        int choicesMade = flowchart.GetIntegerVariable("choicesMade") + 1;
        float responseScore = (flowchart.GetFloatVariable("responseScore") + choiceScore) / choicesMade;

        flowchart.SetIntegerVariable("choicesMade", choicesMade);
        flowchart.SetFloatVariable("responseScore", responseScore);
        Continue();
    }
}