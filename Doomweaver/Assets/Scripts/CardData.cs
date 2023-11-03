using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardData: MonoBehaviour
{
    [SerializeField]
    private int cardId = -1;
    public int CardId { get => cardId; }

    [SerializeField]
    private string cardName;
    public string CardName { get => cardName; }

    [SerializeField]
    [TextArea]
    private string cardDescription;
    public string CardDescription { get => cardDescription; }

    [SerializeField]
    private string movieKey;
    public string MovieKey { get => movieKey; }

    [SerializeField]
    private float choiceWeight = 0f;
    public float ChoiceWeight { get => choiceWeight; }
}
