using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPromptManager : MonoBehaviour
{
    [SerializeField]
    private string[] Prompts;

    public string GetPrompt(int idToRetrieve)
    {
        string promptText = string.Empty;
        if (isValidPrompt(idToRetrieve))
        {
            promptText = Prompts[idToRetrieve];
        }
        else
        {
            Debug.LogError("Prompt ID does not exist.");
        }
        return promptText;
    }

    private bool isValidPrompt(int promptId)
    {
        return promptId >= 0 && promptId < Prompts.Length;
    }
}
