using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovieOption : MonoBehaviour
{
    [SerializeField]
    private int menuPanelId = 0;
    public int MenuPanelId { get => menuPanelId; }
    [SerializeField]
    private MovieData[] movieOptions;
    private Dictionary<string, float> choiceTracker;
    private Dictionary<string, MovieData> movieFinder;

    // Start is called before the first frame update
    void Start()
    {
        choiceTracker = movieOptions.ToDictionary(k => k.Key, x => 0f);
        movieFinder = movieOptions.ToDictionary(k => k.Key, k => k);
    }

    public bool IsValidKey(string movieKey)
    {
        return choiceTracker.ContainsKey(movieKey);
    }

    public void RegisterChoice(string movieKey, float choiceWeight)
    {
        choiceTracker[movieKey] += choiceWeight;
    }
    
    public MovieData GetWinningChoice()
    {
        string winningKey = choiceTracker
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value)
            .FirstOrDefault().Key;
        return movieFinder[winningKey];
    }
}
