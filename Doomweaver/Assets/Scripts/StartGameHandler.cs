using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartGameHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjectsToInitialise;
    [SerializeField]
    private string backgroundElementId;
    [SerializeField]
    private string startButtonId;
    VisualElement backgroundElement;
    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        backgroundElement = rootElement.Q<VisualElement>(backgroundElementId);
        Button startGameButton = backgroundElement.Q<Button>(startButtonId);
        startGameButton.clicked += () => startGame();
    }

    private void startGame()
    {
        backgroundElement.RemoveFromClassList("fade-in");
        for (int i = 0; i < gameObjectsToInitialise.Length; i++)
        {
            gameObjectsToInitialise[i].SetActive(true);
        }
        StartCoroutine(startRoutine());
    }

    private IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
