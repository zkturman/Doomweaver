using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieChoiceManager : MonoBehaviour
{
    [SerializeField]
    private MovieOption[] optionsToPick;
    [SerializeField]
    private MovieMenuBuilder menuBuilder;

    public void LogChoice(string movieKey, float choiceWeight)
    {
        bool foundKey = false;
        int i = 0;
        while (i < optionsToPick.Length && !foundKey)
        {
            if (optionsToPick[i].IsValidKey(movieKey))
            {
                optionsToPick[i].RegisterChoice(movieKey, choiceWeight);
                foundKey = true;
            }
            else
            {
                i++;
            }
        }
    }

    public void SetWinners()
    {
        if (optionsToPick.Length != 2)
        {
            Debug.LogError("Incorrect number of movie options.");
        }
        for (int i = 0; i < optionsToPick.Length; i++)
        {
            menuBuilder.SetMovie(optionsToPick[i].GetWinningChoice());
        }
        menuBuilder.gameObject.SetActive(true);
    }
}
