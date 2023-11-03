using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickHandler : MonoBehaviour
{
    [SerializeField]
    private int cardId = 0;
    [SerializeField]
    private CardData cardData;
    [SerializeField]
    private CardSet parentSet;

    private void OnMouseDown()
    {
        parentSet.ActivateNextPrompt();
        FindObjectOfType<MovieChoiceManager>().LogChoice(cardData.MovieKey, cardData.ChoiceWeight);
        FindObjectOfType<DescriptionFader>().FadeOut();
    }
}
