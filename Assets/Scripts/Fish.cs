using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CommonFish", menuName = "Fish")]
public class Fish : ScriptableObject
{
    public string fishName;
    public Color fishColor;
    public Sprite fishSprite;
}
