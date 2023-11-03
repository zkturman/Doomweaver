using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

[Serializable]
public class MovieData
{
    [SerializeField]
    private string movieName;
    public string MovieName { get => movieName; }
    [SerializeField]
    private string key;
    public string Key { get => key; }
    [SerializeField]
    private string streamingLink;
    public string StreamingLink { get => streamingLink; }
    [SerializeField]
    private Sprite movieImage;
    public Sprite MovieImage { get => movieImage; }
}
