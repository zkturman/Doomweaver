using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour
{
    [SerializeField]
    private int promptId;
    [SerializeField]
    private GameObject nextCardSet;
    [SerializeField]
    private SetPromptManager promptManager;
    [SerializeField]
    private TextFader promptTextController;

    // Start is called before the first frame update
    void Start()
    {
        string promptText = promptManager.GetPrompt(promptId);
        promptTextController.SetText(promptText);
        promptTextController.FadeIn();
    }

    public void ActivateNextPrompt()
    {
        if (nextCardSet != null)
        {
            nextCardSet.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            MovieChoiceManager movieManager = FindObjectOfType<MovieChoiceManager>();
            movieManager.SetWinners();
        }
    }
}
