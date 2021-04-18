using System;
using UnityEngine;

[Serializable]
public class PhotoControl
{
    public Sprite photo;
    public enum PhotoCategory
    {
        cars, hydrants, sidewalks, nothing
    }
    public PhotoCategory photoCate;
}
