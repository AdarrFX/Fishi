using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSetup : MonoBehaviour
{
    public RectTransform hud;
    public RectTransform fishingContainer;
    public RectTransform rod;
    public RectTransform bg;
    public CanvasScaler canvas;
    void Start()
    {
        
        if (Screen.width < Screen.height)
        {
            canvas.matchWidthOrHeight = 0.5f;

            bg.sizeDelta = new Vector2(2000, bg.sizeDelta.y);
            bg.anchorMin = new Vector2(1, 0);
            bg.anchorMax = new Vector2(1, 1);
            bg.pivot = new Vector2(1, 0.5f);

            rod.anchorMin = new Vector2(0.5f, 0);
            rod.anchorMax = new Vector2(0.5f, 0);
            rod.pivot = new Vector2(0.5f, 0);
            rod.anchoredPosition = new Vector2(0, 20);

            fishingContainer.anchorMin = new Vector2(0.5f, 1);
            fishingContainer.anchorMax = new Vector2(0.5f, 1);
            fishingContainer.pivot = new Vector2(0.5f, 1);
            fishingContainer.anchoredPosition = new Vector2(0, -100);

            hud.anchoredPosition = new Vector2(-15, -10);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
