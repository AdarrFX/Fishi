using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProgressBarScript : MonoBehaviour
{
    float progressBarHeight;
    float barPosition;
    float decay, boost;
    bool hasFishInSlider;

    public GameObject fish;
    public GameObject fishSlider;
    public GameObject logicControlObj;

    List<RectTransform> fishTransformList;

    RectTransform sliderTransform;
    RectTransform progressBarTransform;
    GameLogic logicController;

    public event Action FishCaught;

    void Start()
    {
        progressBarHeight = transform.parent.GetComponent<RectTransform>().sizeDelta.y;
        barPosition = progressBarHeight / 2;

        sliderTransform = fishSlider.GetComponent<RectTransform>();
        progressBarTransform = GetComponent<RectTransform>();
        logicController = logicControlObj.GetComponent<GameLogic>();
        hasFishInSlider = false;

        fishTransformList = logicController.GetFishList();
        fishTransformList.Add(Instantiate(fish, fishSlider.transform.parent).GetComponent<RectTransform>());

        decay = 80.0f;
        boost = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RectTransform fish in fishTransformList)
        {
            if (fish.anchoredPosition.y < sliderTransform.anchoredPosition.y + sliderTransform.sizeDelta.y &&
                fish.anchoredPosition.y > sliderTransform.anchoredPosition.y)
            {
                barPosition += boost * Time.deltaTime;
                hasFishInSlider = true;
                break;
            }
        }

        if (!hasFishInSlider)
        {
            barPosition -= decay * Time.deltaTime;
        } else
        {
            hasFishInSlider = false;
        }

        if (barPosition < 0)
        {
            barPosition = 0;
        } else if (barPosition > progressBarHeight)
        {
            barPosition = progressBarHeight;
        }

        CheckIfFishCaught();

        if (fishTransformList.Count == 0)
        {
            barPosition = progressBarHeight / 2;
        }

        progressBarTransform.sizeDelta = new Vector2(progressBarTransform.sizeDelta.x, barPosition);

    }

    void CheckIfFishCaught()
    {
        if (barPosition >= progressBarHeight)
        {
            foreach (RectTransform fishTransform in fishTransformList)
            {
                Destroy(fishTransform.gameObject);
            }
            fishTransformList.Clear();
            FishCaught.Invoke();
        }
    }

}
