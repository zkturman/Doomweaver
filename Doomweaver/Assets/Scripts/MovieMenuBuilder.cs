using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovieMenuBuilder : MonoBehaviour
{
    private List<MovieData> selectedMovies = new List<MovieData>();
    private VisualElement rootDocument;
    [SerializeField]
    private string backgroundElementId;
    private VisualElement backgroundElement;
    [SerializeField]
    private string leftMovieElementId;
    [SerializeField]
    private string rightMovieElementId;
    [SerializeField]
    private string movieImageElementId;
    [SerializeField]
    private string movieTitleLabelId;
    [SerializeField]
    private string navigationButtonId;

    private void OnEnable()
    {
        rootDocument = GetComponent<UIDocument>().rootVisualElement;
        backgroundElement = rootDocument.Q<VisualElement>(backgroundElementId);
        backgroundElement.RegisterCallback<GeometryChangedEvent>(FadeInMenu);
        for (int i = 0; i < selectedMovies.Count; i++)
        {
            SetupMovie(selectedMovies[i], i);
        }
    }

    private void FadeInMenu(GeometryChangedEvent evt)
    {
        backgroundElement.AddToClassList("fade-in");
    }

    public void SetMovie(MovieData dataToSet)
    {
        selectedMovies.Add(dataToSet);
    }
    
    public void SetupMovie(MovieData movieToConfigure, int index)
    {
        VisualElement panelToConfigure;
        if (index == 0)
        {
            panelToConfigure = rootDocument.Q<VisualElement>(leftMovieElementId);
        }
        else
        {
            panelToConfigure = rootDocument.Q<VisualElement>(rightMovieElementId);
        }
        setupMoviePanel(panelToConfigure, movieToConfigure);
    }

    private void setupMoviePanel(VisualElement panelToConfigure, MovieData dataToSet)
    {
        VisualElement movieImage = panelToConfigure.Q<VisualElement>(movieImageElementId);
        movieImage.style.backgroundImage = new StyleBackground(dataToSet.MovieImage);
        Label movieTitle = panelToConfigure.Q<Label>(movieTitleLabelId);
        movieTitle.text = dataToSet.MovieName;
        Button navButton = panelToConfigure.Q<Button>(navigationButtonId);
        navButton.clicked += () => Application.OpenURL(dataToSet.StreamingLink);
    }
}
