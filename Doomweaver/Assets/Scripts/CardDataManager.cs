using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescriptionManager : MonoBehaviour
{
    [SerializeField]
    private string[] Descriptions;

    public string GetCardDescription(int idToRetrieve)
    {
        string cardDescription = string.Empty;
        if (isIdValid(idToRetrieve))
        {
            cardDescription = Descriptions[idToRetrieve];
        }
        else
        {
            Debug.LogError("Card ID has not been configured.");
        }
        return cardDescription;
    }

    private bool isIdValid(int idToCheck)
    {
        return idToCheck >= 0 && idToCheck < Descriptions.Length;
    }
}
