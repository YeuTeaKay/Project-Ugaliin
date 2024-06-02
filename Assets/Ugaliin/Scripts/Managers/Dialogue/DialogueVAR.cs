using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;


public class DialogueVAR
{
    public Dictionary<string, Ink.Runtime.Object> VAR {get; private set;}

    public DialogueVAR(TextAsset loadGlobalsJSON)
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);
        
        VAR = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            VAR.Add(name, value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }

    }


    public void StartListening(Story story)
    {
        VariableToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }


    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (VAR.ContainsKey(name))
        {
            VAR.Remove(name);
            VAR.Add(name, value);
        }
    }

    private void VariableToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in VAR)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
